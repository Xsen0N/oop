using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using static oop_4.MyPrinter;

namespace oop_4
{
    class Program
    {
        enum Deskstop
        {
            monitor,
            keyboard,
            mouse,
            computerCase,
            microphone,
            speaker
        }
        static void Main(string[] args)
        {
            Deskstop part = Deskstop.monitor;
            Console.WriteLine((int)part);
            Console.WriteLine((int)Deskstop.microphone);
            Technique technique = new MyPrinter("Принтер", cost: 1500, 3);
            Technique technique1 = new Computer("Компьютер", 20000, 36);
            IProduct product = new Scanner("Сканер", lifespan: 6, cost: 600);
            Scanner scanner = new Scanner("Сканер", 980, 3);
            Computer computer = new Workstation("Рабочая станция", 78000, 200);
            technique.Power();
            ((IProduct)product).Quality();
            technique.Quality();
            ((IProduct)technique).Quality();
            Computer? newcomputer = technique as Computer;
            if (newcomputer == null)
            {
                Console.WriteLine("Преобразование прошло неудачно");
            }
            else
            {
                Console.WriteLine("Преобразование прошло удачно");
            }
            MyPrinter printer = new MyPrinter("Принтер", cost: 8900, 10);
            if (printer is Technique)
            {
                Console.WriteLine(printer.Name);
            }
            object[] products = new object[6];
            products[0] = technique;
            products[1] = technique1;
            products[2] = product;
            products[3] = computer;
            products[4] = scanner;
            products[5] = printer;
            Printer printer1 = new Printer();
            //for (int i = 0; i < products.Length; i++)
            //{
            //    printer1.IAmPrinting(products[i]);

            //}
            Iron iron = new Iron();
            Tablet tablet = new Tablet();
            iron.model = "Philips";
            iron.instruction();
            //----------------------------------------//
            Laboratory laboratories = new Laboratory(new List<object>() { technique1, technique, printer, computer });
            Console.WriteLine("Введите срок службы ");
            int limit = 17;

            Controler.FindLife(laboratories, limit);
            Console.WriteLine();
            Controler.CountTech(laboratories);
            Controler.Sort(laboratories);
            //--------------------------
            Iron iron1 = new Iron();
            try
            {
                iron1.model = "Samsuni";
            }
            catch (Lies ex)
            {
                Console.WriteLine($"\nОшибка: {ex.Message}");
            }

            try
            {
                Scanner Scan = new Scanner("Сканер", cost: 1500, 3);
                Scan.Name = "Принтер";
            }
            catch (NameExceptoin ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine($"Некорректное значение: {ex.NameElem}");
                throw;
            }
            finally
            {
                Console.WriteLine("Конец!");
            }
            try
            {
                Scanner product1 = new Scanner("Сканер", lifespan: 800, cost: 600);
                ((IProduct)product1).ProductCost(-969669);

            }
            catch (CostExceptoin ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine($"Некорректное значение: {ex.Value}");
            }
            try
            {
                iron1.CostEl = 150000;
            }
            catch (CostExceptoin ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine($"Некорректное значение: {ex.Value}");
            }

            try
            {
                int a = 10;
                int f = 0;
                try {
                    int[] w = new int[4];
                    w[10] = 1;
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine(e.StackTrace);
                }
                int res = a / f;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                int[] a = new int[4];
                a[7] = 1;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.HelpLink);
                Console.WriteLine(e.TargetSite);
            }
            finally
            {
                Console.WriteLine("Конец!");
            }
            try
            {
                int[] s = new int[4];
                s[7] = 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}