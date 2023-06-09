using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract
{
    public class AgeExep : ArgumentException
    {
        public int value { get; }
        public AgeExep(string message, int val) : base(message) { 
        value = val;
        }
    }
    public class Number : Exception {
        public Number(string message) : base(message) { }
    }
}
