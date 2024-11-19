
def generatorITVelikanu():
    try:
        yield "Steve Jobs"
        yield "Richard Stallman"
        yield "Linus Torvalds"

    except GeneratorExit:
        print("!Generovani preruseno!")


print("Velikani v IT:")
for osoba in generatorITVelikanu():
    print(osoba)