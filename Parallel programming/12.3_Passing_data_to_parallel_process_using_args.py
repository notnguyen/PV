import time
import multiprocessing

def vypis_cisel(od, do):
    for i in range(od,do):
        print(i)
        time.sleep(1)

if __name__ == "__main__":
    print("ZACATEK PROGRAMU")

    od = 1
    do = 5

    # p1 = multiprocessing.Process(target=vypis_cisel(od, do))
    p1 = multiprocessing.Process(target=vypis_cisel, args=(od, do))
    p1.start()
    p1.join() # Hlavní proces počká na dokončení paralelního procesu
    print("KONEC PROGRAMU")