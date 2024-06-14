using Bookstore_2._0.DAO;
using Bookstore_2._0.Entity;
using System;
using System.IO;

namespace Bookstore_2._0
{
    public class SignUp
    {
        public void SignUpCustomer()
        {
            var newCustomer = new Customer();
            bool passwordsMatch = false;
            int attempts = 0;

            Console.WriteLine();
            Console.WriteLine("Zadejte jméno:");
            string firstName = Console.ReadLine();
            newCustomer.FirstName = firstName;

            Console.WriteLine();
            Console.WriteLine("Zadejte příjmení:");
            string lastName = Console.ReadLine();
            newCustomer.LastName = lastName;

            Console.WriteLine();
            Console.WriteLine("Zadejte přezdívku:");
            string userName = Console.ReadLine();
            newCustomer.UserName = userName;

            Console.WriteLine();
            Console.WriteLine("Zadejte e-mail:");
            string email = Console.ReadLine();
            newCustomer.Email = email;

            Console.WriteLine();
            Console.WriteLine("Zadejte telefonní číslo:");
            string phoneNumber = Console.ReadLine();
            newCustomer.PhoneNumber = phoneNumber;

            while (!passwordsMatch)
            {
                Console.WriteLine();
                Console.WriteLine("Zadejte heslo:");
                string password = Console.ReadLine();
                newCustomer.Password = password;

                attempts = 0;

                while (attempts < 5)
                {
                    Console.WriteLine();
                    Console.WriteLine("Zadejte heslo znovu pro ověření:");
                    string checkPassword = Console.ReadLine();

                    if (checkPassword.Equals(password))
                    {
                        passwordsMatch = true;
                        break;
                    }
                    else
                    {
                        attempts++;
                        Console.WriteLine();
                        Console.WriteLine("!!! Hesla se neshodují !!!");
                        if (attempts < 5)
                        {
                            Console.WriteLine($"Zkuste to prosím znovu. Pokus {attempts} z 5.");
                        }
                    }
                }

                if (attempts == 5)
                {
                    Console.WriteLine();
                    Console.WriteLine("Překročili jste maximální počet pokusů. Začněte prosím znovu zadávat heslo.");
                }
            }

            var customerDao = new CustomerDAO();
            customerDao.Add(newCustomer);


            string filePath = "C:\\Users\\nguyen4\\Downloads\\Bookstore_2.0\\Bookstore_2.0\\Customers.txt";
            SaveCustomer(filePath, newCustomer);

            Console.WriteLine();
            Console.WriteLine("Registrace úspěšná.");
            Console.WriteLine();
        }

        public static void SaveCustomer(string filename, Customer customer)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename, true))
                {
                    writer.WriteLine($"{customer.FirstName}, {customer.LastName}, {customer.UserName}, {customer.Password}, {customer.Email}, {customer.PhoneNumber}");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
