import re

# 1. Nadefinujte funkci, která přijme uživatelské jméno jako string
# a připojí na za něj řetezec "@spsejecna.cz" jako e-mail.
# Funkce se bude jmenovat append_jecna_postfix

# 2. Nadefinujte druhou funkci, která bude fungovat  stejně jako předchozí, ale
# na konec připojí "@seznam.cz" a bude se jmenovat append_seznam_postfix

# 3. Založte proměnnou appender_postfix a vložte do ní funkci z prvního bodu.
# Následně otestujte funkčnost pomocí příkazu:
# appender_postfix("novak")

# 4. Proveďte vložení funkce z bodu 2. do proměnné appender_postfix a opět zkontrolujte funkčnost.


def append_jecna_postfix(username):
    if not type(username) == str:
        raise TypeError('username must be a string')
    if not re.match(r"[A-Za-z0-9]", username):
        raise ValueError('username must contain only alphanumeric characters')
    return username + "@spsejecna.cz"

def append_seznam_postfix(username):
    if not type(username) == str:
        raise TypeError('username must be a string')
    if not re.match(r"[A-Za-z0-9]", username):
        raise ValueError('username must contain only alphanumeric characters')
    return username + "@seznam.cz"


appender_postfix = append_jecna_postfix
print(appender_postfix("honza"))


appender_postfix = append_seznam_postfix
print(appender_postfix("honza"))
