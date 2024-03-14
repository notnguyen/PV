using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_DS_Project
{
    internal class Item
    {
        private int id;
        private string name;
        private Decimal price;
        private bool isAvailable;
        private int stock;
        private string description;

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public decimal Price { get => price; set => price = value; }
        public bool IsAvailable { get => isAvailable; set => isAvailable = value; }
        public int Stock { get => stock; set => stock = value; }
        public string Description { get => description; set => description = value; }

        public Item(int id, string name, Decimal price, bool isAvailable, int stock, string description)
        {
            this.ID = id;
            this.Name = name;
            this.Price = price;
            this.IsAvailable = isAvailable;
            this.Stock = stock;
            this.Description = description;
        }

        public Item(string name, Decimal price, bool isAvailable, int stock, string description)
        {
            this.ID = 0;
            this.Name = name;
            this.Price = price;
            this.IsAvailable = isAvailable;
            this.Stock = stock;
            this.Description = description;
        }

        public Item() { }

        public override string ToString()
        {
            return $"Item ID: {ID}, Name: {Name}, Price: {Price}, Is Available: {isAvailable}, Stock: {Stock}, Description: {Description}";
        }
    }
}
