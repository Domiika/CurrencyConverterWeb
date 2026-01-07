using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Api
{
    public class CurrencyNotSupported : Exception
    {
        public CurrencyNotSupported(string message) : base(message)
        {
            Console.WriteLine(message);
        }
    }
}
