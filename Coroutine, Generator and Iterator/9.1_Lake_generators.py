# Upravte zdrojový kód generátoru jezer tak, aby
# metoda negenerovala "Krasová jezera" v ČR,
# ale "Rašelinná jezera" podle Vašich znalostí z přírodopisu a zeměpisu ze ZŠ.


# def generatorKrasovychJezerCR():
#     yield "Horní macošské jezírko"
#     yield "Dolní macošské jezírko"
#     yield "jezírko v Hranické propasti"
#     yield "Bozkovské podzemní jezero"
#     yield "Točnické jezírko"
#
# print("Krasjova jezera v CR")
# for jezero in generatorKrasovychJezerCR():
#     print(jezero)

def generatorRaselinnychJezerCR():
    yield "Černé jezero"
    yield "Čertovo jezero"
    yield "Tříjezerní slať"
    yield "Mladé Buky"
    yield "Rejvízská rašeliniště"

print("Rašelinná jezera v ČR")
for jezero in generatorRaselinnychJezerCR():
    print(jezero)
