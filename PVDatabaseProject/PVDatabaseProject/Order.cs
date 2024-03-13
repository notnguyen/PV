using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVDatabaseProject
{
    internal class Order
    {
        public Order() { }
        public Order( int customerId, string orderDate, Decimal totalPrice)
        {
            CustomerId = customerId;
            OrderDate = orderDate;
            TotalPrice = totalPrice;
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string OrderDate { get; set; }
        public Decimal TotalPrice { get; set; }

        public override string? ToString()
        {
            return $"Order ID: {OrderId}, Customer ID: {CustomerId}, Order Date: {OrderDate}, Total Price: {TotalPrice:C}";
        }

    }
}
