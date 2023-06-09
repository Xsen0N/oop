using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Logger
    {
        public static string path = @"D:\additional\ооп\Lab2\Lab2\bin\Debug\logfile.txt";
        public static void Write(string action)
        {
            DateTime DateNow = DateTime.Now;
            using (StreamWriter sw = new StreamWriter(path, true, Encoding.UTF8))
            {
                sw.WriteLine(action);
                sw.WriteLine("------------------------------------------");
            }
        }
    }
}
