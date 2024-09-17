import math

r = None
while r is None:
    try:
        r = int(input('Zadej poloměr:'))
        if r <= 0:
            raise ArithmeticError("Invalid input")
    except ValueError:
        print("Invalid input")

obsah = math.pi * int(r) ** 2

print(obsah)