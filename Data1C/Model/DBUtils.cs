using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cms;

namespace Data1C.Model
{
    public class DBUtils
    {
        private MySqlConnection conn;

        public string DBname = "Library";
        public string UID = "root";
        public string DBpassword = "Pisacu1318!";
        public string ServerAddr = "127.0.0.1";
        public string ConString = string.Empty;

        public DBUtils(string DBname,string UID, string DBpassword, string ServerAddr)
        {

            MySqlConnectionStringBuilder settings = new MySqlConnectionStringBuilder()
            {
                Server = ServerAddr,
                UserID = UID,
                Password = DBpassword,
                Database = DBname,
                Port = 3306,
                DefaultAuthenticationPlugin = "authentication_kerberos_client"
            };

            conn = new MySqlConnection();
            conn.ConnectionString = settings.ConnectionString;
        }

        /// <summary>
        /// Подготовка данных для отправки в БД
        /// </summary>

        public void AddData(string DBName, List<Book> BookList)
        {

            DataTable table = new DataTable();

            table = GetDataTableLayout("books");

            foreach (Book book in BookList)
            {
                DataRow row = table.NewRow();
                row["BookCode"] = book.BookCode;
                row["BookDescription"] = book.BookDescription;
                row["Author"] = book.Author;
                row["AuthorMark"] = book.AuthorMark;
                row["ProdYear"] = book.ProdYear;
                row["Publisher"] = book.Publisher;
                row["Location"] = book.Location;
                row["DateOfCreation"] = book.DateOfCreation;
                row["DateOfLastChanges"] = book.DateOfLastChanges;
                table.Rows.Add(row);
            }

            BulkInsert(table, DBName);
        }

        /// <summary>
        /// Получение структуры данных в БД
        /// </summary>

        private DataTable GetDataTableLayout(string TableName)
        {
            DataTable dataTable = new DataTable();

            //conn было null
            conn.Open();
            string query = $"SELECT * FROM " + TableName + " limit 0";

            
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;

            MySqlDataAdapter adapter= new MySqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);

            return dataTable;

        }

        /// <summary>
        /// Отправка данных в БД
        /// </summary>

        private void BulkInsert(DataTable table, string DBName) 
        {
            MySqlTransaction transaction = conn.BeginTransaction(IsolationLevel.Serializable);
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            MySqlCommandBuilder builder = new MySqlCommandBuilder(dataAdapter);

            cmd.CommandText = "SELECT * FROM " + "books" + " limit 0";
            dataAdapter.SelectCommand = cmd;
            dataAdapter.SelectCommand.Connection = conn;
            builder.GetInsertCommand();
            cmd.Connection = conn;
            cmd.Transaction = transaction;
            cmd.CommandText = "INSERT INTO " + "books(BookCode,BookDescription,Author,AuthorMark,ProdYear,DateOfLastChanges,DateOfCreation,Publisher,Location)";
            dataAdapter.UpdateBatchSize = 10000;
            builder.SetAllValues = true;
            dataAdapter.Update(table);
            transaction.Commit();
        }

    }
}
