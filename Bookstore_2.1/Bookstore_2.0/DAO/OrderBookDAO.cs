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
    public class OrderBookDAO : IDAO<OrderBook>
    {
        public void Add(OrderBook orderBook)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            if (!ValidBook(orderBook.BookID))
            {
                Console.WriteLine("Invalid BookID. Book does not exist.");
                return;
            }

            if (!ValidOrder(orderBook.OrderID))
            {
                Console.WriteLine("Invalid OrderID. Order does not exist.");
                return;
            }

            using (SqlCommand command = new SqlCommand("INSERT INTO OrderBook VALUES (@bookID, @orderID, @amount, @price)", connection))
            {
                command.Parameters.Add(new SqlParameter("@bookID", orderBook.BookID));
                command.Parameters.Add(new SqlParameter("@orderID", orderBook.OrderID));
                command.Parameters.Add(new SqlParameter("@amount", orderBook.Amount));
                command.Parameters.Add(new SqlParameter("@price", orderBook.Price));
                command.ExecuteNonQuery();
                Console.WriteLine("OrderBook added");

                command.CommandText = "Select @@Identity";
                orderBook.ID = Convert.ToInt32(command.ExecuteScalar());
            }
        }

        private bool ValidBook(int bookID)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using var command = new SqlCommand("SELECT COUNT(*) FROM Book WHERE id = @bookID", connection);
            command.Parameters.AddWithValue("@bookID", bookID);
            int count = (int)command.ExecuteScalar();
            return count > 0;
        }

        private bool ValidOrder(int orderID)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using var command = new SqlCommand("SELECT COUNT(*) FROM Order WHERE id = @orderID", connection);
            command.Parameters.AddWithValue("@orderID", orderID);
            int count = (int)command.ExecuteScalar();
            return count > 0;
        }

        public void Delete(int id)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();
            SqlCommand command = null;

            using (command = new SqlCommand("SELECT * FROM OrderBook WHERE id = @orderBookID", connection))
            {
                command.Parameters.AddWithValue("@orderBookID", id);
            }

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine("OrderBook is being removed");
                }
                else
                {
                    Console.WriteLine("OrderBook not found.");
                    return;
                }
            }

            SqlCommand deleteCommand = null;
            using (deleteCommand = new SqlCommand("DELETE FROM OrderBook WHERE id = @ID", connection))
            {
                deleteCommand.Parameters.AddWithValue("@ID", id);
                deleteCommand.ExecuteNonQuery();
            }

            Console.WriteLine("OrderBook successfully removed");
        }

        public void DeleteAll()
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using SqlCommand command = new SqlCommand("DELETE FROM OrderBook", connection);
            command.ExecuteNonQuery();
        }

        public IEnumerable<OrderBook> GetAll()
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM OrderBook", connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    OrderBook orderBook = new OrderBook
                    {
                        ID = Convert.ToInt32(reader[0].ToString()),
                        BookID = Convert.ToInt32(reader[1].ToString()),
                        OrderID = Convert.ToInt32(reader[2].ToString()),
                        Amount = Convert.ToInt32(reader[3].ToString()),
                        Price = Convert.ToDouble(reader[4].ToString())
                    };
                    yield return orderBook;
                }
                reader.Close();
            }
        }

        public OrderBook? GetById(int id)
        {
            OrderBook orderBook = null;
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM OrderBook WHERE id = @ID", connection))
            {
                command.Parameters.Add(new SqlParameter("@ID", id));

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    orderBook = new OrderBook
                    {
                        ID = Convert.ToInt32(reader[0].ToString()),
                        BookID = Convert.ToInt32(reader[1].ToString()),
                        OrderID = Convert.ToInt32(reader[2].ToString()),
                        Amount = Convert.ToInt32(reader[3].ToString()),
                        Price = Convert.ToDouble(reader[4].ToString())
                    };
                }
                reader.Close();
                return orderBook;
            }
        }

        public void Update(OrderBook orderBook)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            if (!ValidBook(orderBook.BookID))
            {
                Console.WriteLine("Invalid BookID. Book does not exist.");
                return;
            }

            if (!ValidOrder(orderBook.OrderID))
            {
                Console.WriteLine("Invalid OrderID. Order does not exist.");
                return;
            }

            SqlCommand command = null;

            using (command = new SqlCommand("UPDATE OrderBook SET bookID = @bookID, orderID = @orderID, amount = @amount, price = @price" + "WHERE id = @ID", connection))
            {
                command.Parameters.Add(new SqlParameter("@ID", orderBook.ID));
                command.Parameters.Add(new SqlParameter("@bookID", orderBook.BookID));
                command.Parameters.Add(new SqlParameter("@orderID", orderBook.OrderID));
                command.Parameters.Add(new SqlParameter("@amount", orderBook.Amount));
                command.Parameters.Add(new SqlParameter("@price", orderBook.Price));
                command.ExecuteNonQuery();
            }
        }
    }
}
