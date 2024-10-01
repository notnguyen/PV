print("Jakymi všemi metodami je možné upravit hodnotu existujícího prvek v kolekci a jaké mají tyto metody vstypy?")
print()

# Tuple ()
tuple = ("a", "b", "c")
tuple2 = (9, 1, 7, 5)

print("tuple: " + str(tuple))
print("tuple2: " + str(tuple2))
print()

# List []
list = ["a", "b", "c"]
list2 = [9, 1, 7, 5]

list[0] = "d"
list2[0] = 6

print("list: " + str(list))
print("list2: " + str(list2))
print()

# Set {}
set = {"a", "b", "c"}
set2 = {9, 1, 7, 5}

print("set: " + str(set))
print("set2: " + str(set2))
print()

# Dictionary { : }
dictionary = {"a": "a", "b": "b", "c": "c"}
dictionary2 = {9: 9, 1: 1, 7: 7, 5: 5}

dictionary["a"] = "d"
dictionary2[9] = 6

dictionary.update({"b": "e"})
dictionary2.update({1: 8})

print("dictionary: " + str(dictionary))
print("dictionary2: " + str(dictionary2))
print()

# String ""

string = "abc"
string2 = "9175"

string += "d"
string2 += "3"

print("string: " + string)
print("string2: " + string2)