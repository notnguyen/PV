using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVDatabaseProject
{
    internal class OrderItemDao : IRepository<OrderItem>
    {
        public void Add(OrderItem entity)
        {
           SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("INSERT INTO Polozky_Objednavky (ID_Polozky, ID_Objednavky, ID_Produktu, Mnozstvi, Cena_Za_Polozku) VALUES (@orderId, @productId, @quantity, @pricePerItem)", conn))
            {
                command.Parameters.Add(new SqlParameter("@orderId", entity.OrderId));
                command.Parameters.Add(new SqlParameter("@productId", entity.ProductId));
                command.Parameters.Add(new SqlParameter("@quantity", entity.Quantity));
                command.Parameters.Add(new SqlParameter("@pricePerItem", entity.PricePerItem));

                command.ExecuteNonQuery();
                command.CommandText = "Select @@Identity";
                entity.OrderItemId = Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public void Delete(int id)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("Delete FROM Polozky_Objednavky where id = @id", conn))
            {
                command.Parameters.Add("@id", (System.Data.SqlDbType)id);
                command.ExecuteNonQuery();
                id = 0;
            }
        }

        public IEnumerable<OrderItem> GetAll()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Polozky_Objednavky", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    OrderItem orderItem = new OrderItem
                    {
                        OrderItemId = Convert.ToInt32(reader[0].ToString()),
                        OrderId = Convert.ToInt32(reader[1].ToString()),
                        ProductId = Convert.ToInt32(reader[2].ToString()),
                        Quantity = Convert.ToInt32(reader[3].ToString()),
                        PricePerItem = Convert.ToInt32(reader[4].ToString()),
                    };
                    yield return orderItem;
                }
                reader.Close();
            }
        }

        public OrderItem GetById(int id)
        {
            OrderItem orderItem = null;
            SqlConnection conn = DatabaseSingleton.GetInstance();


            using (SqlCommand command = new SqlCommand("SELECT * FROM Polozky_Objednavky WHERE id = @Id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    orderItem = new OrderItem
                    {
                        OrderItemId = Convert.ToInt32(reader[0].ToString()),
                        OrderId = Convert.ToInt32(reader[1].ToString()),
                        ProductId = Convert.ToInt32(reader[2].ToString()),
                        Quantity = Convert.ToInt32(reader[3].ToString()),
                        PricePerItem = Convert.ToInt32(reader[4].ToString()),
                    };
                }
                reader.Close();
                return orderItem;
            }
        }

        public void Update(OrderItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
