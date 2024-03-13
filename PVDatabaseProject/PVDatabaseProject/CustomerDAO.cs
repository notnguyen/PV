using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PVDatabaseProject
{
    internal class CustomerDAO : IRepository<Customer>
    {
        public void Add(Customer entity)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("Delete FROM Zakaznik where id = @id", conn))
            {
                command.Parameters.Add("@id", (System.Data.SqlDbType)entity.CustomerId);
                command.ExecuteNonQuery();
                entity.CustomerId = 0;
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
