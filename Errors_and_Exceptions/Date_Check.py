from datetime import datetime
from turtledemo.clock import datum

year = None
while year is None:
    try:
        year = int(input("Zadej rok narozeni"))
        if datetime.now().year - year < 0 or datetime.now().year - year > 119:
            raise Exception("spatny rok narozeni")
    except ValueError:
        print("spatny vstupny parametr")
month = None
while month is None:
    try:
        month = int(input("Zadej mesic narozeni"))
        if month < 1 or month > 12:
            raise Exception("spatny mesic narozeni")
    except ValueError:
        print("spatny vstupny parametr")
day = None
while day is None:
    try:
        day = int(input("Zadej den narozeni"))
        if day < 1 or day > 31:
            raise Exception("maximani hodnota je 31")
        if month == 2:
            if day < 0 or day > 29:
                raise Exception("unor ma maximalne 29 dni")
        if month == 4 or day == 6 or day == 9 or day == 11:
            if day < 1 or day > 30:
                raise Exception("spatna hodnota")
    except ValueError:
        print("spatny vstupny parametr")
if 6 < month < 9:
    print("nepovolene datum")