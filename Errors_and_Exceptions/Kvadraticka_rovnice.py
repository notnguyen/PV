import math
import cmath

a = None
b = None
c = None
while a is None or b is None or c is None:
    try:
        a = int(input("Zadej hodnotu a:"))
        b = int(input("Zadej hodnotu b:"))
        c = int(input("Zadej hodnotu c:"))
    except ValueError:
        print("Invalid input")

try:
    d = b ** 2 - 4 * a * c
    sqrt_d = math.sqrt(d)
except ValueError:
    root1 = (-b + cmath.sqrt(d)) / (2 * a)
    root2 = (-b - cmath.sqrt(d)) / (2 * a)
else:
    root1 = (-b + sqrt_d) / (2 * a)
    root2 = (-b - sqrt_d) / (2 * a)
finally:
    print('root1', root1)
    print('root2', root2)
