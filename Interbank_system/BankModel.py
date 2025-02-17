import configparser
import json
import os
import threading
import logging
import socket
from logger_setup import setup_logger

config = configparser.ConfigParser()
config.read('config.ini')
bank_data = config['bank']['bank_data']
account_num_min = int(config['bank']['account_num_min'])
account_num_max = int(config['bank']['account_num_max'])

setup_logger()

def get_ip():
    """
    Získává IP adresu aktuálního počítače.

    Tato funkce vytvoří UDP socket, připojí se k známé IP adrese a portu,
    a poté získá IP adresu lokálního počítače z jména socketu.
    Pokud dojde k jakékoli chybě během procesu, funkce se vrátí k výchozí hodnotě '127.0.0.1'.

    Parametry:
    Žádné

    Vrátí:
    str: IP adresa aktuálního počítače.
    """
    s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    s.settimeout(0)
    try:
        s.connect(('10.254.254.254', 1))
        ip_address = s.getsockname()[0]
    except Exception:
        ip_address = '127.0.0.1'
    finally:
        s.close()
    return ip_address


class Account:
    """
    Reprezentace bankovního účtu.

    Tato třída reprezentuje bankovní účet s číslem účtu a zůstatkem. Poskytuje metody pro
    vkládání a vybírání prostředků a získávání zůstatku účtu.
    """

    def __init__(self, number, balance=0):
        """
        Inicializuje nový bankovní účet.

        Parametry:
        number (int): Číslo účtu.
        balance (int, volitelný): Počáteční zůstatek na účtu (defaultně 0).
        """
        self.number = number
        self.balance = balance

    def deposit(self, amount):
        """
        Vkládá částku na účet.

        Parametry:
        amount (int): Částka, která se má vložit.

        Výjimky:
        ValueError: Pokud je částka záporná.
        """
        if amount < 0:
            raise ValueError("Částka musí být nezáporná.")
        self.balance += amount

    def withdraw(self, amount):
        """
        Provádí výběr z účtu.

        Parametry:
        amount (int): Částka, která se má vybrat.

        Výjimky:
        ValueError: Pokud je částka záporná nebo pokud na účtu není dostatek prostředků.
        """
        if amount < 0:
            raise ValueError("Částka musí být nezáporná.")
        if self.balance < amount:
            raise ValueError("Nedostatečné prostředky.")
        self.balance -= amount

    def get_balance(self):
        """
        Získá aktuální zůstatek účtu.

        Vrátí:
        int: Aktuální zůstatek na účtu.
        """
        return self.balance


class Bank:
    """
    Třída pro správu banky a účtů.
    """

    def __init__(self, bank_data=bank_data):
        """
        Inicializuje instanci třídy Bank.

        Parametry:
        bank_data (str): Cesta k souboru, kde jsou uložena data účtů.
        """
        self.bank_data = bank_data
        self.lock = threading.Lock()
        self.accounts = {}
        self.load_data()

    def deposit(self, account_num, amount):
        """
        Vkládá částku na účet.

        Parametry:
        account_num (int): Číslo účtu.
        amount (int): Částka, která se má vložit.

        Výjimky:
        ValueError: Pokud účet s daným číslem neexistuje.
        """
        if account_num not in self.accounts:
            raise ValueError(f"Účet {account_num} neexistuje.")
        account = self.accounts[account_num]
        account.deposit(amount)
        self.save_data()
        logging.info(f"Vloženo {amount} na účet {account_num}.")

    def withdraw(self, account_num, amount):
        """
        Provádí výběr z účtu.

        Parametry:
        account_num (int): Číslo účtu.
        amount (int): Částka, která se má vybrat.

        Výjimky:
        ValueError: Pokud účet s daným číslem neexistuje.
        """
        if account_num not in self.accounts:
            raise ValueError(f"Účet {account_num} neexistuje.")
        account = self.accounts[account_num]
        account.withdraw(amount)
        self.save_data()
        logging.info(f"Vybráno {amount} z účtu {account_num}.")

    def get_balance(self, account_num):
        """
        Vrací aktuální zůstatek na účtu.

        Parametry:
        account_num (int): Číslo účtu.

        Vrací:
        int: Aktuální zůstatek na účtu.

        Výjimky:
        ValueError: Pokud účet s daným číslem neexistuje.
        """
        if account_num not in self.accounts:
            raise ValueError(f"Účet {account_num} neexistuje.")
        return self.accounts[account_num].get_balance()

    def create_account(self):
        """
        Vytvoří nový účet s unikátním číslem v daném rozsahu.

        Vrací:
        Account: Nově vytvořený účet.

        Výjimky:
        ValueError: Pokud není k dispozici žádné volné číslo účtu.
        """
        for account_num in range(account_num_min, account_num_max + 1):
            if account_num not in self.accounts:

                new_account = Account(account_num)
                self.accounts[account_num] = new_account

                self.save_data()

                logging.info(f"Účet {account_num} byl úspěšně vytvořen.")
                return new_account
        logging.error("Žádné volné číslo účtu není k dispozici.")
        raise ValueError("Není k dispozici žádné volné číslo účtu.")

    def remove_account(self, account_num):
        """
        Odstraní účet, pokud je jeho zůstatek 0.

        Parametry:
        account_num (int): Číslo účtu.

        Výjimky:
        ValueError: Pokud účet s daným číslem neexistuje.
        """
        if account_num not in self.accounts:
            raise ValueError(f"Účet {account_num} neexistuje.")
        account = self.accounts[account_num]
        if account.get_balance() == 0:
            del self.accounts[account_num]
            self.save_data()
            logging.info(f"Účet {account_num} byl odstraněn.")
        else:
            raise ValueError("Účet má zůstatek, nelze odstranit.")

    def total_balance_accounts(self):
        """
        Vrací celkový zůstatek všech účtů.

        Vrací:
        int: Celkový zůstatek všech účtů.
        """
        with self.lock:
            return sum(account.get_balance() for account in self.accounts.values())

    def number_of_accounts(self):
        """
        Vrací počet účtů v bance.

        Vrací:
        int: Počet účtů v bance.
        """
        with self.lock:
            return len(self.accounts)

    def load_data(self):
        """
        Načte data ze souboru, pokud existují.
        """
        if os.path.isfile(self.bank_data):
            try:
                with open(self.bank_data, "r") as file:
                    raw_data = json.load(file)
                    self.accounts = {int(key): Account(int(key), int(value)) for key, value in raw_data.items()}
                    logging.info(f"Data načtena ze souboru {self.bank_data}")
            except (json.JSONDecodeError, IOError) as e:
                logging.error(f"Chyba při načítání dat: {str(e)}")
        else:
            logging.info("Žádná data nenalezena.")

    def save_data(self):
        """
        Uloží data účtů do souboru.
        """
        with self.lock:
            try:
                data_to_save = {str(account.number): account.balance for account in self.accounts.values()}
                with open(self.bank_data, "w") as file:
                    json.dump(data_to_save, file)
                logging.debug(f"Data uložena do souboru {self.bank_data}")
            except Exception as e:
                logging.error(f"Chyba při ukládání dat: {str(e)}")
