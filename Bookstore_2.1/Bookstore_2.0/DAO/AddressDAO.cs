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
    public class AddressDAO : IDAO<Address>
    {
        public void Add(Address address)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("INSERT INTO Address VALUES (@street, @houseNumber, @city, @postalCode, @state)", connection))
            {
                command.Parameters.Add(new SqlParameter("@street", address.Street));
                command.Parameters.Add(new SqlParameter("@houseNumber", address.HouseNumber));
                command.Parameters.Add(new SqlParameter("@city", address.City));
                command.Parameters.Add(new SqlParameter("@postalCode", address.PostalCode));
                command.Parameters.Add(new SqlParameter("@state", address.State));
                command.ExecuteNonQuery();
                Console.WriteLine("Address added");

                command.CommandText = "Select @@Identity";
                address.ID = Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public void Delete(int id)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();
            SqlCommand command = null;

            using (command = new SqlCommand("SELECT * FROM Address WHERE id = @addressID", connection))
            {
                command.Parameters.AddWithValue("@addressID", id);
            }

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine("Address is being removed");
                }
                else
                {
                    Console.WriteLine("Address not found.");
                    return;
                }
            }

            SqlCommand deleteCommand = null;
            using (deleteCommand = new SqlCommand("DELETE FROM Address WHERE id = @ID", connection))
            {
                deleteCommand.Parameters.AddWithValue("@ID", id);
                deleteCommand.ExecuteNonQuery();
            }

            Console.WriteLine("Address successfully removed");
        }

        public void DeleteAll()
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using SqlCommand command = new SqlCommand("DELETE FROM Address", connection);
            command.ExecuteNonQuery();
        }

        public IEnumerable<Address> GetAll()
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Address", connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Address address = new Address
                    {
                        ID = Convert.ToInt32(reader[0].ToString()),
                        Street = reader[1].ToString(),
                        HouseNumber = Convert.ToInt32(reader[2].ToString()),
                        City = reader[3].ToString(),
                        PostalCode = reader[4].ToString(),
                        State = reader[5].ToString()
                    };
                    yield return address;
                }
                reader.Close();
            }
        }

        public Address? GetById(int id)
        {
            Address address = null;
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Address WHERE id = @ID", connection))
            {
                command.Parameters.Add(new SqlParameter("@ID", id));

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    address = new Address
                    {
                        ID = Convert.ToInt32(reader[0].ToString()),
                        Street = reader[1].ToString(),
                        HouseNumber = Convert.ToInt32(reader[2].ToString()),
                        City = reader[3].ToString(),
                        PostalCode = reader[4].ToString(),
                        State = reader[5].ToString()
                    };
                }
                reader.Close();
                return address;
            }
        }

        public void Update(Address address)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("UPDATE Address SET street = @street, houseNumber = @houseNumber, city = @city, postalCode = @postalCode, state = @state" + "WHERE id = @ID", connection))
            {
                command.Parameters.Add(new SqlParameter("@ID", address.ID));
                command.Parameters.Add(new SqlParameter("@street", address.Street));
                command.Parameters.Add(new SqlParameter("@houseNumber", address.HouseNumber));
                command.Parameters.Add(new SqlParameter("@city", address.City));
                command.Parameters.Add(new SqlParameter("@postalCode", address.PostalCode));
                command.Parameters.Add(new SqlParameter("@state", address.State));
                command.ExecuteNonQuery();
            }
        }
    }
}
