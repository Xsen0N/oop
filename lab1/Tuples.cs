using System;

namespace tuples
{
    class Tuples
    {
        static void Main(string[] args)
        {
            (int, string, char, string, ulong) tuple1 = (18, "Ксения", 'ж', "Жук", 2003);
            Console.Write(tuple1.Item1 + " " + tuple1.Item2 + " " + tuple1.Item3 + " " + tuple1.Item4 + " " + tuple1.Item5 + "\n");

            Console.Write(tuple1.Item1 + " " + tuple1.Item3 + " " + tuple1.Item5);

            (var ar, var br) = ("2003", 1898);
            Console.WriteLine($"\n{ar} {br}" + "\n");
            var _ = tuple1.Item1;
            Console.WriteLine(_);

            var First = (ar, br);
            var Second = (ar, br);
            
            Console.WriteLine(First == Second);
        }
    }
}
