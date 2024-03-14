using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_DS_Project
{
    internal class Supplier
    {
        private int id;
        private string firstName;
        private string lastName;
        private string contactEmail;
        private string phoneNumber;

        public int ID { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string ContactEmail { get => contactEmail; set => contactEmail = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }

        public Supplier(int id, string firstName, string lastName, string contactEmail, string phoneNumber)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ContactEmail = contactEmail;
            this.PhoneNumber = phoneNumber;
        }

        public Supplier(string firstName, string lastName, string contactEmail, string phoneNumber)
        {
            this.ID = 0;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ContactEmail = contactEmail;
            this.PhoneNumber = phoneNumber;
        }

        public Supplier() { }

        public override string ToString()
        {
            return $"Supplier ID: {ID}, First Name: {FirstName}, Last Name: {LastName}, Contact Email: {ContactEmail}, Phone Number: {PhoneNumber}";
        }
    }
}
