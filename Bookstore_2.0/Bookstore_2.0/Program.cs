using Bookstore_2._0.DAO;
using Bookstore_2._0.Entity;

namespace Bookstore_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*SignUp signUp = new SignUp();
            Customer customer = new Customer();

            LogIn log = new LogIn();
            Console.WriteLine();
            Console.WriteLine("Zadejte přezdívku:");
            string userName = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Zadejte heslo:");
            string password = Console.ReadLine();
            log.LoginFromFile(userName, password);

            signUp.SignUpCustomer();

            Console.WriteLine("Seznam uživatelů:");
            foreach (var user in Customer.customers)
            {
                Console.WriteLine($"Jméno: {customer.FirstName}");
                Console.WriteLine($"Příjmení: {customer.LastName}");
                Console.WriteLine($"Přezdívka: {customer.UserName}");
                Console.WriteLine($"Heslo: {customer.Password}");
                Console.WriteLine($"E-mail: {customer.Email}");
                Console.WriteLine($"Telefonní číslo: {customer.PhoneNumber}");
                Console.WriteLine();
            }*/

            SignUp signUp = new SignUp();
            LogIn logIn = new LogIn();

            while (true)
            {
                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Log In");
                Console.WriteLine("Choose:");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        signUp.SignUpCustomer();
                        UI.Start();
                        break;

                    case "2":
                        Console.WriteLine();
                        Console.WriteLine("Zadejte přezdívku:");
                        string userName = Console.ReadLine();

                        Console.WriteLine();
                        Console.WriteLine("Zadejte heslo:");
                        string password = Console.ReadLine();

                        logIn.LoginFromFile(userName, password);
                        UI.Start();
                        break;

                    default:
                        Console.WriteLine("Not a valid option");
                        break;
                }
            }
        



        


        }
    }
}
