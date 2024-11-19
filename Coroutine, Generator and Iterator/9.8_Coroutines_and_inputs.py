# def konverzace():
#     yield "Dobrý den"
#
#     jmeno = yield "Jak se jmenuješ?"
#
#     yield "Zdravím Tě "+ str(jmeno)
#
#     yield "Naschledanou"
#
# k = konverzace()
#
# odpoved = next(k) #posun k prvnimu yieldu
# print(odpoved)
#
# odpoved = next(k) #posun k druhemu yieldu + zacatek naslouchani vstupu
# print(odpoved)
#
# odpoved = k.send("Ondra")  #poslani vstypu + posun na treti yield
# print(odpoved)
#
# odpoved = next(k) #posun na ctvrty yield
# print(odpoved)
# k.close()
#
# k = konverzace()
#
# odpoved = k.send(None) #posun k prvnimu yieldu
# print(odpoved)
#
# odpoved = k.send(None) #posun k druhemu yieldu + zacatek naslouchani vstupu
# print(odpoved)
#
# odpoved = k.send("Petr") #poslani vstypu + posun na treti yield
# print(odpoved)
#
# odpoved = k.send(None) #posun na ctvrty yield
# print(odpoved)
# k.close()

def vydej_obedu():
    menu = [
         "vitamínový nápoj",
         "polévka česneková s bramborem",
         "segedínský guláš, houskové knedlíky",
         "jablko",
    ]

    yield menu[0]

    volba = yield "Choose A or B"

    if volba == "A":
        yield menu[1]
    elif volba == "B":
        yield menu[2]
    else:
        yield menu[3]


o = vydej_obedu()
bla = next(o)
print(bla)
next(o)
bla = o.send("C")
print(bla)
o.close()