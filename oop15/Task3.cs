using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab15
{
    partial class Program
    {
        public static int Sum()
        {
            Random rndm = new Random();
            return rndm.Next(1, 10)+ rndm.Next(1, 10);
        }

        public static int Mult()
        {
            Random rndm = new Random();
            return rndm.Next(1, 10) * rndm.Next(1, 10);
        }

        public static int Diff()
        {
            Random rndm = new Random();
            return rndm.Next(10, 20) - rndm.Next(1, 10);
        }

        public static int Formula(int x, int y, int z)
        {
            return (x + y + z) *2 + 1;
        }
        
    }
}
