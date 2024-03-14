using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_DS_Project
{
    internal class Customer
    {
        private int id;
        private string firstName;
        private string lastName;
        private string address;
        private string phoneNumber;

        public int ID { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Address { get => address; set => address = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }

        public Customer(int id, string firstName, string lastName, string address, string phoneNumber)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
        }

        public Customer( string firstName, string lastName, string address, string phoneNumber)
        {
            this.ID = 0;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
        }

        public Customer() { }

        public override string ToString()
        {
            return $"Customer ID: {ID}, First Name: {FirstName}, Last Name: {LastName}, Address: {Address}, Phone Number: {PhoneNumber}";
        }
    }
}
