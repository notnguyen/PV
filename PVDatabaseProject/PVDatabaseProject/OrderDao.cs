using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVDatabaseProject
{
    internal class OrderDao : IRepository<Order>
    {
        public void Add(Order entity)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("INSERT INTO Objednavky (ID_Zakaznika, Cas_Objednani, Celkova_Cena) VALUES (@orderId, @cusomerId, @orderDate, @orderPrice)", conn))
            {
                command.Parameters.Add(new SqlParameter("@cusomerId", entity.CustomerId));
                command.Parameters.Add(new SqlParameter("@orderDate", entity.OrderDate));
                command.Parameters.Add(new SqlParameter("@orderPrice", entity.TotalPrice));

                command.ExecuteNonQuery();
                command.CommandText = "Select @@Identity";
                entity.OrderId = Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public void Delete(int id)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("Delete FROM Objednavky where id = @id", conn))
            {
                command.Parameters.Add("@id", (System.Data.SqlDbType)id);
                command.ExecuteNonQuery();
                id = 0;
            }
        }

        public IEnumerable<Order> GetAll()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Objednavky", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Order order = new Order
                    {
                        OrderId = Convert.ToInt32(reader[1].ToString()),
                        CustomerId = Convert.ToInt32(reader[2].ToString()),
                        OrderDate = reader[3].ToString(),
                        TotalPrice = Convert.ToInt32(reader[3].ToString()),
                    };
                    yield return order;
                }
                reader.Close();
            }
        }

        public Order GetById(int id)
        {
            Order order = null;
            SqlConnection conn = DatabaseSingleton.GetInstance();


            using (SqlCommand command = new SqlCommand("SELECT * FROM Objednavky WHERE id = @Id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    order = new Order
                    {
                        OrderId = Convert.ToInt32(reader[1].ToString()),
                        CustomerId = Convert.ToInt32(reader[2].ToString()),
                        OrderDate = reader[3].ToString(),
                        TotalPrice = Convert.ToInt32(reader[3].ToString()),
                    };
                }
                reader.Close();
                return order;
            }
        }
        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
