# Představte si, že namísto Vás naprogramuje nějakou funkci jiná funkce.
# Zdá se to jako scifi? Ale vůbec ne, když můžeme funkci uložit do proměnné
# a když můžeme proměnnou vrátit (return), není problém aby funkce vracela jinou funkci.

# Vaše úloha je jednoduchá, naprogramujte dvě funkce které přijmou dva parametry jméno a
# přijímení a obě budou vypisovat jeden string ve kterém je naformátováno jméno takto:
#
# formatuj_prijimeni_prvni, která pri volani prikladu nize vypise "Novak Jan"
#
# formatuj_prijimeni_prvni("Jan", "Novak")
# formatuj_monogram, která pri volani prikladu nize vypise "J.N."
#
# formatuj_monogram("Jan", "Novak")

# Následne vytvorte funkci vyber_formatovaci_funkci(delka), která
# přijímá jeden parametr delka jako délku textu
# a pokud je délka menší než 4 znaky vráti jako formátovací funkci formatuj_monogram
# a v opacnem pripade formatuj_prijimeni_prvni. Kod muzete vyzkouset na:
#
# formatovac = vyber_formatovaci_funkci(3)
# formatovac("Jan", "Novak")
# formatovac = vyber_formatovaci_funkci(155)
# formatovac("Jan", "Novak")

def formatuj_prijimeni_prvni(firstName, lastName):
    return f"{lastName} {firstName}"

def formatuj_monogram(firstName, lastName):
    return f"{firstName[0]}.{lastName[0]}."

def vyber_formatovaci_funkci(delka):
    if delka < 4:
        return formatuj_monogram
    else:
        return formatuj_prijimeni_prvni


print(formatuj_prijimeni_prvni("Jan", "Novak"))

print(formatuj_monogram("Jan", "Novak"))

formatovac = vyber_formatovaci_funkci(3)
print(formatovac("Jan", "Novak"))

formatovac = vyber_formatovaci_funkci(155)
print(formatovac("Jan", "Novak"))