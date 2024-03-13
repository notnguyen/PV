using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVDatabaseProject
{
    internal class Menu
    {
        CustomerDAO customerDAO;
        ProductDao productDAO;
        OrderDao orderDAO;
        OrderItemDao orderItemDAO;
        PaymentDao paymentDAO;

        public Menu()
        {
            customerDAO = new CustomerDAO();
            productDAO = new ProductDao();
            orderDAO = new OrderDao();
            orderItemDAO = new OrderItemDao();
            paymentDAO = new PaymentDao();
        }
        public void ShowMenu()
        {
            Console.WriteLine("Choose item to edit:");
            Console.WriteLine("1. Customer");
            Console.WriteLine("2. Product");
            Console.WriteLine("3. Order");
            Console.WriteLine("4. OrderItem");
            Console.WriteLine("5. Payment");
            Console.WriteLine("6. Exit");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("Selected option: Customer");
                    break;
                case "2":
                    Console.WriteLine("Selected option: Product");
                    break;
                case "3":
                    Console.WriteLine("Selected option: Order");
                    break;
                case "4":
                    Console.WriteLine("Selected option: OrderItem");
                    break;
                case "5":
                    Console.WriteLine("Selected option: Payment");
                    break;
                case "6":
                    Console.WriteLine("Program will be terminated.");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    ShowMenu();
                    break;
            }

            Console.WriteLine("Select action:");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Remove");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. GetAll");
            Console.WriteLine("5. Exit");

            string input2 = Console.ReadLine();

            switch (input2)
            {
                case "1":
                    Console.WriteLine("Selected action: Add");

                    switch (input)
                    {
                        case "1":
                            customerDAO.Add((Customer)CreateEntity("1"));
                            break;
                        case "2":
                            productDAO.Add((Product)CreateEntity("2"));
                            break;
                        case "3":
                            orderDAO.Add((Order)CreateEntity("3"));
                            break;
                        case "4":
                            orderItemDAO.Add((OrderItem)CreateEntity("4"));
                            break;
                        case "5":
                            paymentDAO.Add((Payment)CreateEntity("5"));
                            break;
                    }
                    break;
                case "2":
                    switch (input)
                    {
                        case "1":
                            customerDAO.Delete(Convert.ToInt32(input));
                            break;
                        case "2":
                            productDAO.Delete(Convert.ToInt32(input));
                            break;
                        case "3":
                            orderDAO.Delete(Convert.ToInt32(input));
                            break;
                        case "4":
                            orderItemDAO.Delete(Convert.ToInt32(input));
                            break;
                        case "5":
                            paymentDAO.Delete(Convert.ToInt32(input));
                            break;
                    }
                    break;
                case "3":
                    Console.WriteLine("Selected action: Update");
                    break;
                case "4":
                    switch (input)
                    {
                        case "1":
                            PrintOut(customerDAO.GetAll());
                            break;
                        case "2":
                            PrintOut(productDAO.GetAll());
                            break;
                        case "3":
                            PrintOut(orderDAO.GetAll());
                            break;
                        case "4":
                            PrintOut(orderItemDAO.GetAll());
                            break;
                        case "5":
                            PrintOut(paymentDAO.GetAll());
                            break;
                    }
                    break;
                case "5":
                    Console.WriteLine("Program will be terminated.");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    ShowMenu();
                    break;
            }

            ShowMenu();
        }
        static void PrintOut(IEnumerable<Object> Ie)
        {
            foreach (var entity in Ie)
            {
                Console.WriteLine(entity);
            }
        }
        static Object CreateEntity(string input)
        {
            switch (input)
            {
                case "1":
                    Console.WriteLine("enter the information in this format: first name, second name, mobile number, registration date");
                    break;
                case "2":
                    Console.WriteLine("enter the information in this format: name, price, is avaliable(true/false)");
                    break;
                case "3":
                    Console.WriteLine("enter the information in this format: customer id , order date, total price");
                    break;
                case "4":
                    Console.WriteLine("enter the information in this format: order id , product id, quantity, price per item");
                    break;
                case "5":
                    Console.WriteLine("enter the information in this format: order id , amount, payment date");
                    break;
            }

            string userInput = Console.ReadLine();

            string[] atributs = userInput.Split(",");

            switch (input)
            {
                case "1":
                    return new Customer(atributs[0], atributs[1], atributs[2], atributs[3]);
                    break;
                case "2":
                    return new Product(atributs[0], Convert.ToInt32(atributs[1]), Convert.ToBoolean(atributs[2]));
                    break;
                case "3":
                    return new Order(Convert.ToInt32(atributs[0]), atributs[1], Convert.ToDecimal(atributs[2]));
                    break;
                case "4":
                    return new OrderItem(Convert.ToInt32(atributs[0]), Convert.ToInt32(atributs[1]), Convert.ToInt32(atributs[2]), Convert.ToDecimal(atributs[3]));
                    break;
                case "5":
                    return new Payment(Convert.ToInt32(atributs[0]), Convert.ToInt32(atributs[1]), atributs[2]);
                    break;
            }
            return null;

        }

    }
}
