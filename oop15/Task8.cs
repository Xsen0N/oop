using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab15
{
    partial class Program
    {
        public static void ForAsync()
        {
            for (int i = 0; i < 30; i++)
                if (i % 2 == 0)
                {
                    Console.Write(i + ", ");
                    Thread.Sleep(1000);
                }
        }
        public static async void Async()
        {
            Console.WriteLine("Async Function:");
            await Task.Run(() => ForAsync());
            Console.WriteLine("Все хорошо");
        }
    }
}
