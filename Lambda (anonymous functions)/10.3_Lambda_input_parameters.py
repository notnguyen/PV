# Do proměnných uvedených níže vložte lambda funkce, které budou realizovat danou funkci:
#
# krokovaci_funkce_po_dvou = ... (funkce bude mít parametr x a bude počítat výsledek jako x+2)
# nasobici_funkce = .... (funkce bude mít dva parametry a,b bude počítat jako a * b)
# linearni_funkce = .... (funkce má tři parametry a,b,x a vrací a * x + b)
# konstantni_funkce_peti = ... (fuknce bude pomocí lambdy vracet číslo 5 a nebude přijímat žádné parametry)




krokovaci_funkce_po_dvou = lambda x: x +2
nasobici_funkce = lambda a,b: a * b
linearni_funkce = lambda a,b,x: a * x + b
konstantni_funkce_peti = lambda : 5

print(krokovaci_funkce_po_dvou(10))
print(nasobici_funkce(2, 5))
print(linearni_funkce(2,5,10))
print(konstantni_funkce_peti())