vysledky = [
    ("Karel", 31),
    ("Petr", 10),
    ("Honza", 52),
    ("Eva", 61),
    ("Katka", 0),
]

vysledky_vzestupne = sorted(vysledky, key=lambda x: x[1], reverse=False)

print(vysledky_vzestupne)