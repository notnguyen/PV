# Opravte metodu z úlohy 4.1. aby nebylo možné provést SQL Injection.
# Co je SQL Injection?
#
# To je například, když v SQL používáte pro stringu znak
# " (uvozovky) a hacker vloží jako nickname autora string: "\",\"\"); DROP TABLE PRISPEVEK; --"
# a tim cely systém hacknut. Svůj kód otestujte v pomocí klienta MySQL Workbench.


import re

def create_command(nickname, text):
    if not re.match(r"^[a-zA-Z0-9\s.,?!_-]+$", nickname):
        return "Nickname obsahuje nepovolené znaky."
    if not re.match(r"^[a-zA-Z0-9\s.,?!_-]+$", text):
        return "Text obsahuje nepovolené znaky."
    sql_command = f"INSERT INTO PRISPEVEK (AUTHOR, TEXT) VALUES ('{nickname}', '{text}');"
    return sql_command

nickname = input("Nickname: ")
text = input("Text: ")

print(create_command(nickname, text))