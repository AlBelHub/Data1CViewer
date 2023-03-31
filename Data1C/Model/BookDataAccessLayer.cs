using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Mozilla;
using static System.Reflection.Metadata.BlobBuilder;
using System.Reflection.PortableExecutable;

namespace Data1C.Model
{
    public class BookDataAccessLayer
    {
        List<Book> books = new List<Book>();
        MySqlConnection conn = new MySqlConnection();

        /// <summary>
        /// Get all books in library (where 0 - ALL)
        /// </summary>
        public IEnumerable<Book> GetAllBooks()
        {

            MySqlDataReader reader = GetReader();

            while (reader.Read())
            {
                AddBook(reader, books);
            }

            conn.Close();

            return books;

        }


        public IList<Book> GetRange(IEnumerable<Book> books, int limit)
        {

            List<Book> interm = new List<Book>(books);
            
            if (limit == 0 || limit > interm.Count)
            {
                limit = interm.Count;
            }

            return interm.GetRange(0, limit);
        }
        private MySqlDataReader GetReader()
        {
            conn.ConnectionString = new DBUtils().ConString;
            MySqlCommand cmd = new MySqlCommand("GetAllRecords", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        private void AddBook(MySqlDataReader reader, List<Book> books)
        {
            reader.Read();
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


        /// <summary>
        /// Create
        /// </summary>

        public void CreateBook(Book book)
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
    }
}
