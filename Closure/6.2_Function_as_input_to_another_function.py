import re

# Tato úloha navazuje na příklad 6.1
#
# Vytvořte funkci s následující hlavičkou:
#
# def create_email(appender_function, username):
# Tato funkce bude příjímat dva argumenty.
# První z nich je funkce, která se použije a druhý je username jako string.
# Váš úkol napsat tělo funkce create_email tak, aby
# vytvořila e-mail zavoláním funkce z prvního argumentu a přededala této funkci username.
# Pro otestování použijte příklad:
#
# appender_postfix = append_jecna_postfix
# create_email(appender_postfix, "novak")
# #ma vratit novak@spsejecna.cz
# appender_postfix = append_seznam_postfix
# create_email(appender_postfix, "novak")
# #ma vratit novak@seznam.cz

def append_jecna_postfix(username):
    if not type(username) == str:
        raise TypeError('username must be a string')
    if not re.match(r"[A-Za-z0-9]", username):
        raise ValueError('username must contain only alphanumeric characters')
    return username + "@spsejecna.cz"
#   return f"{username}@spsejecna.cz"

def append_seznam_postfix(username):
    if not type(username) == str:
        raise TypeError('username must be a string')
    if not re.match(r"[A-Za-z0-9]", username):
        raise ValueError('username must contain only alphanumeric characters')
    return username + "@seznam.cz"
#   return f"{username}@seznam.cz"


def create_email(appender_function, username):
    return f"{appender_function(username)}"

appender_postfix = append_jecna_postfix
print(create_email(appender_postfix, "novak"))
# #ma vratit novak@spsejecna.cz

appender_postfix = append_seznam_postfix
print(create_email(appender_postfix, "novak"))
# #ma vratit novak@seznam.cz





