# Napište metodu password_policy_check(username, password), která přijme na vstupu heslo a zkontroluje,
# jestli heslo odpovídá následujícím parametrům pomocí regulárních výrazů:
#
# Heslo musí být minimálně 10 znaků.
# Heslo musí obsahovat alespoň jedno číslo.
# Heslo musí obsahovat alespoň jedno písmeno malé a jedno písmeno velké abecedy
# Heslo musí obsahovat alespoň nečíselný a nepísmený znak.
# Heslo nesmí obsahovat username.
# Heslo nesmí obsahovat jakýkkoli podřetězec username delší než 3 znaky.


import re

def password_policy_check(username, password):
    if len(password) < 10:
        return "Heslo musi byt minimalne 10 znaku dlouhe"
    if not re.search(r'\d', password):
        return "Heslo musi obsahovat alespon jednu cislici"
    if not re.search(r'[a-z]', password) or not re.search(r'[A-Z]', password):
        return "Heslo musi obsahovat alespon jedno velke a male pismeno"
    if not re.search(r"[^\w\s]", password):
        return "Heslo musi obsahovat alespon jeden specialni znak"
    if username in password:
        return "heslo nesmi obsahovat username"
    for i in range(len(username) - 3):
        sub_str = username[i:i + 4]
        if sub_str.lower() in password.lower():
            return f"Heslo nesmi obsahovat podretezec uzivatelskeho jmena: {sub_str}"
    return "Heslo odpodivda pozadavkum"

nickname = input("Nickname: ")
password = input("Password: ")

print(password_policy_check(nickname, password))