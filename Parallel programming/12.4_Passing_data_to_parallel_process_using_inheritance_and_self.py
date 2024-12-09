import time
import multiprocessing


class VypisCiselProcess(multiprocessing.Process):
    def __init__(self, od, do):
        super().__init__()
        self.od = od
        self.do = do

    def run(self):
        for i in range(self.od, self.do):
            print(i)
            time.sleep(1)

if __name__ == "__main__":
    print("ZACATEK PROGRAMU")
    p1 = VypisCiselProcess(1, 5)
    p1.start()
    p1.join()
    print("KONEC PROGRAMU")