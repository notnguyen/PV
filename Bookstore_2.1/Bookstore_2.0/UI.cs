using Bookstore_2._0.DAO;
using Bookstore_2._0.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_2._0
{
    public class UI
    {
        public static void Start()
        {
            var menu = new Menu();
            var bookDAO = new BookDAO();
            var customerDAO = new CustomerDAO();
            var orderDAO = new OrderDAO();
            var orderBookDAO = new OrderBookDAO();
            var addressDAO = new AddressDAO();
            var supplierDAO = new SupplierDAO();

            do
            {
                menu.PrintRoleMenu();
                Console.WriteLine("Choose:");
                string inputRole = Console.ReadLine();

                switch (inputRole)
                {
                    case "1":

                                menu.PrintMainMenu();
                        Console.WriteLine("Choose:");
                        string input = Console.ReadLine();

                        switch (input)
                        {
                            case "1":
                                menu.PrintAddMenu();
                                Console.WriteLine("Choose:");
                                string inputAdd = Console.ReadLine();

                                switch (inputAdd)
                                {
                                    case "1":

                                        var order = new Order();

                                        foreach (var c in customerDAO.GetAll())
                                        {
                                            Console.WriteLine(c);
                                        }
                                        Console.WriteLine("Enter ID of Customer: ");
                                        order.CustomerID = Convert.ToInt32(Console.ReadLine());

                                        foreach (var s in supplierDAO.GetAll())
                                        {
                                            Console.WriteLine(s);
                                        }
                                        Console.WriteLine("Enter ID of Supplier: ");
                                        order.SupplierID = Convert.ToInt32(Console.ReadLine());

                                        foreach (var a in addressDAO.GetAll())
                                        {
                                            Console.WriteLine(a);
                                        }
                                        Console.WriteLine("Enter ID of Address: ");
                                        order.AddressID = Convert.ToInt32(Console.ReadLine());

                                        Console.WriteLine("Enter OrderDate (yyyy-MM-dd):");
                                        order.OrderDate = Convert.ToDateTime(Console.ReadLine());

                                        Console.WriteLine("Enter TotalPrice of Order: ");
                                        order.TotalPrice = Convert.ToDouble(Console.ReadLine());

                                        Console.WriteLine("Enter TotalAmount of Order: ");
                                        order.TotalAmount = Convert.ToInt32(Console.ReadLine());

                                        if (order.OrderDate > DateTime.Now)
                                        {
                                            order.IsShipped = false;
                                        }
                                        else
                                        {
                                            order.IsShipped = true;
                                        }

                                        orderDAO.Add(order);
                                        break;

                                    case "2":

                                        var orderBook = new OrderBook();

                                        foreach (var b in bookDAO.GetAll())
                                        {
                                            Console.WriteLine(b);
                                        }
                                        Console.WriteLine("Enter ID of Book: ");
                                        orderBook.BookID = Convert.ToInt32(Console.ReadLine());

                                        foreach (var o in orderDAO.GetAll())
                                        {
                                            Console.WriteLine(o);
                                        }
                                        Console.WriteLine("Enter ID of Order: ");
                                        orderBook.OrderID = Convert.ToInt32(Console.ReadLine());

                                        Console.WriteLine("Enter Amount of OrderBook: ");
                                        orderBook.Amount = Convert.ToInt32(Console.ReadLine());

                                        Console.WriteLine("Enter Price of OrderBook: ");
                                        orderBook.Price = Convert.ToDouble(Console.ReadLine());

                                        orderBookDAO.Add(orderBook);
                                        break;

                                    case "3":

                                        var address = new Address();

                                        Console.WriteLine("Enter Street of Address: ");
                                        address.Street = Console.ReadLine();

                                        Console.WriteLine("Enter HouseNumber of Address: ");
                                        address.HouseNumber = Convert.ToInt32(Console.ReadLine());

                                        Console.WriteLine("Enter City of Address: ");
                                        address.City = Console.ReadLine();

                                        Console.WriteLine("Enter PostalCode of Address: ");
                                        address.PostalCode = Console.ReadLine();

                                        Console.WriteLine("Enter State of Address: ");
                                        address.State = Console.ReadLine();

                                        addressDAO.Add(address);
                                        break;

                                    case "4":
                                        menu.PrintMainMenu();
                                        break;
                                    default:
                                        Console.WriteLine("Not a valid option");
                                        break;
                                }
                                break;
                            case "2":
                                menu.PrintUpdateMenu();
                                Console.WriteLine("Choose:");
                                string inputUpdate = Console.ReadLine();
                                // UPDATE options
                                switch (inputUpdate)
                                {
                                    case "1":

                                        foreach (var o in orderDAO.GetAll())
                                        {
                                            Console.WriteLine(o);
                                        }
                                        Console.WriteLine("Enter ID of Order to update:");

                                        if (int.TryParse(Console.ReadLine(), out var orderID))
                                        {
                                            Order orderUpdate = orderDAO.GetById(orderID);

                                            if (orderUpdate != null)
                                            {
                                                Console.WriteLine("Selected Order:");
                                                Console.WriteLine(orderUpdate);

                                                foreach (var c in customerDAO.GetAll())
                                                {
                                                    Console.WriteLine(c);
                                                }

                                                Console.WriteLine("Enter new Customer ID:");
                                                orderUpdate.CustomerID = Convert.ToInt32(Console.ReadLine());

                                                foreach (var s in supplierDAO.GetAll())
                                                {
                                                    Console.WriteLine(s);
                                                }

                                                Console.WriteLine("Enter new Supplier ID:");
                                                orderUpdate.SupplierID = Convert.ToInt32(Console.ReadLine());

                                                foreach (var a in addressDAO.GetAll())
                                                {
                                                    Console.WriteLine(a);
                                                }

                                                Console.WriteLine("Enter new Customer ID:");
                                                orderUpdate.AddressID = Convert.ToInt32(Console.ReadLine());

                                                Console.WriteLine("Enter new OrderDate (yyyy-MM-dd HH:mm:ss):");
                                                if (DateTime.TryParse(Console.ReadLine(), out DateTime newOrderDate))
                                                {
                                                    orderUpdate.OrderDate = newOrderDate;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid date format. Order date not updated.");
                                                }

                                                Console.WriteLine("Enter new TotalPrice:");
                                                if (double.TryParse(Console.ReadLine(), out double newPrice))
                                                {
                                                    orderUpdate.TotalPrice = newPrice;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid price. Product price will remain unchanged.");
                                                }

                                                Console.WriteLine("Enter TotalAmount: ");
                                                orderUpdate.TotalAmount = Convert.ToInt32(Console.ReadLine());

                                                Console.WriteLine("IsShipped? (true/false):");
                                                if (bool.TryParse(Console.ReadLine(), out bool isShipped))
                                                {
                                                    orderUpdate.IsShipped = isShipped;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid input. Order shipping status not updated.");
                                                }

                                                orderDAO.Update(orderUpdate);
                                            }
                                        }
                                        break;
                                    case "2":

                                        foreach (var o in orderBookDAO.GetAll())
                                        {
                                            Console.WriteLine(o);
                                        }
                                        Console.WriteLine("Enter ID of OrderBook to update:");

                                        if (int.TryParse(Console.ReadLine(), out var orderBookID))
                                        {
                                            OrderBook orderBookUpdate = orderBookDAO.GetById(orderBookID);

                                            if (orderBookUpdate != null)
                                            {
                                                Console.WriteLine("Selected OrderBook:");
                                                Console.WriteLine(orderBookUpdate);

                                                foreach (var b in bookDAO.GetAll())
                                                {
                                                    Console.WriteLine(b);
                                                }

                                                Console.WriteLine("Enter new Book ID:");
                                                orderBookUpdate.BookID = Convert.ToInt32(Console.ReadLine());

                                                foreach (var o in orderDAO.GetAll())
                                                {
                                                    Console.WriteLine(o);
                                                }

                                                Console.WriteLine("Enter new Order ID:");
                                                orderBookUpdate.OrderID = Convert.ToInt32(Console.ReadLine());

                                                Console.WriteLine("Enter Amount: ");
                                                orderBookUpdate.Amount = Convert.ToInt32(Console.ReadLine());

                                                Console.WriteLine("Enter new Price:");
                                                if (double.TryParse(Console.ReadLine(), out double newPrice))
                                                {
                                                    orderBookUpdate.Price = newPrice;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid price. Product price will remain unchanged.");
                                                }

                                                orderBookDAO.Update(orderBookUpdate);
                                            }
                                        }
                                        break;
                                    case "3":

                                        foreach (var a in addressDAO.GetAll())
                                        {
                                            Console.WriteLine(a);
                                        }
                                        Console.WriteLine("Enter ID of Address to update:");

                                        if (int.TryParse(Console.ReadLine(), out var addressID))
                                        {
                                            Address addressUpdate = addressDAO.GetById(addressID);

                                            if (addressUpdate != null)
                                            {
                                                Console.WriteLine("Selected Address:");
                                                Console.WriteLine(addressUpdate);

                                                Console.WriteLine("Enter Street:");
                                                string newStreet = Console.ReadLine();
                                                if (!string.IsNullOrEmpty(newStreet))
                                                {
                                                    addressUpdate.Street = newStreet;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid Street. Address Street will remain unchanged.");
                                                }

                                                Console.WriteLine("Enter HouseNumber: ");
                                                addressUpdate.HouseNumber = Convert.ToInt32(Console.ReadLine());

                                                Console.WriteLine("Enter City:");
                                                string newCity = Console.ReadLine();
                                                if (!string.IsNullOrEmpty(newCity))
                                                {
                                                    addressUpdate.City = newCity;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid City. Address City will remain unchanged.");
                                                }

                                                Console.WriteLine("Enter PostalCode:");
                                                string newPostalCode = Console.ReadLine();
                                                if (!string.IsNullOrEmpty(newPostalCode))
                                                {
                                                    addressUpdate.PostalCode = newPostalCode;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid PostalCode. Address PostalCode will remain unchanged.");
                                                }

                                                Console.WriteLine("Enter State:");
                                                string newState = Console.ReadLine();
                                                if (!string.IsNullOrEmpty(newState))
                                                {
                                                    addressUpdate.State = newStreet;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid State. Address State will remain unchanged.");
                                                }

                                                addressDAO.Update(addressUpdate);
                                            }
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("Not a valid option");
                                        break;
                                }
                                break;
                            case "3":
                                menu.PrintDeleteMenu();
                                Console.WriteLine("Choose:");
                                string inputDelete = Console.ReadLine();
                                // DELETE options
                                switch (inputDelete)
                                {
                                    case "1":
                                        // Removes an order from the database.
                                        foreach (var o in orderDAO.GetAll())
                                        {
                                            Console.WriteLine(o);
                                        }

                                        Console.WriteLine("Enter ID of Order:");
                                        string orderID = Console.ReadLine();
                                        orderDAO.Delete(Convert.ToInt32(orderID));
                                        break;
                                    case "2":
                                        // Remove a product from the database.
                                        foreach (var o in orderBookDAO.GetAll())
                                        {
                                            Console.WriteLine(o);
                                        }

                                        Console.WriteLine("Enter ID of OrderBook:");
                                        string orderBookID = Console.ReadLine();
                                        orderBookDAO.Delete(Convert.ToInt32(orderBookID));
                                        break;
                                    case "3":
                                        // Remove an ordered product from the database.
                                        foreach (var a in addressDAO.GetAll())
                                        {
                                            Console.WriteLine(a);
                                        }

                                        Console.WriteLine("Enter ID of Address:");
                                        string addressID = Console.ReadLine();
                                        addressDAO.Delete(Convert.ToInt32(addressID));
                                        break;
                                    default:
                                        Console.WriteLine("Not a valid option");
                                        break;
                                }
                                break;
                            case "4":
                                menu.PrintListAllMenu();
                                Console.WriteLine("Choose:");
                                string inputListAll = Console.ReadLine();
                                // LIST ALL options
                                switch (inputListAll)
                                {
                                    case "1":

                                        foreach (var o in orderDAO.GetAll())
                                        {
                                            Console.WriteLine(o);
                                        }
                                        break;
                                    case "2":

                                        foreach (var o in orderBookDAO.GetAll())
                                        {
                                            Console.WriteLine(o);
                                        }
                                        break;
                                    case "3":

                                        foreach (var a in addressDAO.GetAll())
                                        {
                                            Console.WriteLine(a);
                                        }
                                        break;
                                    case "6":

                                        Console.WriteLine("All orders:");
                                        foreach (var o in orderDAO.GetAll())
                                        {
                                            Console.WriteLine(o);
                                        }

                                        foreach (var o in orderBookDAO.GetAll())
                                        {
                                            Console.WriteLine(o);
                                        }

                                        foreach (var a in addressDAO.GetAll())
                                        {
                                            Console.WriteLine(a);
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("Not a valid option");
                                        break;
                                }
                                break;
                            case "5":
                                menu.PrintDeleteAllMenu();
                                Console.WriteLine("Choose:");
                                string inputDelAll = Console.ReadLine();

                                switch (inputDelAll)
                                {
                                    case "1":

                                        string choiceDelOrders = "";
                                        foreach (var o in orderDAO.GetAll())
                                        {
                                            Console.WriteLine(o);
                                        }
                                        Console.WriteLine("Do you want to delete all orders? (yes/no)");
                                        choiceDelOrders = Console.ReadLine();
                                        if (choiceDelOrders == "yes")
                                        {
                                            orderDAO.DeleteAll();
                                        }
                                        break;
                                    case "2":

                                        string choiceDelOrderBooks = "";
                                        foreach (var o in orderBookDAO.GetAll())
                                        {
                                            Console.WriteLine(o);
                                        }
                                        Console.WriteLine("Do you want to delete all orderBooks? (yes/no)");
                                        choiceDelOrderBooks = Console.ReadLine();
                                        if (choiceDelOrderBooks == "yes")
                                        {
                                            orderBookDAO.DeleteAll();
                                        }
                                        break;
                                    case "3":

                                        string choiceDelAddress = "";
                                        foreach (var o in addressDAO.GetAll())
                                        {
                                            Console.WriteLine(o);
                                        }
                                        Console.WriteLine("Do you want to delete all addresses? (yes/no)");
                                        choiceDelAddress = Console.ReadLine();
                                        if (choiceDelAddress == "yes")
                                        {
                                            addressDAO.DeleteAll();
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("Not a valid option");
                                        break;
                                }
                                break;
                            case "6":

                                Console.WriteLine("Quitting");
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Not a valid option");
                                break;
                        }
                        break;
                    case "2":
                        break;
                    case "3":
                        Console.WriteLine("Quitting");
                        Environment.Exit(0);
                        break;
                }

                } while (true);
        }
    }
}

