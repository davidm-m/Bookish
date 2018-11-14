using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookish.DataAccess;

namespace Bookish.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataAccessor = new DataAccessor();
            var books = dataAccessor.GetBooks();
            foreach (var book in books)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
