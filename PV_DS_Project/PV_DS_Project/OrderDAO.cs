using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_DS_Project
{
    internal class OrderDAO : IRepozitory<Order>
    {
        public void Delete(Order order)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("DELETE FROM Orders WHERE id = @id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", order.ID));
                command.ExecuteNonQuery();
                order.ID = 0;
            }
        }

        public IEnumerable<Order> GetAll()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Orders", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Order order = new Order
                    {
                        ID = Convert.ToInt32(reader[0].ToString()),
                        CustomerID = Convert.ToInt32(reader[1].ToString()),
                        SupplierID = Convert.ToInt32(reader[2].ToString()),
                        OrderDate = Convert.ToDateTime(reader[3].ToString()),
                        TotalPrice = Convert.ToInt32(reader[4].ToString()),
                        ShippingAddress = reader[5].ToString(),
                        IsCompleted = Convert.ToBoolean(reader[6].ToString()),
                        TotalAmount = Convert.ToInt32(reader[7].ToString()),
                    };
                    yield return order;
                }
                reader.Close();
            }
        }

        public Order GetByID(int id)
        {
            Order order = null;
            SqlConnection conn = DatabaseSingleton.GetInstance();


            using (SqlCommand command = new SqlCommand("SELECT * FROM Orders WHERE id = @Id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    order = new Order
                    {

                        ID = Convert.ToInt32(reader[0].ToString()),
                        CustomerID = Convert.ToInt32(reader[1].ToString()),
                        SupplierID = Convert.ToInt32(reader[2].ToString()),
                        OrderDate = Convert.ToDateTime(reader[3].ToString()),
                        TotalPrice = Convert.ToInt32(reader[4].ToString()),
                        ShippingAddress = reader[5].ToString(),
                        IsCompleted = Convert.ToBoolean(reader[6].ToString()),
                        TotalAmount = Convert.ToInt32(reader[7].ToString()),
                    };
                }
                reader.Close();
                return order;
            }
        }

        public void Save(Order order)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            if (order.ID < 1)
            {
                using (command = new SqlCommand("INSERT INTO Orders VALUES (@customerID, @supplierID, @orderDate, @totalPrice, @shippingAddress, @isCompleted, @totalAmount)", conn))
                {
                    command.Parameters.Add(new SqlParameter("@customerID", order.CustomerID));
                    command.Parameters.Add(new SqlParameter("@supplierID", order.SupplierID));
                    command.Parameters.Add(new SqlParameter("@orderDate", order.OrderDate));
                    command.Parameters.Add(new SqlParameter("@totalPrice", order.TotalPrice));
                    command.Parameters.Add(new SqlParameter("@shippingAddress", order.ShippingAddress));
                    command.Parameters.Add(new SqlParameter("@isCompleted", order.IsCompleted));
                    command.Parameters.Add(new SqlParameter("@totalAmount", order.TotalAmount));
                    command.ExecuteNonQuery();
                    
                    command.CommandText = "Select @@Identity";
                    order.ID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            else
            {
                using (command = new SqlCommand("UPDATE Orders SET customerID = @customerID, supplierID = @supplierID, orderDate = @orderDate, totalPrice = @totalPrice, shippingAddress = @shippingAddress, isCompleted = @isCompleted, totalAmount = @totalAmount" + "WHERE id = @id", conn))
                {
                    command.Parameters.Add(new SqlParameter("@id", order.ID));
                    command.Parameters.Add(new SqlParameter("@customerID", order.CustomerID));
                    command.Parameters.Add(new SqlParameter("@supplierID", order.SupplierID));
                    command.Parameters.Add(new SqlParameter("@orderDate", order.OrderDate));
                    command.Parameters.Add(new SqlParameter("@totalPrice", order.TotalPrice));
                    command.Parameters.Add(new SqlParameter("@shippingAddress", order.ShippingAddress));
                    command.Parameters.Add(new SqlParameter("@isCompleted", order.IsCompleted));
                    command.Parameters.Add(new SqlParameter("@totalAmount", order.TotalAmount));
                    command.ExecuteNonQuery();
                }
            }

        }

        public void Add(Order order)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("INSERT INTO Orders VALUES (@id, @customerID, @supplierID, @orderDate, @totalPrice, @shippingAddress, @isCompleted, @totalAmount)", conn))
            {
                command.Parameters.Add(new SqlParameter("@customerID", order.CustomerID));
                command.Parameters.Add(new SqlParameter("@supplierID", order.SupplierID));
                command.Parameters.Add(new SqlParameter("@orderDate", order.OrderDate));
                command.Parameters.Add(new SqlParameter("@totalPrice", order.TotalPrice));
                command.Parameters.Add(new SqlParameter("@shippingAddress", order.ShippingAddress));
                command.Parameters.Add(new SqlParameter("@isCompleted", order.IsCompleted));
                command.Parameters.Add(new SqlParameter("@totalAmount", order.TotalAmount));
                command.ExecuteNonQuery();

                command.CommandText = "Select @@Identity";
                order.ID = Convert.ToInt32(command.ExecuteScalar());
            }
        }

    }
}
