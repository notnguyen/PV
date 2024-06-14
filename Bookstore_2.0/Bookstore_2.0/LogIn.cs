using Bookstore_2._0.DAO;
using Bookstore_2._0.Entity;
using System;
using System.IO;

namespace Bookstore_2._0
{
    public class LogIn
    {
        public void LogInCustomer()
        {
            var customerDao = new CustomerDAO();
            Customer? loggedInCustomer = null;
            int attempts = 0;
            const int maxAttempts = 5;

            while (loggedInCustomer == null && attempts < maxAttempts)
            {
                Console.WriteLine();
                Console.WriteLine("Zadejte přezdívku:");
                string userName = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine("Zadejte heslo:");
                string password = Console.ReadLine();

                loggedInCustomer = customerDao.Login(userName, password);

                if (loggedInCustomer != null)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Přihlášení úspěšné. Vítejte, {loggedInCustomer.FirstName} {loggedInCustomer.LastName}");
                    return;
                }
                else
                {
                    attempts++;
                    Console.WriteLine();
                    Console.WriteLine($"Neplatné přihlašovací jméno nebo heslo. Zkuste to prosím znovu. Pokus {attempts} z 5.");
                }
            }

            if (attempts >= maxAttempts)
            {
                Console.WriteLine();
                Console.WriteLine("Překročili jste maximální počet pokusů. Vracíme se zpět do hlavní nabídky.");
            }
        }

        public Customer? LoginFromFile(string userName, string password)
        {
            string filePath = "C:\\Users\\kingh\\source\\repos\\Bookstore_2.0\\Bookstore_2.0\\Customers.txt";
            int attempts = 0;
            const int maxAttempts = 5;

            while (attempts < maxAttempts)
            {
                try
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] parts = line.Split(',');
                            if (parts.Length >= 6)
                            {
                                string storedUserName = parts[2].Trim();
                                string storedPassword = parts[3].Trim();

                                if (storedUserName.Equals(userName) && storedPassword.Equals(password))
                                {
                                    Customer customer = new Customer
                                    {
                                        FirstName = parts[0].Trim(),
                                        LastName = parts[1].Trim(),
                                        UserName = storedUserName,
                                        Password = storedPassword,
                                        Email = parts[4].Trim(),
                                        PhoneNumber = parts[5].Trim()
                                    };
                                    Console.WriteLine($"Přihlášení úspěšné z textového souboru. Vítejte, {customer.FirstName} {customer.LastName}");
                                    return customer;
                                }
                            }
                        }
                    }
                    attempts++;
                    Console.WriteLine($"Neplatné přihlašovací jméno nebo heslo z textového souboru. Zkuste to prosím znovu. Pokus {attempts} z 5.");
                }
                catch (IOException e)
                {
                    Console.WriteLine($"Error reading file: {e.Message}");
                    break;
                }

                if (attempts < maxAttempts)
                {
                    Console.WriteLine();
                    Console.WriteLine("Zadejte přezdívku:");
                    userName = Console.ReadLine();

                    Console.WriteLine();
                    Console.WriteLine("Zadejte heslo:");
                    password = Console.ReadLine();
                }
            }

            if (attempts >= maxAttempts)
            {
                Console.WriteLine();
                Console.WriteLine("Překročili jste maximální počet pokusů při přihlašování z textového souboru. Vracíme se zpět do hlavní nabídky.");
            }

            return null;
        }
    }
}
