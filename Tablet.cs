using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static oop_4.MyPrinter;

namespace oop_4
{
    public partial class Tablet 
    {
        public override int GetHashCode()
        {
            return base.GetHashCode() + 1000;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            if (obj is Computer computer) return true;
            return false;
        }

    }
}
