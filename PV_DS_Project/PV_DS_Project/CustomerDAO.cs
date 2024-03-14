using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_DS_Project
{
    internal class CustomerDAO : IRepozitory<Customer>
    {
        public void Delete(Customer customer)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("DELETE FROM Customers WHERE id = @id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", customer.ID));
                command.ExecuteNonQuery();
                customer.ID = 0;
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Customers", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Customer customer = new Customer
                    {
                        ID = Convert.ToInt32(reader[0].ToString()),
                        FirstName = reader[1].ToString(),
                        LastName = reader[2].ToString(),
                        Address = reader[3].ToString(),
                        PhoneNumber = reader[4].ToString(),

                    };
                    yield return customer;
                }
                reader.Close();
            }
        }

        public Customer GetByID(int id)
        {
            Customer customer = null;
            SqlConnection conn = DatabaseSingleton.GetInstance();


            using (SqlCommand command = new SqlCommand("SELECT * FROM Customers WHERE id = @Id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    customer = new Customer
                    {

                        ID = Convert.ToInt32(reader[0].ToString()),
                        FirstName = reader[1].ToString(),
                        LastName = reader[2].ToString(),
                        Address = reader[3].ToString(),
                        PhoneNumber = reader[4].ToString(),
                    };
                }
                reader.Close();
                return customer;
            }
        }

        public void Save(Customer customer)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            if (customer.ID < 1)
            {
                using (command = new SqlCommand("INSERT INTO Customers VALUES (@firstName, @lastName, @address, @phoneNumber", conn))
                {
                    command.Parameters.Add(new SqlParameter("@firstName", customer.FirstName));
                    command.Parameters.Add(new SqlParameter("@lastName", customer.LastName));
                    command.Parameters.Add(new SqlParameter("@address", customer.Address));
                    command.Parameters.Add(new SqlParameter("@phoneNumber", customer.PhoneNumber));
                    command.ExecuteNonQuery();

                    command.CommandText = "Select @@Identity";
                    customer.ID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            else
            {
                using (command = new SqlCommand("UPDATE Customers SET firstName = @firstName, lastName = @lastName, address = @address, phoneNumber = @phoneNumber" + "WHERE id = @id", conn))
                {
                    command.Parameters.Add(new SqlParameter("@id", customer.ID));
                    command.Parameters.Add(new SqlParameter("@firstName", customer.FirstName));
                    command.Parameters.Add(new SqlParameter("@lastName", customer.LastName));
                    command.Parameters.Add(new SqlParameter("@address", customer.Address));
                    command.Parameters.Add(new SqlParameter("@phoneNumber", customer.PhoneNumber));
                    command.ExecuteNonQuery();
                }
            }


        }

        public void Add(Customer customer)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("INSERT INTO Customers VALUES (@id, @firstName, @lastName, @address, @phoneNumber)", conn))
            {
                command.Parameters.Add(new SqlParameter("@firstName", customer.FirstName));
                command.Parameters.Add(new SqlParameter("@lastName", customer.LastName));
                command.Parameters.Add(new SqlParameter("@address", customer.Address));
                command.Parameters.Add(new SqlParameter("@phoneNumber", customer.PhoneNumber));
                command.ExecuteNonQuery();

                command.CommandText = "Select @@Identity";
                customer.ID = Convert.ToInt32(command.ExecuteScalar());
            }
        }
    }
}
