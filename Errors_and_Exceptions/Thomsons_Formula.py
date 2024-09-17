from math import sqrt
F = None
while F is None:
    L = None
    while L is None:
        try:
            L = int(input("Zadej indukcnost [H]:"))
        except ValueError:
            print("Invalid input")

    C = None
    while C is None:
        try:
            C = int(input("Zadej kapacitu [F]:"))
        except ValueError:
            print("Invalid input")

    if not L * C < 0:
        F = 1 / (2 * 3.14 * sqrt(L * C))
        print("Frekvence je: " + str(F) + "Hz")