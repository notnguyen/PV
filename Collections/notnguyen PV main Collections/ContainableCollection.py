print("Jakymi všemi metodami je možné ověřit jestli kolekce obsahuje nějaký prvek?")
print()

# Tuple ()
tuple = ("a", "b", "c")
tuple2 = (9, 1, 7, 5)

print("a" in tuple)
print(9 in tuple2)
print()

# List []
list = ["a", "b", "c"]
list2 = [9, 1, 7, 5]

print("a" in list)
print(9 in list2)
print()

# Set {}
set = {"a", "b", "c"}
set2 = {9, 1, 7, 5}

print("a" in set)
print(9 in set2)
print()

# Dictionary { : }
dictionary = {"a": "a", "b": "b", "c": "c"}
dictionary2 = {9: 9, 1: 1, 7: 7, 5: 5}

print("a" in dictionary)
print(9 in dictionary2)
print()

# String ""

string = "abc"
string2 = "9175"

print("a" in string)
print("9" in string2)
print()