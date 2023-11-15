using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumeratorsOperatorOverloading_B
{
    static class Program
    {
        public static void Main()
        {
            Money M1 = new Money(1000000, CurrencyUnit.Euro);
            Money M2 = new Money(32000000000, CurrencyUnit.Euro);

            Money M3 = M2 + M1;

            Console.WriteLine(M3);
            Money M4 = M3 + (new Money(48000000000, CurrencyUnit.Dollar));
            Console.WriteLine(M4);
        }
    }
}
