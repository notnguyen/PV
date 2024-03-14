using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_DS_Project
{
    internal class OrderItem
    {
        private int id;
        private int itemID;
        private int orderID;
        private int amount;
        private Decimal price;

        public int ID { get => id; set => id = value; }
        public int ItemID { get => itemID; set => itemID = value; }
        public int OrderID { get => orderID; set => orderID = value; }
        public int Amount { get => amount; set => amount = value; }
        public decimal Price { get => price; set => price = value; }

        public OrderItem(int id, int itemID, int orderID, int amount, Decimal price )
        {
            this.ID = id;
            this.ItemID = itemID;
            this.OrderID = orderID;
            this.Amount = amount;
            this.Price = price;
        }

        public OrderItem(int itemID, int orderID, int amount, Decimal price)
        {
            this.ID = 0;
            this.ItemID = itemID;
            this.OrderID = orderID;
            this.Amount = amount;
            this.Price = price;
        }

        public OrderItem() { }

        public override string ToString()
        {
            return $"OrderItem ID: {ID}, Item ID: {itemID}, Order ID: {orderID}, Amount: {amount}, Price: {price}";
        }
    }
}
