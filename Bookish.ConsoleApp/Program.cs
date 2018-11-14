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
            var authors = dataAccessor.GetAuthorByBook(1);
            foreach (var author in authors)
            {
                Console.WriteLine(author.Name);
            }

            Console.ReadLine();
        }
    }
}
