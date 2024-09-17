x = None
while x is None:
    try:
        x = int(input("Zadej cislo: "))
    except ValueError:
        print("Invalid input")
y = int(x) + 1
print(y)