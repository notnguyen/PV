# def generatorMest():
#     yield "Praha"
#     yield "Brno"
#     yield "Ostrava"
#
# mesta = generatorMest()
#
# print(next(mesta))
# print(next(mesta))


def generatorKrasovychJezerCR():
    try:
        yield "Horní macošské jezírko"
        yield "Dolní macošské jezírko"
        yield "jezírko v Hranické propasti"
        yield "Bozkovské podzemní jezero"
        yield "Točnické jezírko"

    except GeneratorExit:
        print("!Generovani preruseno!")

jezero = generatorKrasovychJezerCR()

try:
    while jezero:
        print(next(jezero))
except StopIteration:
    pass