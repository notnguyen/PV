using Bookstore_2._0.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bookstore_2._0.Entity
{
    public class Customer : IBaseClass
    {
        private int id;
        private string userName;
        private string password;
        private string firstName;
        private string lastName;
        private string email;
        private string phoneNumber;

        public int ID { get => id; set => id = value; }
        public string UserName { get => userName; set
        {
            while (!System.Text.RegularExpressions.Regex.IsMatch(value, "^[^\\s]+$"))
            {
                Console.WriteLine();
                Console.WriteLine("!!! Špatně zadané uživatelské jméno !!!");
                Console.WriteLine("Ujistete se, ze uživatelské jméno neobsahuje mezery");
                Console.WriteLine();
                Console.WriteLine("Zadejte uživatelské jméno:");
                value = Console.ReadLine();
            }
                userName = value;
        } }
        public string Password { get => password; set => password=value; }
        public string FirstName { get => firstName; set
            {
                while (!System.Text.RegularExpressions.Regex.IsMatch(value, "^[A-Z][a-zA-Z]*$"))
                {
                    Console.WriteLine();
                    Console.WriteLine("!!! Špatně zadané jméno !!!");
                    Console.WriteLine("Ujistěte se, že jméno začíná velkým písmenem");
                    Console.WriteLine();
                    Console.WriteLine("Zadejte jméno:");
                    value = Console.ReadLine();
                }
                firstName = value;
            }
        }
        public string LastName { get => lastName; set
            {
                while (!System.Text.RegularExpressions.Regex.IsMatch(value, "^[A-Z][a-zA-Z]*$"))
                {
                    Console.WriteLine();
                    Console.WriteLine("!!! Špatně zadané příjmení !!!");
                    Console.WriteLine("Ujistěte se, že příjmení začíná velkým písmenem");
                    Console.WriteLine();
                    Console.WriteLine("Zadejte příjmení:");
                    value = Console.ReadLine();
                }
                lastName = value;
            }
        }
        public string Email
        {
            get => email;
            set
            {
                while (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                {
                    Console.WriteLine();
                    Console.WriteLine("!!! Špatně zadaný e-mail !!!");
                    Console.WriteLine("Ujistěte se, že e-mail má správný formát (např. example@example.com)");
                    Console.WriteLine();
                    Console.WriteLine("Zadejte e-mail:");
                    value = Console.ReadLine();
                }
                email = value;
            }
        }

        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                while (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^\+?[\d\s]{3,}$"))
                {
                    Console.WriteLine();
                    Console.WriteLine("!!! Špatně zadané telefonní číslo !!!");
                    Console.WriteLine("Ujistěte se, že telefonní číslo obsahuje pouze číslice a může obsahovat mezeru nebo znak + na začátku");
                    Console.WriteLine();
                    Console.WriteLine("Zadejte telefonní číslo:");
                    value = Console.ReadLine();
                }
                phoneNumber = value;
            }
        }

        public Customer()
        {
        }

        public Customer(int id, string userName, string password, string firstName, string lastName, string email, string phoneNumber)
        {
            ID = id;
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public Customer(string userName, string password, string firstName, string lastName, string email, string phoneNumber)
        {
            ID = 0;
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"Customer: {ID}, UserName: {UserName}, Password: {Password}, FirstName: {FirstName}, LastName: {LastName}, Email: {Email}, PhoneNumber: {PhoneNumber}";
        }
    }
}
