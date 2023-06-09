using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using static oop.Set;
using oop;

namespace oop
{
    class Program
    {

        public static string AboutOrg(Production production)
        {
            return $"Объект: ID: {production.Id}, название организации: {production.Organization}";
        }

        public static string AboutDev(Developer developer)
        {
            return $"Объект: ID: {developer.Id}, фио: {developer.FIO}, отдел: {developer.department}";

        }
        static void Main(string[] args)
        {
            SetTest();
            var setEx = new Set(new List<int>() { 7, 8, 3, 5, 9, 1, 2 });
            var nullSet = new Set(new List<int>() { 0, 1, 0, 3, 8 });
            Console.WriteLine("Множество 1: ");
            foreach (var i in setEx.List)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\nМножество 2: ");
            foreach (var i in nullSet.List)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            string str = "Сегодня невероятно хорошая погода, жаль что солнце слабо греет";
            Console.WriteLine($"Строка: {str}" );
            Production Goodobj = new Production();
            Console.WriteLine(value: AboutOrg(Goodobj));
            Developer developer = new Developer();
            Console.WriteLine(value: AboutDev(developer));
            Console.WriteLine($"Сумма максимального и минимального элемента множества = {StatisticOperation.Sum(setEx)}");
            Console.WriteLine($"Разница между максимальным и минимальным элементом множества = {StatisticOperation.Difference(setEx)}");
            Console.WriteLine($"Количество элементов множества: {StatisticOperation.Length(setEx)}");           
            Console.WriteLine($"Поиск самого короткого слова:\n{StatisticOperation.FindTheShortestWord(str)}");
            Console.Write("Множество: ");
            foreach (var i in setEx.List)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\nУпорядоченное множество");
            var resSet = StatisticOperation.SortNums(setEx);
        }
    }
}
