# Vytvořte funkci vytvor_pocitadlo_navstevniku(), které nebude mít žádné vstupy.
# Uvnitř založte proměnnou počet návštevníku, inicializovanou na nula a vnitřní funkci pridej_navstevnika(), kterou vrátíte.
# Když někdo spustí přidej návštěvníka, tak funkce musí udělat dvě věci: 1. Zvýší počet návštěvníku +1 a vráti aktuální počet.
#
# Otestujte to na následujícím zdrojovém kódu:

def vytvor_pocitadlo_navstevniku()
    pocet_navstevniku = 0

    def pridej_navstevnika():
        nonlocal pocet_navstevniku
        pocet_navstevniku += 1
        return pocet_navstevniku


pridej_navstevnika = vytvor_pocitadlo_navstevniku()
pocet = pridej_navstevnika()
print(pocet)
pocet = pridej_navstevnika()
print(pocet)
pocet = pridej_navstevnika()
print(pocet)