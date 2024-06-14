using Bookstore_2._0.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_2._0.Entity
{
    public class Supplier : IBaseClass
    {
        private int id;
        private string firstName;
        private string lastName;
        private string email;
        private string phoneNumber;

        public int ID { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber=value; }

        public Supplier()
        {
        }

        public Supplier(int id, string firstName, string lastName, string email, string phoneNumber)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public Supplier(string firstName, string lastName, string email, string phoneNumber)
        {
            ID = 0;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"Supplier: {ID}, FirstName: {FirstName}, LastName: {LastName}, Email: {Email}, PhoneNumber: {PhoneNumber}";
        }
    }
}
