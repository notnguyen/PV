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
    public class CustomerDAO : IDAO<Customer>
    {
        public void Add(Customer customer)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("INSERT INTO Customer VALUES (@userName, @password, @firstName, @lastName, @email, @phoneNumber)", connection))
            {
                command.Parameters.Add(new SqlParameter("@userName", customer.UserName));
                command.Parameters.Add(new SqlParameter("@password", customer.Password));
                command.Parameters.Add(new SqlParameter("@firstName", customer.FirstName));
                command.Parameters.Add(new SqlParameter("@lastName", customer.LastName));
                command.Parameters.Add(new SqlParameter("@email", customer.Email));
                command.Parameters.Add(new SqlParameter("@phoneNumber", customer.PhoneNumber));
                command.ExecuteNonQuery();
                Console.WriteLine("Customer added");

                command.CommandText = "Select @@Identity";
                customer.ID = Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public void Delete(int id)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();
            SqlCommand command = null;

            using (command = new SqlCommand("SELECT * FROM Customer WHERE id = @customerID", connection))
            {
                command.Parameters.AddWithValue("@customerID", id);
            }

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine("Customer is being removed");
                }
                else
                {
                    Console.WriteLine("Customer not found.");
                    return;
                }
            }

            SqlCommand deleteCommand = null;
            using (deleteCommand = new SqlCommand("DELETE FROM Customer WHERE id = @ID", connection))
            {
                deleteCommand.Parameters.AddWithValue("@ID", id);
                deleteCommand.ExecuteNonQuery();
            }

            Console.WriteLine("Customer successfully removed");
        }

        public void DeleteAll()
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using SqlCommand command = new SqlCommand("DELETE FROM Customer", connection);
            command.ExecuteNonQuery();
        }

        public IEnumerable<Customer> GetAll()
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Customer", connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Customer customer = new Customer
                    {
                        ID = Convert.ToInt32(reader[0].ToString()),
                        UserName = reader[1].ToString(),
                        Password = reader[2].ToString(),
                        FirstName = reader[3].ToString(),
                        LastName = reader[4].ToString(),
                        Email = reader[5].ToString(),
                        PhoneNumber = reader[6].ToString()
                    };
                    yield return customer;
                }
                reader.Close();
            }
        }

        public Customer? GetById(int id)
        {
            Customer customer = null;
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Customer WHERE id = @ID", connection))
            {
                command.Parameters.Add(new SqlParameter("@ID", id));

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    customer = new Customer
                    {
                        ID = Convert.ToInt32(reader[0].ToString()),
                        UserName = reader[1].ToString(),
                        Password = reader[2].ToString(),
                        FirstName = reader[3].ToString(),
                        LastName = reader[4].ToString(),
                        Email = reader[5].ToString(),
                        PhoneNumber = reader[6].ToString()
                    };
                }
                reader.Close();
                return customer;
            }
        }

        public void Update(Customer customer)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("UPDATE Customer SET userName = @userName, password = @password, firstName = @firstName, lastName = @lastName, email = @email, phoneNumber = @phoneNumber" + "WHERE id = @ID", connection))
            {
                command.Parameters.Add(new SqlParameter("@ID", customer.ID));
                command.Parameters.Add(new SqlParameter("@userName", customer.UserName));
                command.Parameters.Add(new SqlParameter("@password", customer.Password));
                command.Parameters.Add(new SqlParameter("@firstName", customer.FirstName));
                command.Parameters.Add(new SqlParameter("@lastName", customer.LastName));
                command.Parameters.Add(new SqlParameter("@email", customer.Email));
                command.Parameters.Add(new SqlParameter("@phoneNumber", customer.PhoneNumber));
                command.ExecuteNonQuery();
            }
        }

        public Customer? Login(string userName, string password)
        {
            Customer customer = null;
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Customer WHERE userName = @userName AND password = @password", connection))
            {
                command.Parameters.Add(new SqlParameter("@userName", userName));
                command.Parameters.Add(new SqlParameter("@password", password));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    customer = new Customer
                    {
                        ID = Convert.ToInt32(reader[0].ToString()),
                        UserName = reader[1].ToString(),
                        Password = reader[2].ToString(),
                        FirstName = reader[3].ToString(),
                        LastName = reader[4].ToString(),
                        Email = reader[5].ToString(),
                        PhoneNumber = reader[6].ToString()
                    };
                }
                reader.Close();
            }
            return customer;
        }
    }
}
