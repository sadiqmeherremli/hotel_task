using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_task
{
    public class NotAvailableException : Exception
    {
        public NotAvailableException() : base("Otaq movcud deyil veya rezervasiya olunub") { }
    }

    public class MissingInfoException : Exception
    {
        public MissingInfoException(string message) : base(message) { }
    }
}
