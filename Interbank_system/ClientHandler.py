import configparser
import socket
import socketserver
import logging
from BankModel import Bank, get_ip
from logger_setup import setup_logger

config = configparser.ConfigParser()
config.read('config.ini')
timeout = int(config['bank']['timeout'])
port = int(config['bank']['port'])

setup_logger()

bank_instance = Bank()


def send_command_to_remote(command, remote_ip):
    """
    Odešle příkaz na vzdálený server pomocí TCP socketové spojení.

    Parametry
    ----------
    command : str
        Příkaz, který se má odeslat na vzdálený server.
    remote_ip : str
        IP adresa vzdáleného serveru.

    Vrací
    -------
    str
        Odpověď přijatá od vzdáleného serveru. Pokud dojde k chybě při komunikaci,
        vrátí chybovou zprávu ve formátu "ER Chyba při komunikaci: {str(e)}".

    Výjimky
    -------
    Exception
        Pokud dojde k jakékoli jiné výjimce při komunikaci.
    """
    try:
        with socket.create_connection((remote_ip, port), timeout=timeout) as connection:
            connection.sendall(f"{command}\n".encode("utf-8"))
            response = connection.recv(1024).decode("utf-8").strip()
            return response
    except Exception as e:
        return f"ER Chyba při komunikaci: {str(e)}"


class ClientHandler(socketserver.StreamRequestHandler):
    """
    Třída pro zpracování příchozích požadavků od klientů pomocí TCP.

    Metody:
    handle() - Zpracovává příchozí připojení a požadavky klientů.
    client_request() - Zpracovává jednotlivé příkazy a vrací odpovědi.
    parse_account_and_balance() - Pomocná metoda pro zpracování účtu a částky.
    parse_account_number() - Pomocná metoda pro zpracování čísla účtu.
    """

    def handle(self):
        """
        Zpracovává příchozí požadavky od klienta.

        Tato metoda neustále čte příkazy od klienta a odpovídá na ně, dokud není připojení ukončeno.
        Všechny výjimky jsou ošetřeny a logovány.
        """
        self.request.settimeout(timeout)
        client_ip, client_port = self.client_address
        logging.info(f"Nové připojení {client_ip}:{client_port}")

        while True:
            try:
                command = self.rfile.readline().decode("utf-8").strip()
                if not command:
                    logging.info(f"Klient {client_ip}:{client_port} ukončil spojení.")
                    break
                logging.debug(f"Přijatý příkaz: {command}")
                response = self.client_request(command)
                self.wfile.write(f"{response}\n".encode("utf-8"))
                logging.debug(f"Odeslaná odpověď: {response}")
            except (ConnectionResetError, ConnectionAbortedError):
                logging.info(f"Klient {client_ip}:{client_port} ukončil spojení.")
                break
            except socket.timeout:
                logging.error(f"Vypršel časový limit pro klienta {client_ip}:{client_port}")
                break
            except Exception as e:
                logging.exception(f"Chyba při zpracování požadavku: {e}")
                break

    def client_request(self, command):
        """
        Zpracovává příkaz od klienta.

        Parametry
        ----------
        command : str
            Příkaz, který je zaslán klientem.

        Vrací
        -------
        str
            Odpověď na příkaz. V případě chyby vrací chybovou zprávu.
        """
        command_parts = command.split()
        if not command_parts:
            return "ER Prázdný příkaz."

        cmd = command_parts[0].upper()
        local_ip = get_ip()

        try:
            match cmd:
                case "BC":
                    return f"BC {local_ip}"

                case "AC":
                    account_number = bank_instance.create_account()
                    return f"AC {account_number.number}/{local_ip}"

                case "AD":
                    if len(command_parts) != 3:
                        raise ValueError("Špatný formát příkazu AD.")
                    account_field, amount_field = command_parts[1], command_parts[2]
                    account, amount = self.parse_account_and_balance(account_field, amount_field)
                    if account_field.split("/")[1] != local_ip:
                        return send_command_to_remote(command, account_field.split("/")[1])
                    else:
                        bank_instance.deposit(account, amount)
                        return "AD"

                case "AW":
                    if len(command_parts) != 3:
                        raise ValueError("Špatný formát příkazu AW.")
                    account_field, amount_field = command_parts[1], command_parts[2]
                    account, amount = self.parse_account_and_balance(account_field, amount_field)
                    if account_field.split("/")[1] != local_ip:
                        return send_command_to_remote(command, account_field.split("/")[1])
                    else:
                        bank_instance.withdraw(account, amount)
                        return "AW"

                case "AB":
                    if len(command_parts) != 2:
                        raise ValueError("Špatný formát příkazu AB.")
                    account_field = command_parts[1]
                    account = self.parse_account_number(account_field)
                    if account_field.split("/")[1] != local_ip:
                        return send_command_to_remote(command, account_field.split("/")[1])
                    else:
                        balance = bank_instance.get_balance(account)
                        return f"AB {balance}"

                case "AR":
                    if len(command_parts) != 2:
                        raise ValueError("Špatný formát příkazu AR.")
                    account_field = command_parts[1]
                    account = self.parse_account_number(account_field)
                    if account_field.split("/")[1] != local_ip:
                        raise ValueError("Špatný formát příkazu AR.")
                    bank_instance.remove_account(account)
                    return "AR"

                case "BA":
                    if len(command_parts) != 1:
                        raise ValueError("Špatný formát příkazu BA.")
                    return f"BA {bank_instance.total_balance_accounts()}"

                case "BN":
                    if len(command_parts) != 1:
                        raise ValueError("Špatný formát příkazu BN.")
                    return f"BN {bank_instance.number_of_accounts()}"

                case _:
                    return "ER Nepodporovaný příkaz."

        except Exception as e:
            return f"ER {str(e)}"

    def parse_account_and_balance(self, account_field, amount_field):
        """
        Pomocná metoda pro zpracování účtu a částky.

        Parametry
        ----------
        account_field : str
            Pole obsahující číslo účtu a IP adresu.
        amount_field : str
            Částka pro vklad nebo výběr.

        Vrací
        -------
        tuple
            Tuple obsahující číslo účtu (int) a částku (int).

        Výjimky
        -------
        ValueError
            Pokud formát účtu nebo částky není správný.
        """
        try:
            account_str, ip_part = account_field.split("/")
            account = int(account_str)
            amount = int(amount_field)
            return account, amount
        except Exception:
            raise ValueError("Chyba ve formátu účtu nebo částky.")

    def parse_account_number(self, account_field):
        """
        Pomocná metoda pro zpracování čísla účtu.

        Parametry
        ----------
        account_field : str
            Pole obsahující číslo účtu a IP adresu.

        Vrací
        -------
        int
            Číslo účtu.

        Výjimky
        -------
        ValueError
            Pokud formát čísla účtu není správný.
        """
        try:
            account_str, ip_part = account_field.split("/")
            account = int(account_str)
            return account
        except Exception:
            raise ValueError("Formát čísla účtu není správný.")
