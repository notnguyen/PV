using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVDatabaseProject
{
    internal class Payment
    {
        public Payment() { }
        public Payment(int orderID, int amount, string paymentDate)
        {
            OrderID = orderID;
            Amount = amount;
            PaymentDate = paymentDate;
        }

        public int PayemntId { get; set; }
        public int OrderID { get; set; }
        public int Amount { get; set; }
        public string PaymentDate { get; set; }

        public override string? ToString()
        {
            return $"Payment ID: {PayemntId}, Order ID: {OrderID}, Amount: {Amount:C}, Payment Date: {PaymentDate}";
        }

    }
}
