mesta = [
    'Praha',
    'České Budějovice',
    'Písek',
    'Hradec Králové',
    'Ústí nad Labem',
    'Děčín',
    'Olomouc',
    'Zlín',
    'Břeclav',
]

prameny = [
    'Šumava',
    'Krkonošsko',
    'Králíky',
]

reky = {
    'Vltava': {
        'pramen': [prameny[0]],
        'mesta': [mesta[0], mesta[1], mesta[2]]
    },
    'Labe': {
        'pramen': [prameny[1]],
        'mesta': [mesta[3], mesta[4], mesta[5]]
    },
    'Morava': {
        'pramen': [prameny[2]],
        'mesta': [mesta[6], mesta[7], mesta[8]]
    }
}

input_mesto = input("Zadej mesto: ")
rivers = []
for river, value in reky.items():
    if input_mesto in value['mesta']:
        rivers.append(river)
print(rivers)

input_reka = input("Zadej reka: ")




