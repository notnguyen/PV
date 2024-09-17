
input1 = None
valid_inputs = {"U", "I", "R"}

while input1 not in valid_inputs:
    input1 = input("Zadejte co chcete vypocitat: U - napeti, I - proud, R - odpor: ")
    if input1 not in valid_inputs:
        print("Špatný vstupní parametr. Zkuste to znovu.")
if input1 == "I":
    U = None
    while U is None:
        try:
            U = float(input("U:"))
        except ValueError:
            print("spatny vstupny parametr")
    R = None
    while R is None:
        try:
            R = float(input("R:"))
        except ValueError:
            print("spatny vstupny parametr")
    I = U / R
    print("I: " + str(I))
    exit()
if input1 == "U":
    I = None
    while I is None:
        try:
            I = float(input("I:"))
        except ValueError:
            print("spatny vstupny parametr")
    R = None
    while R is None:
        try:
            R = float(input("R:"))
        except ValueError:
            print("spatny vstupny parametr")
    raise NotImplementedError
if input1 == "R":
    U = None
    while U is None:
        try:
            U = float(input("U:"))
        except ValueError:
            print("spatny vstupny parametr")
    I = None
    while I is None:
        try:
            I = float(input("I:"))
        except ValueError:
            print("spatny vstupny parametr")
    raise NotImplementedError
