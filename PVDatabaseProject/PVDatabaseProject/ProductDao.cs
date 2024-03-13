using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PVDatabaseProject
{
    internal class ProductDao : IRepository<Product>
    {
        public void Add(Product entity)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("INSERT INTO Produkty (Nazev, Cena, Dostupnost) VALUES (@name, @price, @isAvailable)", conn))
            {
                command.Parameters.Add(new SqlParameter("@name", entity.Name));
                command.Parameters.Add(new SqlParameter("@price", entity.Price));
                command.Parameters.Add(new SqlParameter("@isAvailable", entity.Price));

                command.ExecuteNonQuery();  
                command.CommandText = "Select @@Identity";
                entity.ProductId = Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public void Delete(int id)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("Delete FROM Produkty where id = @id", conn))
            {
                command.Parameters.Add("@id", (System.Data.SqlDbType)id);
                command.ExecuteNonQuery();
                id = 0;
            }
        }

        public IEnumerable<Product> GetAll()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Produkty", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product
                    {
                        ProductId = Convert.ToInt32(reader[0].ToString()),
                        Name = reader[1].ToString()
                    };
                    yield return product;
                }
                reader.Close();
            }
        }

        public Product GetById(int id)
        {
            Product product = null;
            SqlConnection conn = DatabaseSingleton.GetInstance();


            using (SqlCommand command = new SqlCommand("SELECT * FROM Produkty WHERE id = @Id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    product = new Product
                    {
                        ProductId = Convert.ToInt32(reader[0].ToString()),
                        Name = reader[1].ToString()
                    };
                }
                reader.Close();
                return product;
            }
        }

        public void Update(Product entity)
        {/*
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            if (entity.ProductId < 1)
            {
                using (command = new SqlCommand("INSERT INTO Produkty (Nazev, Cena, Dostupnost) VALUES (@name, @price, @isAvailable)", conn))
                {
                    command.Parameters.Add(new SqlParameter("@name", entity.Name));
                    command.Parameters.Add(new SqlParameter("@price", entity.Price));
                    command.Parameters.Add(new SqlParameter("@isAvailable", entity.Price));
                    command.ExecuteNonQuery();

                    command.CommandText = "Select @@Identity";
                    entity.ProductId = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            else
            {
                using (command = new SqlCommand("UPDATE Produkt SET name = @name" +
                    "WHERE id = @id", conn))
                {
                    command.Parameters.Add(new SqlParameter("@id", entity.ProductId));
                    command.Parameters.Add(new SqlParameter("@name", entity.Name));
                    command.ExecuteNonQuery();
                }
            }*/
        }
    }
}
