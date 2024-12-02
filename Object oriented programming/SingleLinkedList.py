class Node:
    def __init__(self, data):
        self.data = data
        self.next = None

class LinkedList:
    def __init__(self):
        self.head = None

    def append(self, data):
        new_node = Node(data)
        if self.head is None:
            self.head = new_node
        else:
            last = self.head
            while last.next:
                last = last.next
            last.next = new_node
    def __str__(self):
        elements = []
        current_node = self.head
        while current_node:
            elements.append(str(current_node.data))  # Přidání dat aktuálního uzlu do seznamu
            current_node = current_node.next
        return ' '.join(elements)

linked_list = LinkedList()

# Přidání alespoň 5 prvků
linked_list.append(10)
linked_list.append(20)
linked_list.append(30)
linked_list.append(40)
linked_list.append(50)

# Výpis všech prvků na obrazovku
print(linked_list)

import unittest
import time
import random


class TestLinkedList(unittest.TestCase):
    def setUp(self):
        self.linked_list = LinkedList()

    def test_append_and_assertIn(self):
        # Přidání prvků do seznamu
        self.linked_list.append(10)
        self.linked_list.append(20)

        # Ověření, že prvky jsou v seznamu
        current = self.linked_list.head
        elements = []
        while current:
            elements.append(current.data)
            current = current.next

        self.assertIn(10, elements)
        self.assertIn(20, elements)
        self.assertNotIn(30, elements)

    def test_count_value_efficiency(self):
        # Naplnění seznamu 1 milionem náhodných hodnot
        for _ in range(1_000_000):
            self.linked_list.append(random.randint(1, 999))

        # Přidání několika hodnot 186
        for _ in range(10):
            self.linked_list.append(186)

        # Počítání výskytů hodnoty 186
        start_time = time.time()
        count = 0
        current = self.linked_list.head
        while current:
            if current.data == 186:
                count += 1
            current = current.next
        end_time = time.time()

        elapsed_time = (end_time - start_time) * 1000  # Převod na milisekundy
        print(f"Elapsed time: {elapsed_time:.2f} ms")

        # Ověření, že program běží do 500 ms
        self.assertLess(elapsed_time, 500)
        self.assertEqual(count, 10)  # Ověření správného počtu hodnot 186


if __name__ == "__main__":
    unittest.main()
