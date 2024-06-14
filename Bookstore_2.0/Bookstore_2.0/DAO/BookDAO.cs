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
    public class BookDAO : IDAO<Book>
    {
        public void Add(Book book)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("INSERT INTO Book VALUES (@title, @author, @genre, @pages)", connection))
            {
                command.Parameters.Add(new SqlParameter("@title", book.Title));
                command.Parameters.Add(new SqlParameter("@author", book.Author));
                command.Parameters.Add(new SqlParameter("@genre", book.Genre));
                command.Parameters.Add(new SqlParameter("@pages", book.Pages));
                command.ExecuteNonQuery();
                Console.WriteLine("Book added");

                command.CommandText = "Select @@Identity";
                book.ID = Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public void Delete(int id)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();
            SqlCommand command = null;

            using (command = new SqlCommand("SELECT * FROM Book WHERE id = @bookID", connection))
            {
                command.Parameters.AddWithValue("@bookID", id);
            }

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine("Book is being removed");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                    return;
                }
            }

            SqlCommand deleteCommand = null;
            using (deleteCommand = new SqlCommand("DELETE FROM Book WHERE id = @ID", connection))
            {
                deleteCommand.Parameters.AddWithValue("@ID", id);
                deleteCommand.ExecuteNonQuery();
            }

            Console.WriteLine("Book successfully removed");
        }

        public void DeleteAll()
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using SqlCommand command = new SqlCommand("DELETE FROM Book", connection);
            command.ExecuteNonQuery();
        }

        public IEnumerable<Book> GetAll()
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Book", connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Book book = new Book
                    {
                        ID = Convert.ToInt32(reader[0].ToString()),
                        Title = reader[1].ToString(),
                        Author = reader[2].ToString(),
                        Genre = reader[3].ToString(),
                        Pages = Convert.ToInt32(reader[4].ToString())
                    };
                    yield return book;
                }
                reader.Close();
            }
        }

        public Book? GetById(int id)
        {
            Book book = null;
            SqlConnection connection = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Book WHERE id = @ID", connection))
            {
                command.Parameters.Add(new SqlParameter("@ID", id));

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    book = new Book
                    {
                        ID = Convert.ToInt32(reader[0].ToString()),
                        Title = reader[1].ToString(),
                        Author = reader[2].ToString(),
                        Genre = reader[3].ToString(),
                        Pages = Convert.ToInt32(reader[4].ToString())
                    };
                }
                reader.Close();
                return book;
            }
        }

        public void Update(Book book)
        {
            SqlConnection connection = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("UPDATE Book SET title = @title, author = @author, genre = @genre, pages = @pages" + "WHERE id = @ID", connection))
            {
                command.Parameters.Add(new SqlParameter("@ID", book.ID));
                command.Parameters.Add(new SqlParameter("@title", book.Title));
                command.Parameters.Add(new SqlParameter("@author", book.Author));
                command.Parameters.Add(new SqlParameter("@genre", book.Genre));
                command.Parameters.Add(new SqlParameter("@pages", book.Pages));
                command.ExecuteNonQuery();
            }
        }
    }
}
