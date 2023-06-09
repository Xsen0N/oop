using System;
using System.Linq; //LINQ (Language-Integrated Query) представляет простой и удобный язык запросов к источнику данных.

namespace Local_fun
{
    class Local_fun
    {
        static void Main(string[] args)
        {
            (int, int, int, char) localFun(int[] mass, string st)
            {
                int max = mass.Max();
                int min = mass.Min();
                int sum = mass.Sum();
                char sim = st.First();
                return (max, min, sum, sim);
            }
            int[] mass = { 115, 2, 3, 4, 5 };
            string st = "Hello, World";
            Console.WriteLine(localFun(mass, st));
        }
    }
}
