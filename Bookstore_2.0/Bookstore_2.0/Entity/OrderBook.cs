using Bookstore_2._0.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_2._0.Entity
{
    public class OrderBook : IBaseClass
    {
        private int id;
        private int bookID;
        private int orderID;
        private int amount;
        private double price;

        public int ID { get => id; set => id = value; }
        public int BookID { get => bookID; set => bookID = value; }
        public int OrderID { get => orderID; set => orderID = value; }
        public int Amount { get => amount; set => amount = value; }
        public double Price { get => price; set => price=value; }

        public OrderBook()
        {
        }

        public OrderBook(int id, int bookID, int orderID, int amount, double price)
        {
            ID = id;
            BookID = bookID;
            OrderID = orderID;
            Amount = amount;
            Price = price;
        }

        public OrderBook(int bookID, int orderID, int amount, double price)
        {
            ID = 0;
            BookID = bookID;
            OrderID = orderID;
            Amount = amount;
            Price = price;
        }

        public override string ToString()
        {
            return $"OrderBook: {ID}, BookID: {BookID}, OrderID: {OrderID}, Amount: {Amount}, Price: {Price}";
        }
    }
}
