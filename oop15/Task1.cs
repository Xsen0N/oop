using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace OOP_Lab15
{
    partial class Program
    { 
        public static Task task1;
        public static void SieveOfEratosthenes()
        {
            int N = 1000;
            WriteLine("Текущий ID: " + Task.CurrentId.ToString());
            List<int> numbers = new List<int>();
            for (int i = 2; i < N; i++)
            {
                numbers.Add(i);
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                 for (int j = 2; j < N; j ++)
                 {
                    numbers.Remove(numbers[i] * j);
                }
                
            }
            
            WriteLine("Простые числа до " + N + ":");
                
            foreach (int a in numbers)
            {
                WriteLine(a);
            }

        }

    }
}
