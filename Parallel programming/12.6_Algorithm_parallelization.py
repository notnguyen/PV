import multiprocessing
import time
import csv
import re

#Na nize uvedeny zdrojovy kod v uloze 12.7 nesahat !
def rok_narozeni_z_rc(rodne_cislo):
    assert type(rodne_cislo) == str
    assert len(rodne_cislo) == 11

    rok_narozeni = int(rodne_cislo[0:2])
    if (rok_narozeni > 21):
        rok_narozeni += 1900
    else:
        rok_narozeni += 2000
    return rok_narozeni

def prumerny_dluh_dle_roku_narozeni(rokOd,rokDo,label):
    soucet = 0
    pocet = 0
    prumerny_dluh = 0

    data = []
    with open('dluznici.csv') as csvfile:
        reader = csv.reader(csvfile, delimiter=',', quotechar='"')
        next(reader, None)  # skip the headers
        for row in reader:
            if (rokOd <= rok_narozeni_z_rc(row[1]) < rokDo):
                pocet += 1
                soucet += int(row[2])

    if(pocet > 0):
        prumerny_dluh = round(soucet/pocet)

    print("Prumerny dluh pro "+label+" je "+str(prumerny_dluh)+" CZK")

#Na vyse uvedeny zdrojovy kod v uloze 12.6 nesahat !

if __name__ == "__main__":
    start = time.time()
    p1 = multiprocessing.Process(target=prumerny_dluh_dle_roku_narozeni, args=(1991, 2001, "dvacatniky"))
    p2 = multiprocessing.Process(target=prumerny_dluh_dle_roku_narozeni, args=(1981, 1991, "tricatniky"))
    p3 = multiprocessing.Process(target=prumerny_dluh_dle_roku_narozeni, args=(1971, 1981, "ctyricatniky"))
    p4 = multiprocessing.Process(target=prumerny_dluh_dle_roku_narozeni, args=(1961, 1971, "padesatniky"))
    p5 = multiprocessing.Process(target=prumerny_dluh_dle_roku_narozeni, args=(1951, 1961, "sedesatniky"))
    p1.start()
    p2.start()
    p3.start()
    p4.start()
    p5.start()
    p1.join()
    p2.join()
    p3.join()
    p4.join()
    p5.join()
    end = time.time()
    print("Vypocet trval {:.6f} sec.".format((end - start)))