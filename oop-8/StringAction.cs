using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_8
{
    public delegate void StrAct(string text);

    public class StringAction
    {
        public static void Lower(string str)
        {
            Console.WriteLine(str.ToLower());
        }

        public static void Upper(string str)
        {
            Console.WriteLine(str.ToUpper());
        }

        public static string Reverse(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return (new string(charArray));
        }

        public static void Remove(string str)
        {
            Console.WriteLine(str.Remove(0, 2));
        }
        public static string RemoveEleminstr(string str)
        {
            return str.Remove(0, 2);
        }

        public static void Insert(string str)
        {
            Console.WriteLine(str.Insert(str.Length, "@"));
        }
    }
}
