class MnozinaException(Exception):
    """Výjimka pro neplatné operace s Mnozina."""
    pass

class Mnozina:
    def __init__(self):
        self.prvky = []

    def vloz(self, prvek):
        """Vloží prvek do množiny, pokud tam již není."""
        if prvek not in self.prvky:
            self.prvky.append(prvek)

    def odeber(self, prvek):
        """Odstraní prvek z množiny, pokud existuje."""
        if prvek in self.prvky:
            self.prvky.remove(prvek)

    def prunik(self, jina_mnozina):
        """Vrátí průnik této množiny a jiné množiny."""
        if jina_mnozina is None:
            return self
        if not isinstance(jina_mnozina, Mnozina):
            raise MnozinaException("Průnik lze provést pouze s jinou množinou.")
        vysledek = Mnozina()
        for prvek in self.prvky:
            if prvek in jina_mnozina:
                vysledek.vloz(prvek)
        return vysledek

    def sjednoceni(self, jina_mnozina):
        """Vrátí sjednocení této množiny a jiné množiny."""
        if jina_mnozina is None:
            return self
        if not isinstance(jina_mnozina, Mnozina):
            raise MnozinaException("Sjednocení lze provést pouze s jinou množinou.")
        vysledek = Mnozina()
        for prvek in self.prvky:
            vysledek.vloz(prvek)
        for prvek in jina_mnozina:
            vysledek.vloz(prvek)
        return vysledek

    def __len__(self):
        """Vrátí počet prvků v množině."""
        return len(self.prvky)

    def __contains__(self, prvek):
        """Zjišťuje, zda je prvek v množině."""
        return prvek in self.prvky

    def __eq__(self, jina_mnozina):
        """Porovnání dvou množin."""
        if not isinstance(jina_mnozina, Mnozina):
            return False
        return set(self.prvky) == set(jina_mnozina.prvky)

    def __iter__(self):
        """Umožňuje iteraci přes prvky množiny."""
        return iter(self.prvky)



# Zde doplnte importy sveho zdrojovoho kodu.

import unittest

class MnozinaTestCase(unittest.TestCase):

    def test_vytvoreni(self):
        m = Mnozina()
        m.vloz("Pepa")
        m.vloz(1)
        m.vloz(3.14)

    def test_pocet_prvku(self):
        m = Mnozina()
        m.vloz("A")
        m.vloz("B")
        m.vloz("C")
        self.assertEqual(len(m), 3)
        m.vloz("D")
        self.assertEqual(len(m), 4)
        m.odeber("B")
        self.assertEqual(len(m), 3)

    def test_neopakovani_prvku(self):
        m = Mnozina()
        m.vloz("A")
        m.vloz("A")
        m.vloz("A")
        self.assertEqual(len(m), 1)
        m.vloz("B")
        self.assertEqual(len(m), 2)
        m.vloz("B")
        self.assertEqual(len(m), 2)

    def test_porovnani(self):
        m1 = Mnozina()
        m1.vloz("A")
        m1.vloz("B")

        m2 = Mnozina()
        m2.vloz("B")
        m2.vloz("A")

        self.assertEqual(m1, m1)
        self.assertEqual(m2, m2)
        self.assertEqual(m1, m2)
        self.assertEqual(m2, m1)

        m2.vloz("C")
        self.assertNotEqual(m1, m2)
        self.assertNotEqual(m2, m1)

    def test_vyhledani(self):
        m = Mnozina()
        m.vloz("Pepa")
        m.vloz(1)
        m.vloz(3.14)

        self.assertTrue(1 in m)
        self.assertFalse(2 in m)
        self.assertTrue(3.14 in m)
        self.assertFalse(0.2 in m)
        self.assertTrue("Pepa" in m)
        self.assertFalse("Jiri" in m)

    def test_prunik(self):
        m1 = Mnozina()
        m1.vloz("Pepa")
        m1.vloz(1)
        m1.vloz(None)

        m2 = Mnozina()
        m2.vloz(1)
        m2.vloz(2)
        m2.vloz(3)

        prunik = m1.prunik(m2)
        self.assertEqual(len(prunik), 1)
        self.assertTrue(1 in prunik)

        prunikSpravnyVysledek = Mnozina()
        prunikSpravnyVysledek.vloz(1)
        self.assertEqual(prunik, prunikSpravnyVysledek)


    def test_sjednoceni(self):
        m1 = Mnozina()
        m1.vloz("Pepa")
        m1.vloz(1)
        m1.vloz(None)

        m2 = Mnozina()
        m2.vloz(1)
        m2.vloz(2)
        m2.vloz(3)

        sjednoceni = m1.sjednoceni(m2)
        self.assertEqual(len(sjednoceni), 5)
        self.assertTrue(1 in sjednoceni)
        self.assertTrue(2 in sjednoceni)
        self.assertTrue(3 in sjednoceni)
        self.assertTrue(None in sjednoceni)
        self.assertTrue("Pepa" in sjednoceni)

        sjednoceniSpravnyVysledek = Mnozina()
        sjednoceniSpravnyVysledek.vloz(1)
        sjednoceniSpravnyVysledek.vloz(2)
        sjednoceniSpravnyVysledek.vloz(3)
        sjednoceniSpravnyVysledek.vloz(None)
        sjednoceniSpravnyVysledek.vloz("Pepa")
        self.assertEqual(sjednoceni, sjednoceniSpravnyVysledek)

    def test_nevalidni_sjednoceni_a_prunik(self):
        m1 = Mnozina()
        m1.vloz("Pepa")
        m1.vloz(1)
        m1.vloz(None)

        with self.assertRaises(MnozinaException):
            m1.sjednoceni("1,2,3")

        with self.assertRaises(MnozinaException):
            m1.prunik("1,2,3")

    def test_sjednoceni_a_prunik_s_none(self):
        m = Mnozina()
        m.vloz("Pepa")
        m.vloz(1)
        m.vloz(None)

        sjednoceni = m.sjednoceni(None)
        self.assertEqual(len(sjednoceni), len(m))
        self.assertEqual(sjednoceni,m)

        prunik = m.prunik(None)
        self.assertEqual(len(prunik), len(m))
        self.assertEqual(prunik, m)

if __name__ == '__main__':
    unittest.main()