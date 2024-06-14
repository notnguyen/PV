using Bookstore_2._0.Entity;
using Bookstore_2._0.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_2._0.DAO
{
    public class OrderDAO : IDAO<Order>
    {
        public void Add(Order order)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            if (!ValidCustomer(order.CustomerID))
            {
                Console.WriteLine("Invalid CustomerID. Customer does not exist.");
                return;
            }

            if (!ValidSupplier(order.SupplierID))
            {
                Console.WriteLine("Invalid SupplierID. Supplier does not exist.");
                return;
            }

            if (!ValidAddress(order.AddressID))
            {
                Console.WriteLine("Invalid AddressID. Address does not exist.");
                return;
            }

            using (SqlCommand command = new SqlCommand("INSERT INTO Order VALUES (@customerID, @supplierID, @addressID, @orderDate, @totalPrice, @totalAmount, @isShipped)", connection))
            {
                command.Parameters.Add(new SqlParameter("@customerID", order.CustomerID));
                command.Parameters.Add(new SqlParameter("@supplierID", order.SupplierID));
                command.Parameters.Add(new SqlParameter("@addressID", order.AddressID));
                command.Parameters.Add(new SqlParameter("@orderDate", order.OrderDate));
                command.Parameters.Add(new SqlParameter("@totalPrice", order.TotalPrice));
                command.Parameters.Add(new SqlParameter("@totalAmount", order.TotalAmount));
                command.Parameters.Add(new SqlParameter("@isShipped", order.IsShipped));
                command.ExecuteNonQuery();
                Console.WriteLine("Order added");

                command.CommandText = "Select @@Identity";
                order.ID = Convert.ToInt32(command.ExecuteScalar());
            }
        }

        private bool ValidCustomer(int customerID)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using var command = new SqlCommand("SELECT COUNT(*) FROM Customer WHERE id = @customerID", connection);
            command.Parameters.AddWithValue("@customerID", customerID);
            int count = (int)command.ExecuteScalar();
            return count > 0;
        }

        private bool ValidSupplier(int supplierID)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using var command = new SqlCommand("SELECT COUNT(*) FROM Supplier WHERE id = @supplierID", connection);
            command.Parameters.AddWithValue("@supplierID", supplierID);
            int count = (int)command.ExecuteScalar();
            return count > 0;
        }

        private bool ValidAddress(int addressID)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using var command = new SqlCommand("SELECT COUNT(*) FROM Address WHERE id = @addressID", connection);
            command.Parameters.AddWithValue("@addressID", addressID);
            int count = (int)command.ExecuteScalar();
            return count > 0;
        }

        public void Delete(int id)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();
            SqlCommand command = null;

            using (command = new SqlCommand("SELECT * FROM Order WHERE id = @orderID", connection))
            {
                command.Parameters.AddWithValue("@orderID", id);
            }

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine("Order is being removed");
                }
                else
                {
                    Console.WriteLine("Order not found.");
                    return;
                }
            }

            SqlCommand deleteCommand = null;
            using (deleteCommand = new SqlCommand("DELETE FROM Order WHERE id = @ID", connection))
            {
                deleteCommand.Parameters.AddWithValue("@ID", id);
                deleteCommand.ExecuteNonQuery();
            }

            Console.WriteLine("Order successfully removed");
        }

        public void DeleteAll()
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using SqlCommand command = new SqlCommand("DELETE FROM Order", connection);
            command.ExecuteNonQuery();
        }

        public IEnumerable<Order> GetAll()
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Order", connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Order order = new Order
                    {
                        ID = Convert.ToInt32(reader[0].ToString()),
                        CustomerID = Convert.ToInt32(reader[1].ToString()),
                        SupplierID = Convert.ToInt32(reader[2].ToString()),
                        AddressID = Convert.ToInt32(reader[3].ToString()),
                        OrderDate = Convert.ToDateTime(reader[4].ToString()),
                        TotalPrice = Convert.ToDouble(reader[5].ToString()),
                        TotalAmount = Convert.ToInt32(reader[6].ToString()),
                        IsShipped = Convert.ToBoolean(reader[7].ToString())
                    };
                    yield return order;
                }
                reader.Close();
            }
        }

        public Order? GetById(int id)
        {
            Order order = null;
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Order WHERE id = @ID", connection))
            {
                command.Parameters.Add(new SqlParameter("@ID", id));

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    order = new Order
                    {
                        ID = Convert.ToInt32(reader[0].ToString()),
                        CustomerID = Convert.ToInt32(reader[1].ToString()),
                        SupplierID = Convert.ToInt32(reader[2].ToString()),
                        AddressID = Convert.ToInt32(reader[3].ToString()),
                        OrderDate = Convert.ToDateTime(reader[4].ToString()),
                        TotalPrice = Convert.ToDouble(reader[5].ToString()),
                        TotalAmount = Convert.ToInt32(reader[6].ToString()),
                        IsShipped = Convert.ToBoolean(reader[7].ToString())
                    };
                }
                reader.Close();
                return order;
            }
        }

        public void Update(Order order)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            if (!ValidCustomer(order.CustomerID))
            {
                Console.WriteLine("Invalid CustomerID. Customer does not exist.");
                return;
            }

            if (!ValidSupplier(order.SupplierID))
            {
                Console.WriteLine("Invalid SupplierID. Supplier does not exist.");
                return;
            }

            if (!ValidAddress(order.AddressID))
            {
                Console.WriteLine("Invalid AddressID. Address does not exist.");
                return;
            }

            SqlCommand command = null;

            using (command = new SqlCommand("UPDATE Order SET customerID = @customerID, supplierID = @supplierID, addressID = @addressID, orderDate = @orderDate, totalPrice = @totalPrice, totalAmount = @totalAmount, isShipped = @isShipped" + "WHERE id = @ID", connection))
            {
                command.Parameters.Add(new SqlParameter("@ID", order.ID));
                command.Parameters.Add(new SqlParameter("@customerID", order.CustomerID));
                command.Parameters.Add(new SqlParameter("@supplierID", order.SupplierID));
                command.Parameters.Add(new SqlParameter("@addressID", order.AddressID));
                command.Parameters.Add(new SqlParameter("@orderDate", order.OrderDate));
                command.Parameters.Add(new SqlParameter("@totalPrice", order.TotalPrice));
                command.Parameters.Add(new SqlParameter("@totalAmount", order.TotalAmount));
                command.Parameters.Add(new SqlParameter("@isShipped", order.IsShipped));
                command.ExecuteNonQuery();
            }
        }
    }
}
