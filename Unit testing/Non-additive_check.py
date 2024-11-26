def scitani(a, b):
    if a == None or b == None:
        raise TypeError("a and b cannot be None")
    if isinstance(a, list) and isinstance(b, list):
        raise TypeError("a and b cannot be a list")
    if type(a) not in [int, float] or type(b) not in [int, float]:
        raise ValueError("a must be an integer or float")
    return a + b



import unittest
class TestNescitani(unittest.TestCase):

    def test_bad_input(self):
        with self.assertRaises(ValueError):
            scitani("AHOJ", 100)
        with self.assertRaises(ValueError):
            scitani(100, "AHOJ")
        with self.assertRaises(TypeError):
            scitani(None, None)
        with self.assertRaises(TypeError):
            scitani([4, 5, 6], [1, 2, 3])

if __name__ == '__main__':
    unittest.main()