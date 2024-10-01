print("Jakymi všemi metodami je možné smazat/odebrat existující prvek do kolekce a jaké mají tyto metody vstypy?")
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

list.remove("c")
list2.remove(5)

list.pop(0)
list2.pop(0)

del list[0]
del list2[0]

print("list: " + str(list))
print("list2: " + str(list2))
print()

# Set {}
set = {"a", "b", "c"}
set2 = {9, 1, 7, 5}

set.remove("c")
set2.remove(5)

set.discard("b")
set2.discard(7)

set.pop()
set2.pop()

print("set: " + str(set))
print("set2: " + str(set2))
print()

# Dictionary { : }
dictionary = {"a": "a", "b": "b", "c": "c"}
dictionary2 = {9: 9, 1: 1, 7: 7, 5: 5}

dictionary.pop('c')
dictionary2.pop(5)

del dictionary['b']
del dictionary2[7]

dictionary.popitem()
dictionary2.popitem()

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