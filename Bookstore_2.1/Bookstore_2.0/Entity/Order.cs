using Bookstore_2._0.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_2._0.Entity
{
    public class Order : IBaseClass
    {
        private int id;
        private int customerID;
        private int supplierID;
        private int addressID;
        private DateTime orderDate;
        private double totalPrice;
        private int totalAmount;
        private bool isShipped;

        public int ID { get => id; set => id = value; }
        public int CustomerID { get => customerID; set => customerID = value; }
        public int SupplierID { get => supplierID; set => supplierID = value; }
        public int AddressID { get => addressID; set => addressID = value; }
        public DateTime OrderDate { get => orderDate; set => orderDate = value; }
        public double TotalPrice { get => totalPrice; set => totalPrice = value; }
        public int TotalAmount { get => totalAmount; set => totalAmount = value; }
        public bool IsShipped { get => isShipped; set => isShipped=value; }

        public Order()
        {
        }

        public Order(int id, int customerID, int supplierID, int addressID, DateTime orderDate, double totalPrice, int totalAmount, bool isShipped)
        {
            ID = id;
            CustomerID = customerID;
            SupplierID = supplierID;
            AddressID = addressID;
            OrderDate = orderDate;
            TotalPrice = totalPrice;
            TotalAmount = totalAmount;
            IsShipped = isShipped;
        }

        public Order(int customerID, int supplierID, int addressID, DateTime orderDate, double totalPrice, int totalAmount, bool isShipped)
        {
            ID = 0;
            CustomerID = customerID;
            SupplierID = supplierID;
            AddressID = addressID;
            OrderDate = orderDate;
            TotalPrice = totalPrice;
            TotalAmount = totalAmount;
            IsShipped = isShipped;
        }

        public override string ToString()
        {
            return $"Order: {ID}, CustomerID: {CustomerID}, SupplierID: {SupplierID}, AddressID: {AddressID}, OrderDate: {OrderDate}, TotalPrice: {TotalPrice}, TotalAmount: {TotalAmount}, IsShipped: {IsShipped}";
        }
    }
}
