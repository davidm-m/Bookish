using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Bookish.DataAccess
{
    public class DataAccessor
    {
        public SqlConnection db { get; set; }

        public DataAccessor()
        {
            db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        private List<T> Query<T>(string sqlString)
        {
            return db.Query<T>(sqlString).ToList();
        }

        public List<Book> GetBooks()
        {
            var sqlString = "SELECT * FROM [Book];";
            return Query<Book>(sqlString);
        }

        public List<Author> GetAuthors()
        {
            var sqlString = "SELECT * FROM [Author];";
            return Query<Author>(sqlString);
        }

        public List<CheckedOut> GetCheckedOutByUser(int userId)
        {
            var sqlString = $"SELECT * FROM [CheckedOut] WHERE User = {userId};";
            return Query<CheckedOut>(sqlString);
        }

        public List<Book> GetBooksCheckedOutByUser(int userId)
        {
            var sqlString = $"SELECT * FROM [Book] INNER JOIN Copy ON Book.BookID=Copy.Book INNER JOIN CheckedOut ON Copy.CopyID=CheckedOut.Copy WHERE CheckedOut.UserID={userId};";
            return Query<Book>(sqlString);
        }

        public List<Author> GetAuthorByBook(int bookId)
        {
            var sqlString = $"SELECT * FROM [Author] INNER JOIN Book ON Book.Author=Author.AuthorID WHERE BookID={bookId};";
            return Query<Author>(sqlString);
        }
    }
}
