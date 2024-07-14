using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMbanking
{
    public class VTwoLogger : ILoggerIn
    {
        public void LogIn(string message)
        {
            Console.WriteLine(message);
        }
    }
}
