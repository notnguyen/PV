# Napište metodu, která bude součástí diskusního fóra na webu.
# Na vstupu přijme dva argumenty: nickname autora, text autora
# a vrátí SQL příkaz pro vložení příspěvku do MySQL databázové tabulky, která je definována takto:
#
# CREATE TABLE PRISPEVEK (
#
#   ID INT NOT NULL AUTO_INCREMENT,
#
#   AUTHOR VARCHAR(100) NOT NULL,
#
#   TEXT TINYTEXT NOT NULL,
#
#   PRIMARY KEY (ID));
#
# Pro otestování je třeba SQL string vypsat na obrazovku a otestovat pomocí klienta MySQL Workbench.


def create_command(nickname, text):
    sql_command = f"INSERT INTO PRISPEVEK (AUTHOR, TEXT) VALUES ('{nickname}', '{text}');"
    return sql_command

nickname = input("Nickname: ")
text = input("Text: ")

print(create_command(nickname, text))