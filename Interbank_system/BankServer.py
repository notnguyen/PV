import configparser
import logging
import socketserver
import argparse
from BankModel import get_ip
from logger_setup import setup_logger
from ClientHandler import ClientHandler

config = configparser.ConfigParser()
config.read('config.ini')
timeout = int(config['bank']['timeout'])
port = int(config['bank']['port'])


class ReusableTCPServer(socketserver.ThreadingMixIn, socketserver.TCPServer):
    allow_reuse_address = True


class BankServer:
    """
    Třída představující bankovní server.

    Atributy
    ----------
    host : str
        IP adresa, na které bude server běžet. Výchozí hodnota je "0.0.0.0".
    port : int
        Číslo portu, na kterém server bude naslouchat. Výchozí hodnota je 65530.
    timeout : int
        Timeout serveru v sekundách. Výchozí hodnota je hodnota z konfiguračního souboru.

    Metody
    -------
    parse_args():
        Zpracuje argumenty příkazové řádky pro server.

    start_server():
        Spustí server a naslouchá příchozím připojením.
    """

    def __init__(self, host="0.0.0.0", port=65530, timeout=timeout):
        self.host = host
        self.port = port
        self.timeout = timeout

    def parse_args(self):
        """
        Zpracuje argumenty příkazové řádky pro server.

        Vrací
        -------
        argparse.Namespace
            Objekt obsahující zpracované argumenty.
        """
        parser = argparse.ArgumentParser()
        parser.add_argument(
            "--port", type=int, default=self.port,
        )
        parser.add_argument(
            "--timeout", type=int, default=self.timeout,
        )
        return parser.parse_args()

    def start_server(self):
        """
        Spustí server a naslouchá příchozím připojením.

        Pokud zadaný port není v rozsahu 65525 až 65535, je zalogována chybová zpráva.
        Jinak je server spuštěn na zadaném hostiteli a portu s daným timeoutem.
        Zaloguje se IP adresa serveru a bude naslouchat navždy, dokud nedojde k výjimce.
        """
        args = self.parse_args()
        if not (65525 <= args.port <= 65535):
            logging.error("Port musí být v rozsahu 65525 až 65535.")
            return

        server_address = (self.host, args.port)
        logging.info(f"Spouštím server na portu {args.port} s timeoutem {args.timeout} sekund.")
        try:
            with ReusableTCPServer(server_address, ClientHandler) as server:
                logging.info(f"IP adresa: {get_ip()}")
                server.serve_forever()
        except Exception as e:
            logging.error(f"Chyba při spuštění serveru: {str(e)}")


def main():
    setup_logger()
    bank_server = BankServer()
    bank_server.start_server()


if __name__ == "__main__":
    main()
