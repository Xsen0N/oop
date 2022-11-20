using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_4
{
    public class Printer
    {
         public void IAmPrinting(Object someobj) {
            Console.WriteLine( someobj.GetType());
            Console.WriteLine(someobj.ToString());
        }
    }
}
