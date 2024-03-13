using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVDatabaseProject
{
    internal class PaymentDao : IRepository<Payment>
    {
        public void Add(Payment entity)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("INSERT INTO Platby (ID_Objednavky, Castka, Datum_Platby) VALUES (@orderId, @amount, @paymentDate)", conn))
            {
                command.Parameters.Add(new SqlParameter("@orderId", entity.OrderID));
                command.Parameters.Add(new SqlParameter("@amount", entity.Amount));
                command.Parameters.Add(new SqlParameter("@paymentDate", entity.PaymentDate));

                command.ExecuteNonQuery();
                command.CommandText = "Select @@Identity";
                entity.PayemntId = Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public void Delete(int id)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("Delete FROM Platby where id = @id", conn))
            {
                command.Parameters.Add("@id", (System.Data.SqlDbType)id);
                command.ExecuteNonQuery();
                id = 0;
            }
        }

        public IEnumerable<Payment> GetAll()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Platby", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Payment payment = new Payment
                    {
                        OrderID = Convert.ToInt32(reader[0].ToString()),
                        Amount = Convert.ToInt32(reader[1].ToString()),
                        PaymentDate = reader[2].ToString()
                    };
                    yield return payment;
                }
                reader.Close();
            }
        }

        public Payment GetById(int id)
        {
            Payment payment = null;
            SqlConnection conn = DatabaseSingleton.GetInstance();


            using (SqlCommand command = new SqlCommand("SELECT * FROM Platby WHERE id = @Id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    payment = new Payment
                    {
                        PayemntId = Convert.ToInt32(reader[0].ToString()),
                        OrderID = Convert.ToInt32(reader[1].ToString()),
                        Amount = Convert.ToInt32(reader[2].ToString()),
                        PaymentDate = reader[3].ToString()
                    };
                }
                reader.Close();
                return payment;
            }
        }

        public void Update(Payment entity)
        {
            throw new NotImplementedException();
        }
    }
}
