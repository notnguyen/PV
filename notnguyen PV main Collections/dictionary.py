dictionary1 = {"a": "a", "b": "b", "c": "c", "a": "a", None : None}
dictionary2 = {5 : 5, 1 : 1, 3 : 3, 5 : 5, None : None}
dictionary3 = {True: True, False : False, False : False, None : None}
dictionary4 = {"b": "b", 3 : 3, True: True}


print("dictionary: " + str(dictionary1))
print("dictionary2: " + str(dictionary2))
print("dictionary3: " + str(dictionary3))

print(str(dictionary1.get("a")))

print(len(dictionary1))

# id() - adresa, dir() - funkce, type() - typ

print(dir(dictionary1))

dictionary5 = {dictionary1: dictionary1, "b": "b", 3 : 3, True: True}

print("dictionary5: " + str(dictionary5))