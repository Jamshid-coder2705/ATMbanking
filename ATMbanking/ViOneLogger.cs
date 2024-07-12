using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMbanking
{
    internal class ViOneLogger : LoggerIn
    {
        internal override void Info(string message)
        {
            Console.WriteLine(message);

        }
    }
}
