

def generatorKrasovychJezerCR():
    try:
        yield "Horní macošské jezírko"
        yield "Dolní macošské jezírko"
        yield "jezírko v Hranické propasti"
        yield "Bozkovské podzemní jezero"
        yield "Točnické jezírko"

    except GeneratorExit:
        print("!Generovani preruseno!")

print("Krasjova jezera v CR")
for jezero in generatorKrasovychJezerCR():
    if jezero == "jezírko v Hranické propasti":
        break
    else:
        print(jezero)