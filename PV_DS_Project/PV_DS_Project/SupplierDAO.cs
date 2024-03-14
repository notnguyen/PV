using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_DS_Project
{
    internal class SupplierDAO : IRepozitory<Supplier>
    {
        public void Delete(Supplier supplier)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("DELETE FROM Suppliers WHERE id = @id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", supplier.ID));
                command.ExecuteNonQuery();
                supplier.ID = 0;
            }
        }

        public IEnumerable<Supplier> GetAll()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Suppliers", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Supplier supplier = new Supplier
                    {
                        ID = Convert.ToInt32(reader[0].ToString()),
                        FirstName = reader[1].ToString(),
                        LastName = reader[2].ToString(),
                        ContactEmail = reader[3].ToString(),
                        PhoneNumber = reader[4].ToString(),

                    };
                    yield return supplier;
                }
                reader.Close();
            }
        }

        public Supplier GetByID(int id)
        {
            Supplier supplier = null;
            SqlConnection conn = DatabaseSingleton.GetInstance();


            using (SqlCommand command = new SqlCommand("SELECT * FROM Suppliers WHERE id = @Id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    supplier = new Supplier
                    {

                        ID = Convert.ToInt32(reader[0].ToString()),
                        FirstName = reader[1].ToString(),
                        LastName = reader[2].ToString(),
                        ContactEmail = reader[3].ToString(),
                        PhoneNumber = reader[4].ToString(),
                    };
                }
                reader.Close();
                return supplier;
            }
        }

        public void Save(Supplier supplier)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            if (supplier.ID < 1)
            {
                using (command = new SqlCommand("INSERT INTO Suppliers VALUES (@firstName, @lastName, @contactEmail, @phoneNumber", conn))
                {
                    command.Parameters.Add(new SqlParameter("@firstName", supplier.FirstName));
                    command.Parameters.Add(new SqlParameter("@lastName", supplier.LastName));
                    command.Parameters.Add(new SqlParameter("@contactEmail", supplier.ContactEmail));
                    command.Parameters.Add(new SqlParameter("@phoneNumber", supplier.PhoneNumber));
                    command.ExecuteNonQuery();

                    command.CommandText = "Select @@Identity";
                    supplier.ID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            else
            {
                using (command = new SqlCommand("UPDATE Suppliers SET firstName = @firstName, lastName = @lastName, contactEmail = @contactEmail, phoneNumber = @phoneNumber" + "WHERE id = @id", conn))
                {
                    command.Parameters.Add(new SqlParameter("@id", supplier.ID));
                    command.Parameters.Add(new SqlParameter("@firstName", supplier.FirstName));
                    command.Parameters.Add(new SqlParameter("@lastName", supplier.LastName));
                    command.Parameters.Add(new SqlParameter("@contactEmail", supplier.ContactEmail));
                    command.Parameters.Add(new SqlParameter("@phoneNumber", supplier.PhoneNumber));
                    command.ExecuteNonQuery();
                }
            }

        }

        public void Add(Supplier supplier)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("INSERT INTO Suppliers VALUES (@id, @firstName, @lastName, @contactEmail, @phoneNumber)", conn))
            {
                command.Parameters.Add(new SqlParameter("@firstName", supplier.FirstName));
                command.Parameters.Add(new SqlParameter("@lastName", supplier.LastName));
                command.Parameters.Add(new SqlParameter("@contactEmail", supplier.ContactEmail));
                command.Parameters.Add(new SqlParameter("@phoneNumber", supplier.PhoneNumber));
                command.ExecuteNonQuery();

                command.CommandText = "Select @@Identity";
                supplier.ID = Convert.ToInt32(command.ExecuteScalar());
            }
        }
    }
}
