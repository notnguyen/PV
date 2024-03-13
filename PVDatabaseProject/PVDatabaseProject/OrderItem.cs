using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVDatabaseProject
{
    internal class OrderItem
    {
        public OrderItem() { }
        public OrderItem(int orderId, int productId, int quantity, decimal pricePerItem)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            PricePerItem = pricePerItem;
        }

        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerItem { get; set; }

        public override string? ToString()
        {
            return $"Order Item ID: {OrderItemId}, Order ID: {OrderId}, Product ID: {ProductId}, Quantity: {Quantity}, Price Per Item: {PricePerItem:C}";
        }

    }
}
