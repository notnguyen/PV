print("Je možné kolekce vnořovat, tedy vložit jako prvek kolekce další kolekci s několika prvky?")
print()

# Tuple ()
tuple = ("a", "b", "c")
tuple2 = (9, 1, 7, 5)
tuple3 = (tuple, tuple2)

print("tuple: " + str(tuple))
print("tuple2: " + str(tuple2))
print("tuple3: " + str(tuple3))
print()

# List []
list = ["a", "b", "c"]
list2 = [9, 1, 7, 5]
list3 = [list, list2]

print("list: " + str(list))
print("list2: " + str(list2))
print("list3: " + str(list3))
print()

# Set {}
set = {"a", "b", "c"}
set2 = {9, 1, 7, 5}
# set3 = {set, set2}

print("set: " + str(set))
print("set2: " + str(set2))
# print("set3: " + str(set3))
print()

# Dictionary { : }
dictionary = {"a": "a", "b": "b", "c": "c"}
dictionary2 = {9: 9, 1: 1, 7: 7, 5: 5}
dictionary3 = {True: tuple, set: dictionary2}

print("dictionary: " + str(dictionary))
print("dictionary2: " + str(dictionary2))
print("dictionary3: " + str(dictionary3))
print()

# String ""

string = "abc"
string2 = "9175"
string3 = "True, False"

print("string: " + string)
print("string2: " + string2)
print("string3: " + string3)