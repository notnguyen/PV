using Microsoft.Data.SqlClient;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace _20240216
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder consStringBuilder = new SqlConnectionStringBuilder();
            consStringBuilder.UserID = "sa"; //prihlasovaci jmeno
            consStringBuilder.Password = "student"; //heslo
            consStringBuilder.InitialCatalog = "prekladac"; //jmeno databaze
            consStringBuilder.DataSource = "PC980"; //XXX je cislo vaseho PC ve skole
            consStringBuilder.ConnectTimeout = 30;
            try
            {
                using (SqlConnection connection = new SqlConnection(consStringBuilder.ConnectionString))
                {
                    connection.Open();
                    Console.WriteLine("Pripojeno");
                    /*

                V kodu se pracuje s tabulkou
                    create table Tabulka (id int identity(1,1) primary key, text varchar(20) not null);

                    */
                    string query = "create table Tabulka (id int identity(1,1) primary key, text varchar(20) not null);";
                    SqlCommand command3 = new SqlCommand(query, connection);
                    command3.ExecuteNonQuery();


                    //vlozeni radku do tabulky
                    query = "insert into Tabulka (text) values ('Ahoj')";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();

                    //nacteni dat z tabulky
                    query = "select * from Tabulka";
                    SqlCommand command2 = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString());
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}