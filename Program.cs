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
        enum Deskstop { 
        monitor,
        keyboard,
        mouse,
        computerCase,
        microphone,
        speaker
        }
        static void Main(string[] args)
        {
            Technique technique = new MyPrinter("Принтер", cost: 1500, 3);
            Technique technique1 = new Computer("Компьютер", 20000, 36);
            IProduct product = new Scanner("Сканер", lifespan: 6, cost: 600);
            Scanner scanner = new Scanner("Сканер",980, 3 );
            Computer computer = new Workstation("Рабочая станция", 78000, 200 );
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
            if (printer is Technique )
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
            for (int i = 0; i < products.Length; i++)
            {
                printer1.IAmPrinting( products[i]);

            }
            Iron iron = new Iron();
            Tablet tablet = new Tablet();
            iron.model = "Philips";
            iron.instruction();
            //----------------------------------------//
            Laboratory laboratories = new Laboratory(new List<object>( ){ technique1, technique, printer, computer });
            Console.WriteLine("Введите срок службы ");
            int limit = Convert.ToInt32(Console.ReadLine());
            
            Controler.FindLife(laboratories, limit);
            Console.WriteLine();
            Controler.CountTech(laboratories);
            Controler.Sort(laboratories);
        }

    }
}