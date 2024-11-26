# Vytvořte kombinací funkcí list(map(...)) a lambda výrazu nové pole s názvem pole2,
# kde budou hodnoty vyšší o 30% z proměnné pole

# Vytvořte kombinací funkcí list(filter(...)) a lambda vyrazu další pole s názvem pole3,
# kde budou hodnoty vyšší než 120.0 z proměnné pole

# Vytvořte kombinací funkcí list(), filter() a map() a lamda výrazů nové pole s názve pole4,
# kde budou hodnoty vyšší než 110.0 po předchozím navýšení o 30% a snížení o 5.
# Vyjděte opět z proměnné pole


pole = [100.10, 323.2, 355.9, 214.19, 87.0]

plus_30_procent = lambda x: x * 1.30
x = list(map(plus_30_procent, pole))
print(x)


