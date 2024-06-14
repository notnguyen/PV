using Bookstore_2._0.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bookstore_2._0.Entity
{
    public class Address : IBaseClass
    {
        private int id;
        private string street;
        private int houseNumber;
        private string city;
        private string postalCode;
        private string state;

        public int ID { get => id; set => id = value; }
        public string Street { get => street; set => street = value; }
        public int HouseNumber { get => houseNumber; set => houseNumber = value; }
        public string City { get => city; set => city = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
        public string State { get => state; set => state=value; }

        public Address()
        {
        }

        public Address(int id, string street, int houseNumber, string city, string postalCode, string state)
        {
            ID = id;
            Street = street;
            HouseNumber = houseNumber;
            City = city;
            PostalCode = postalCode;
            State = state;
        }

        public Address(string street, int houseNumber, string city, string postalCode, string state)
        {
            ID = 0;
            Street = street;
            HouseNumber = houseNumber;
            City = city;
            PostalCode = postalCode;
            State = state;
        }

        public override string ToString()
        {
            return $"Address: {ID}, Street: {Street}, HouseNumber: {HouseNumber}, City: {City}, PostalCode: {PostalCode}, State: {State}";
        }
    }
}
