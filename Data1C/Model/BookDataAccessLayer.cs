using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Mozilla;

namespace Data1C.Model
{
    public class BookDataAccessLayer
    {
        /// <summary>
        /// Get all books in library
        /// </summary>
        public IEnumerable<Book> GetAllBooks(int DBlimit)
        {
            List<Book> books = new List<Book>();

            using (MySqlConnection conn = new MySqlConnection())
            {
                conn.ConnectionString = new DBUtils().ConString;

                MySqlCommand cmd = new MySqlCommand("GetAllRecords", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                //for (int i = 0; i< 100; i++)
                //{
                //    reader.Read();
                //    Book book = new Book();
                //    book.BookCode = Convert.ToString(reader["BookCode"]);
                //    book.BookDescription = Convert.ToString(reader["BookDescription"]);
                //    book.Author = Convert.ToString(reader["Author"]);
                //    book.AuthorMark = Convert.ToString(reader["AuthorMark"]);
                //    book.ProdYear = Convert.ToString(reader["ProdYear"]);
                //    book.DateOfLastChanges = Convert.ToDateTime(reader["DateOfLastChanges"]);
                //    book.DateOfCreation = Convert.ToDateTime(reader["DateOfCreation"]);
                //    book.Publisher = Convert.ToString(reader["Publisher"]);
                //    book.Location = Convert.ToString(reader["Location"]);

                //    books.Add(book);
                //}

                //Оставить на потом \ полный вывод БД на страничку

                while (reader.Read())
                {
                    Book book = new Book();
                    book.BookCode = Convert.ToString(reader["BookCode"]);
                    book.BookDescription = Convert.ToString(reader["BookDescription"]);
                    book.Author = Convert.ToString(reader["Author"]);
                    book.AuthorMark = Convert.ToString(reader["AuthorMark"]);
                    book.ProdYear = Convert.ToString(reader["ProdYear"]);
                    book.DateOfLastChanges = Convert.ToDateTime(reader["DateOfLastChanges"]);
                    book.DateOfCreation = Convert.ToDateTime(reader["DateOfCreation"]);
                    book.Publisher = Convert.ToString(reader["Publisher"]);
                    book.Location = Convert.ToString(reader["Location"]);

                    books.Add(book);
                }
                conn.Close();
            };
            return books;
        }

        /// <summary>
        /// Create
        /// </summary>

        public void AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete
        /// </summary>

        public void DeleteBook(int? id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Read
        /// </summary>

        public void ReadBookData()
        {
            throw new NotImplementedException();
        }
    }
}
