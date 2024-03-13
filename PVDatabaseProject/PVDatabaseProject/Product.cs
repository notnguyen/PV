using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVDatabaseProject
{
    internal class Product
    {
        public Product() { }
        public Product(string name, int price, bool isAvailable)
        {
            Name = name;
            Price = price;
            IsAvailable = isAvailable;
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsAvailable { get; set; }

        public override string? ToString()
        {
            return $"Product ID: {ProductId}, Name: {Name}, Price: {Price}, Available: {(IsAvailable ? "Yes" : "No")}";
        }
    }
}
