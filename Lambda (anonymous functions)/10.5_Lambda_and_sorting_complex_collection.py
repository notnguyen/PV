zbozi = [
    {
        "name" : "IPHONE 14",
        "price" : 22169.0,
        "category" : (12, "Mobilní telefony")
    },
    {
        "name" : "Fujifilm XT30",
        "price" : 22269.0,
        "category" : (2, "Fotoaparáty")
    },
    {
        "name" : "Niceboy HIVE Pins Black",
        "price" : 999.0,
        "category" : (4, "Sluchátka")
    }
]

cena_vzestupne = sorted(zbozi, key = lambda i: i["price"], reverse = False)
nazev_sestupne = sorted(zbozi, key = lambda i: i["name"], reverse = True)
kategorie_vzestupne = sorted(zbozi, key = lambda i: i["category"], reverse = False)

print(cena_vzestupne)
print(nazev_sestupne)
print(kategorie_vzestupne)