def generatorSudychCisel(od, do):
    i = od
    while(i < do):
        yield i + 1
        i = i + 2

for x in generatorSudychCisel(1,50):
    print(x)