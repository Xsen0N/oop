using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_4
{
    public static class Controler
    {
        public static void FindLife(Laboratory laboratory, int limit)
        {
            int count = 0;
            Console.Write("Техника старше заданного срока службы:");
            foreach (Technique t in laboratory.List)
            {
                if (t.lifespan > limit)
                {
                    Console.Write(t.Name + " "+ t.lifespan + " ");
                    count++;
                }
            }
            Console.Write($"Количество: {count}");
        }

        public static void CountTech(Laboratory laboratory)
        {
            int com = 0;
            int tab = 0;
            int work = 0;
            int print = 0;
            int scan = 0;
            foreach (Technique t in laboratory.List) { 
            if (t.Name == "Принтер") print++;
            if (t.Name == "Компьютер") com++;
            if (t.Name == "Рабочая станция") work++;
            if (t.Name == "Планшет") tab++;
            if (t.Name == "Сканер") scan++;
            }
            Console.WriteLine($"Количество принтеров: {print}, компьютеров: {com}, рабочих станций: {work}, планшетов: {tab}, сканеров: {scan}");
        }
        public static int Sort(Laboratory laboratory)
        {
            var sortedTechnique = from Technique p in laboratory.List
                                orderby p.cost descending
                                select p;
            foreach (Technique i in sortedTechnique)
                Console.Write(i.Name + " " + i.cost + " ");
            return 0;

        }
    }
}
