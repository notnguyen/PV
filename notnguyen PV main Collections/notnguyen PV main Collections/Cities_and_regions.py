mesta = [
    "Praha",
    "Nymburk",
    "Liberec",
    "Brno",
    "Plzen",
]

kraje = [
    "Praha",
    "Stredocesky",
    "Liberecky",
    "Jihomoravsky",
    "Plzensky",
]

mestaPodleKraje = {
    [kraje[0]] : [mesta[0]],
    [kraje[1]] : [mesta[1]],
    [kraje[2]] : [mesta[2]],
    [kraje[3]] : [mesta[3]],
    [kraje[4]] : [mesta[4]],
}

krajePodleMesta = {
    [mesta[0]] : [kraje[0]],
    [mesta[1]] : [kraje[1]],
    [mesta[2]] : [kraje[2]],
    [mesta[3]] : [kraje[3]],
    [mesta[4]] : [kraje[4]],
}

input_mesto = input("Zadej mesto")
print(mestaPodleKraje[input_mesto])

input_kraj = input("Zadej kraj")
print(krajePodleMesta[input_kraj])






