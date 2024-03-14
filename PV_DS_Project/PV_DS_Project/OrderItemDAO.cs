using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_DS_Project
{
    internal class OrderItemDAO : IRepozitory<OrderItem>
    {
        public void Delete(OrderItem orderItem)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("DELETE FROM OrderItems WHERE id = @id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", orderItem.ID));
                command.ExecuteNonQuery();
                orderItem.ID = 0;
            }
        }

        public IEnumerable<OrderItem> GetAll()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM OrderItems", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    OrderItem orderItem = new OrderItem
                    {
                        ID = Convert.ToInt32(reader[0].ToString()),
                        ItemID = Convert.ToInt32(reader[1].ToString()),
                        OrderID = Convert.ToInt32(reader[2].ToString()),
                        Amount = Convert.ToInt32(reader[3].ToString()),
                        Price = Convert.ToInt32(reader[4].ToString()),
                    };
                    yield return orderItem;
                }
                reader.Close();
            }
        }

        public OrderItem GetByID(int id)
        {
            OrderItem orderItem = null;
            SqlConnection conn = DatabaseSingleton.GetInstance();


            using (SqlCommand command = new SqlCommand("SELECT * FROM OrderItems WHERE id = @Id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    orderItem = new OrderItem
                    {

                        ID = Convert.ToInt32(reader[0].ToString()),
                        ItemID = Convert.ToInt32(reader[1].ToString()),
                        OrderID = Convert.ToInt32(reader[2].ToString()),
                        Amount = Convert.ToInt32(reader[3].ToString()),
                        Price = Convert.ToInt32(reader[4].ToString()),
                    };
                }
                reader.Close();
                return orderItem;
            }
        }

        public void Save(OrderItem orderItem)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            if (orderItem.ID < 1)
            {
                using (command = new SqlCommand("INSERT INTO OrderItems VALUES (@itemID, @orderID, @amount, @price)", conn))
                {
                    command.Parameters.Add(new SqlParameter("@itemID", orderItem.ItemID));
                    command.Parameters.Add(new SqlParameter("@orderID", orderItem.OrderID));
                    command.Parameters.Add(new SqlParameter("@amount", orderItem.Amount));
                    command.Parameters.Add(new SqlParameter("@price", orderItem.Price));
                    command.ExecuteNonQuery();

                    command.CommandText = "Select @@Identity";
                    orderItem.ID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            else
            {
                using (command = new SqlCommand("UPDATE OrderItems SET itemID = @itemID, orderID = @orderID, amount = @amount, price = @price" + "WHERE id = @id", conn))
                {
                    command.Parameters.Add(new SqlParameter("@id", orderItem.ID));
                    command.Parameters.Add(new SqlParameter("@itemID", orderItem.ItemID));
                    command.Parameters.Add(new SqlParameter("@orderID", orderItem.OrderID));
                    command.Parameters.Add(new SqlParameter("@amount", orderItem.Amount));
                    command.Parameters.Add(new SqlParameter("@price", orderItem.Price));
                    command.ExecuteNonQuery();
                }
            }

        }

        public void Add(OrderItem orderItem)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("INSERT INTO OrderItems VALUES (@id, @itemID, @orderID, @amount, @price)", conn))
            {
                command.Parameters.Add(new SqlParameter("@itemID", orderItem.ItemID));
                command.Parameters.Add(new SqlParameter("@orderID", orderItem.OrderID));
                command.Parameters.Add(new SqlParameter("@amount", orderItem.Amount));
                command.Parameters.Add(new SqlParameter("@price", orderItem.Price));
                command.ExecuteNonQuery();

                command.CommandText = "Select @@Identity";
                orderItem.ID = Convert.ToInt32(command.ExecuteScalar());
            }
        }
    }
}
