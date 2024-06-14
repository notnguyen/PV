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
    public class SupplierDAO : IDAO<Supplier>
    {
        public void Add(Supplier supplier)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("INSERT INTO Supplier VALUES (@firstName, @lastName, @email, @phoneNumber)", connection))
            {
                command.Parameters.Add(new SqlParameter("@firstName", supplier.FirstName));
                command.Parameters.Add(new SqlParameter("@lastName", supplier.LastName));
                command.Parameters.Add(new SqlParameter("@email", supplier.Email));
                command.Parameters.Add(new SqlParameter("@phoneNumber", supplier.PhoneNumber));
                command.ExecuteNonQuery();
                Console.WriteLine("Supplier added");

                command.CommandText = "Select @@Identity";
                supplier.ID = Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public void Delete(int id)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();
            SqlCommand command = null;

            using (command = new SqlCommand("SELECT * FROM Supplier WHERE id = @supplierID", connection))
            {
                command.Parameters.AddWithValue("@supplierID", id);
            }

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine("Supplier is being removed");
                }
                else
                {
                    Console.WriteLine("Supplier not found.");
                    return;
                }
            }

            SqlCommand deleteCommand = null;
            using (deleteCommand = new SqlCommand("DELETE FROM Supplier WHERE id = @ID", connection))
            {
                deleteCommand.Parameters.AddWithValue("@ID", id);
                deleteCommand.ExecuteNonQuery();
            }

            Console.WriteLine("Supplier successfully removed");
        }

        public void DeleteAll()
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using SqlCommand command = new SqlCommand("DELETE FROM Supplier", connection);
            command.ExecuteNonQuery();
        }

        public IEnumerable<Supplier> GetAll()
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Supplier", connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Supplier supplier = new Supplier
                    {
                        ID = Convert.ToInt32(reader[0].ToString()),
                        FirstName = reader[1].ToString(),
                        LastName = reader[2].ToString(),
                        Email = reader[3].ToString(),
                        PhoneNumber = reader[4].ToString()
                    };
                    yield return supplier;
                }
                reader.Close();
            }
        }

        public Supplier? GetById(int id)
        {
            Supplier supplier = null;
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Supplier WHERE id = @ID", connection))
            {
                command.Parameters.Add(new SqlParameter("@ID", id));

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    supplier = new Supplier
                    {
                        ID = Convert.ToInt32(reader[0].ToString()),
                        FirstName = reader[1].ToString(),
                        LastName = reader[2].ToString(),
                        Email = reader[3].ToString(),
                        PhoneNumber = reader[4].ToString()
                    };
                }
                reader.Close();
                return supplier;
            }
        }

        public void Update(Supplier supplier)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("UPDATE Supplier SET firstName = @firstName, lastName = @lastName, email = @email, phoneNumber = @phoneNumber" + "WHERE id = @ID", connection))
            {
                command.Parameters.Add(new SqlParameter("@ID", supplier.ID));
                command.Parameters.Add(new SqlParameter("@firstName", supplier.FirstName));
                command.Parameters.Add(new SqlParameter("@lastName", supplier.LastName));
                command.Parameters.Add(new SqlParameter("@email", supplier.Email));
                command.Parameters.Add(new SqlParameter("@phoneNumber", supplier.PhoneNumber));
                command.ExecuteNonQuery();
            }
        }
    }
}
