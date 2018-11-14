using System;

namespace Bookish.DataAccess
{
    public class CheckedOut
    {
        public int UserID { get; set; }
        public int Copy { get; set; }
        public DateTime Due { get; set; }
    }
}