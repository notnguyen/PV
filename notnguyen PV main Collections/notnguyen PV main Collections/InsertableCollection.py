print("Jakymi všemi metodami je možné vložit nový prvek do kolekce a jaké mají tyto metody vstypy?")
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

list.append("d")
list2.append(3)

list.insert(4, "e")
list2.insert(4, 8)

list.extend("f")
list2.extend([6])

print("list: " + str(list))
print("list2: " + str(list2))
print()

# Set {}
set = {"a", "b", "c"}
set2 = {9, 1, 7, 5}

set.add("d")
set2.add(3)

set.update({"e"})
set2.update({6})

print("set: " + str(set))
print("set2: " + str(set2))
print()

# Dictionary { : }
dictionary = {"a": "a", "b": "b", "c": "c"}
dictionary2 = {9: 9, 1: 1, 7: 7, 5: 5}

dictionary["d"] = "d"
dictionary2[3] = 3

dictionary.update({"e": "e"})
dictionary2.update({3: 3})

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