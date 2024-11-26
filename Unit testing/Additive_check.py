def scitani(a, b):
    return a + b

import unittest
class TestScitani(unittest.TestCase):
    def testinteger(self):
        self.assertEqual(scitani(1, 1), 2)
        self.assertEqual(scitani(-1, 1), 0)
        self.assertEqual(scitani(1, -1), 0)
        self.assertEqual(scitani(2, 3), 5)

    def testnumber(self):
        self.assertEqual(scitani(1.5, 0.5), 2)
        self.assertEqual(scitani(-1.5, 1.5), 0)
        self.assertEqual(scitani(2.3, -0.4), 1.9)

    def testcomplex(self):
        self.assertEqual(scitani(complex(5, 1), complex(5, 4)), 10+5j)

    def test(self):
        x = 0.0
        for i in range(3):
            x = scitani(x, 0.1)
        self.assertAlmostEqual(x, 0.3)

if __name__ == '__main__':
    unittest.main()