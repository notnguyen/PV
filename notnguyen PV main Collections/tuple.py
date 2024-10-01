from itertools import count

tuple1 = ("a", "b", "c", "a", None)
tuple2 = (5, 1, 3, 5, None)
tuple3 = (True, False, False, None)
tuple4 = ("b", 3, True)

print("tuple: " + str(tuple1))
print("tuple2: " + str(tuple2))
print("tuple3: " + str(tuple3))
print("tuple4: " + str(tuple4))

print(tuple1[1])

print(len(tuple1))

print(dir(tuple1))

tuple5 = (tuple1, "b", 3, True)

print("tuple5: " + str(tuple5))