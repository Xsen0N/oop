using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Collections.Concurrent;

namespace OOP_Lab15
{
    partial class Program
    {
        public static BlockingCollection<string> MyBlock;
        public static void AddProduct()
        {
            Random r = new Random();
            int x;
            List<string> products = new List<string>() { "Торт", "Конфеты", "Пирог", "Штрудель", "Кексы" };
            for (int i = 0; i < 5; i++)
            {
                x = r.Next(0, products.Count - 1);
                Console.WriteLine("Добавлен товар: " + products[x]);
                MyBlock.Add(products[x]);
                products.RemoveAt(x);
                Thread.Sleep(r.Next(1, 3));
            }
            MyBlock.CompleteAdding();
        }
        public static void PurchasedProduct()
        {
            string str;
            while (MyBlock.IsAddingCompleted == false)
            {
                if (MyBlock.TryTake(out str) == true)
                    Console.WriteLine("Был куплен товар: " + str);
                if (MyBlock.TryTake(out str) != true)
                    Console.WriteLine("Покупатель ушел.");
            }
        }

    }
}
