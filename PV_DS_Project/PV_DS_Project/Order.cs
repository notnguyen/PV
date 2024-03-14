using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_DS_Project
{
    internal class Order
    {
        private int id;
        private int customerID;
        private int supplierID;
        private DateTime orderDate;
        private Decimal totalPrice;
        private string shippingAddress;
        private bool isCompleted;
        private float totalAmount;

        public int ID { get => id; set => id = value; }
        public int CustomerID { get => customerID; set => customerID = value; }
        public int SupplierID { get => supplierID; set => supplierID = value; }
        public DateTime OrderDate { get => orderDate; set => orderDate = value; }
        public decimal TotalPrice { get => totalPrice; set => totalPrice = value; }
        public string ShippingAddress { get => shippingAddress; set => shippingAddress = value; }
        public bool IsCompleted { get => isCompleted; set => isCompleted = value; }
        public float TotalAmount { get => totalAmount; set => totalAmount = value; }

        public Order(int id, int customerID, int supplierID, DateTime orderDate, Decimal totalPrice, string shippingAddress, bool isCompleted, float totalAmount)
        {
            this.ID = id;
            this.CustomerID = customerID;
            this.SupplierID = supplierID;
            this.OrderDate = orderDate;
            this.TotalPrice = totalPrice;
            this.ShippingAddress = shippingAddress;
            this.IsCompleted = isCompleted;
            this.TotalAmount = totalAmount;
        }

        public Order(int customerID, int supplierID, DateTime orderDate, Decimal totalPrice, string shippingAddress, bool isCompleted, float totalAmount)
        {
            this.ID = 0;
            this.CustomerID = customerID;
            this.SupplierID = supplierID;
            this.OrderDate = orderDate;
            this.TotalPrice = totalPrice;
            this.ShippingAddress = shippingAddress;
            this.IsCompleted = isCompleted;
            this.TotalAmount = totalAmount;
        }

        public Order() { }

        public override string ToString()
        {
            return $"Order ID: {ID}, Customer ID: {CustomerID}, Supplier ID: {SupplierID}, Order Date: {OrderDate}, Total Price: {TotalPrice}, Shipping Address: {ShippingAddress}, Is Completed : {IsCompleted}, Total Amount: {TotalAmount}";
        }
    }
}

