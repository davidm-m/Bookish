using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

        public List<Book> GetBooks()
        {
            var sqlString = "SELECT TOP 100 * FROM [Book]";
            return db.Query<Book>(sqlString).ToList();
        }
    }
}
