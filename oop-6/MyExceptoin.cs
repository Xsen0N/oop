using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_4
{
    public class MyExceptoin : Exception
    {
        public MyExceptoin(string message)
            : base(message) { }
    }
    public class Lies : Exception
    {
        public Lies(string message)
            : base(message) { }
    }
    public class CostExceptoin : ArgumentException
    {
        public double Value { get; }
        public CostExceptoin(string message, double val)
            : base(message) {
            Value = val;
        }
    }
    public class NameExceptoin : ArgumentException
    {
        public string? NameElem { get; }
        public NameExceptoin(string message, string val) 
            : base(message) {
            NameElem = val;
        }
    }
    public class NullElemNameExceptoin : NullReferenceException
    {
        public NullElemNameExceptoin(string message)
            : base(message)
        {
        }
    }

}
