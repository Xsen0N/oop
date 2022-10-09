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
        static void Main(string[] args)
        {
            Technique technique = new MyPrinter("Принтер");
            Technique technique1 = new Computer("Компьютер");
            IProduct product = new Scanner();
            Scanner scanner = new Scanner();
            Computer computer = new Workstation("Рабочая станция");
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
            MyPrinter printer = new MyPrinter("Принтер хороший");
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
        }
    }
}