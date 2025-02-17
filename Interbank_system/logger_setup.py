import configparser
from logging.handlers import RotatingFileHandler
import logging

config = configparser.ConfigParser()
config.read('config.ini')
file = config['log']['file']

def setup_logger():

    file_handler = RotatingFileHandler(
        file,
        maxBytes=5*1024*1024,  # 5 MB
        backupCount=5
    )
    file_handler.setLevel(logging.INFO)


    stream_handler = logging.StreamHandler()
    stream_handler.setLevel(logging.INFO)


    formatter = logging.Formatter('%(asctime)s - %(levelname)s - %(message)s')
    file_handler.setFormatter(formatter)
    stream_handler.setFormatter(formatter)


    logging.basicConfig(
        level=logging.INFO,
        format='%(asctime)s - %(levelname)s - %(message)s',
        handlers=[file_handler, stream_handler]
    )

    logging.info("\n" + "="*50)
    logging.info("New program execution started")
