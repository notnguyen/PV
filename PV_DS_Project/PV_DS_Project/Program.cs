using System;

namespace PV_DS_Project
{
    internal class Program
    {
        private static CustomerDAO customerDAO = new CustomerDAO();
        private static SupplierDAO supplierDAO = new SupplierDAO();
        private static ItemDAO itemDAO = new ItemDAO();
        private static OrderDAO orderDAO = new OrderDAO();
        private static OrderItemDAO orderItemDAO = new OrderItemDAO();

        static void Main(string[] args)
        {
            ShowOptions();
        }

        static void ShowOptions()
        {
            while (true)
            {
                Console.WriteLine("Select");
                Console.WriteLine("1. Customer");
                Console.WriteLine("2. Supplier");
                Console.WriteLine("3. Item");
                Console.WriteLine("4. Order");
                Console.WriteLine("5. OrderItem");
                Console.WriteLine("6. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        EditEntity("Customer");
                        break;
                    case "2":
                        EditEntity("Supplier");
                        break;
                    case "3":
                        EditEntity("Item");
                        break;
                    case "4":
                        EditEntity("Order");
                        break;
                    case "5":
                        EditEntity("OrderItem");
                        break;
                    case "6":
                        Console.WriteLine("Exit");
                        return;
                    default:
                        Console.WriteLine("Try again");
                        break;
                }
            }
        }

        static void EditEntity(string entityName)
        {
            while (true)
            {
                Console.WriteLine($"Selected option: {entityName}");
                Console.WriteLine("Select:");
                Console.WriteLine("1. Delete");
                Console.WriteLine("2. GetAll");
                Console.WriteLine("3. GetByID");
                Console.WriteLine("4. Save");
                Console.WriteLine("5. Add");
                Console.WriteLine("6. Back");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Delete ID:");
                        string id = Console.ReadLine();
                        switch (entityName)
                        {
                            case "Customer":
                                customerDAO.Delete(Convert.ToInt32(id));
                                break;
                            case "Supplier":
                                supplierDAO.Delete(Convert.ToInt32(id));
                                break;
                            case "Item":
                                itemDAO.Delete(Convert.ToInt32(id));
                                break;
                            case "Order":
                                orderDAO.Delete(Convert.ToInt32(id));
                                break;
                            case "OrderItem":
                                orderItemDAO.Delete(Convert.ToInt32(id));
                                break;
                        }
                        break;
                    case "2":
                        Console.WriteLine("GetAll");
                        switch (entityName)
                        {
                            case "Customer":
                                PrintOut(customerDAO.GetAll());
                                break;
                            case "Supplier":
                                PrintOut(supplierDAO.GetAll());
                                break;
                            case "Item":
                                PrintOut(itemDAO.GetAll());
                                break;
                            case "Order":
                                PrintOut(orderDAO.GetAll());
                                break;
                            case "OrderItem":
                                PrintOut(orderItemDAO.GetAll());
                                break;
                        }
                        break;
                    case "6":
                        Console.WriteLine("Back");
                        return;
                    default:
                        Console.WriteLine("Try again");
                        break;
                }
            }
        }

        static void PrintOut(IEnumerable<object> entities)
        {
            foreach (var entity in entities)
            {
                Console.WriteLine(entity);
            }
        }
    }
}
