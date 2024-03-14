using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_DS_Project
{
    internal class ItemDAO : IRepozitory<Item>
    {
        public void Delete(Item item)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("DELETE FROM Items WHERE id = @id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", item.ID));
                command.ExecuteNonQuery();
                item.ID = 0;
            }
        }

        public IEnumerable<Item> GetAll()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Items", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Item item = new Item
                    {
                        ID = Convert.ToInt32(reader[0].ToString()),
                        Name = reader[1].ToString(),
                        Price = Convert.ToInt32(reader[2].ToString()),
                        IsAvailable = Convert.ToBoolean(reader[3].ToString()),
                        Stock = Convert.ToInt32(reader[4].ToString()),
                        Description = reader[5].ToString(),
                    };
                    yield return item;
                }
                reader.Close();
            }
        }

        public Item GetByID(int id)
        {
            Item item = null;
            SqlConnection conn = DatabaseSingleton.GetInstance();


            using (SqlCommand command = new SqlCommand("SELECT * FROM Items WHERE id = @Id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    item = new Item
                    {

                        ID = Convert.ToInt32(reader[0].ToString()),
                        Name = reader[1].ToString(),
                        Price = Convert.ToInt32(reader[2].ToString()),
                        IsAvailable = Convert.ToBoolean(reader[3].ToString()),
                        Stock = Convert.ToInt32(reader[4].ToString()),
                        Description = reader[5].ToString(),
                    };
                }
                reader.Close();
                return item;
            }
        }

        public void Save(Item item)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            if (item.ID < 1)
            {
                using (command = new SqlCommand("INSERT INTO Items VALUES (@name, @price, @isAvailable, @stock, @description)", conn))
                {
                    command.Parameters.Add(new SqlParameter("@name", item.Name));
                    command.Parameters.Add(new SqlParameter("@price", item.Price));
                    command.Parameters.Add(new SqlParameter("@isAvailable", item.IsAvailable));
                    command.Parameters.Add(new SqlParameter("@stock", item.Stock));
                    command.Parameters.Add(new SqlParameter("@description", item.Description));
                    command.ExecuteNonQuery();

                    command.CommandText = "Select @@Identity";
                    item.ID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            else
            {
                using (command = new SqlCommand("UPDATE Items SET name = @name, price = @price, isAvailable = @isAvailable, stock = @stock, description = @description" + "WHERE id = @id", conn))
                {
                    command.Parameters.Add(new SqlParameter("@id", item.ID));
                    command.Parameters.Add(new SqlParameter("@name", item.Name));
                    command.Parameters.Add(new SqlParameter("@price", item.Price));
                    command.Parameters.Add(new SqlParameter("@isAvailable", item.IsAvailable));
                    command.Parameters.Add(new SqlParameter("@stock", item.Stock));
                    command.Parameters.Add(new SqlParameter("@description", item.Description));
                    command.ExecuteNonQuery();
                }
            }

        }

        public void Add(Item item)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("INSERT INTO Items VALUES (@id, @name, @price, @isAvailable, @stock, @description)", conn))
            {
                command.Parameters.Add(new SqlParameter("@name", item.Name));
                command.Parameters.Add(new SqlParameter("@price", item.Price));
                command.Parameters.Add(new SqlParameter("@isAvailable", item.IsAvailable));
                command.Parameters.Add(new SqlParameter("@stock", item.Stock));
                command.Parameters.Add(new SqlParameter("@description", item.Description));
                command.ExecuteNonQuery();

                command.CommandText = "Select @@Identity";
                item.ID = Convert.ToInt32(command.ExecuteScalar());
            }
        }
    }
}
