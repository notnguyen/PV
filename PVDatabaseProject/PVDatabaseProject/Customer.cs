using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVDatabaseProject
{
    internal class Customer
    {   
        public Customer() { }
        public Customer(string customerName, string customerSecondName, string mobileNumber, string registrationDate) 
        {
            CustomerName = customerName; 
            CustomerSecondName = customerSecondName;
            MobileNumber = mobileNumber;
            RegistrationDate = registrationDate;
        }
        

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSecondName { get; set; }
        public string MobileNumber { get; set;}
        public string RegistrationDate { get; set; }

        public override string? ToString()
        {
            return $"Customer ID: {CustomerId}, Name: {CustomerName}, Second Name: {CustomerSecondName}, Mobile Number: {MobileNumber}, Registration Date: {RegistrationDate}";
        }
    }
}
