using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace oop
{
    public partial class Set
    {

        public class Production
        {
            public string Organization { get; set; }
            public readonly int Id;

            public Production()
            {
                Id = GetHashCode();
                Organization = "Организация";
            }
        }

        public class Developer
        {
            public string FIO { get; set; }
            public readonly int Id;
            public string department;

            public Developer()
            {
                Id = GetHashCode();
                FIO = "Светлова Света Святославовна";
                department = "Тестирования";
            }
        }

        public static class StatisticOperation
        {
            public static int Sum(Set set1)
            {
                return set1.List.Max() + set1.List.Min();
            }

            public static int Difference(Set set1)
            {
                return set1.List.Max() - set1.List.Min();
            }

            public static int Length(Set set1)
            {
                return set1.List.Count();
            }

            public static string FindTheShortestWord(string str)
            {
                string[] words = str.Split(' ');
                string MinLength = "111111111"; 
                for (int i = 0; i < words.Length; i++)
                    if (words[i].Length < MinLength.Length)
                        MinLength = words[i];
                return MinLength;
            }
            public static int SortNums(Set set)
            {
                var orderedNumbers = from i in set.List
                                     orderby i
                                     select i;
                foreach (int i in orderedNumbers)
                    Console.Write(i + " ");
                return 0;
            }
        }
    }
}
