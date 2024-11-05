import sys

def add(a,b):
    return a+b

if __name__ == "__main__":
    try:
        if len(sys.argv) != 3:
            print("Usage: python3 skript1.py <number1> <number2>")
            sys.exit(1)

        a = float(sys.argv[1])
        b = float(sys.argv[2])

        result = add(a, b)
        print("Vysledek je", result)
    except ValueError:
        print("Please enter valid numbers.")
