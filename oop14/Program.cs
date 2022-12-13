using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace lab14
{
    public class Program
    {
        static  string locker = "null";
        static void DomainInfo(AppDomain domain)
        {
            Console.WriteLine("Информация о домене");
            Console.WriteLine($"Имя: {domain.FriendlyName}\n ID: {domain.Id}\n По умолчанию {domain.IsDefaultAppDomain()}\nПуть: {domain.BaseDirectory}\n");
            Assembly[] assemblies = domain.GetAssemblies();
            Console.WriteLine("Все сборки: ");
            Assembly buf = null;
            foreach (Assembly asm in assemblies) { 
                Console.WriteLine(asm.GetName().Name);
                if (asm.GetName().Name == "lab14")
                    buf = asm;
            }    
        }

        static void Main(string[] args)
        {
            Process current = Process.GetCurrentProcess();
            Console.WriteLine($"Id: {current.Id}, Name: {current.ProcessName}, Priority: {current.BasePriority} , Size:{current.VirtualMemorySize64}, Start Time:{current.StartTime},Processor Time:{current.TotalProcessorTime}");
            //----------------
            AppDomain domain = AppDomain.CurrentDomain;
            DomainInfo(domain);
            Console.WriteLine("Создание нового домена ");
            //AppDomain newD = AppDomain.CreateDomain("MyNewAppDomain");
            //AppDomain.Unload(newD);
            //DomainInfo(newD);
            Console.WriteLine("Enter a number");
            int num = Convert.ToInt32(Console.ReadLine());
            Thread myThread = new Thread(CountNums);
            myThread.Name = "Новый поток";
            myThread.Priority = ThreadPriority.Highest;
            myThread.Start(num);
            myThread.Join();
            //------------------
            Console.WriteLine("------------");
            Thread th1 = new Thread(CountOddNums) { Name = "OddNumThread", };//нечет
            Thread th2 = new Thread(CountEvenNums) { Name = "EvenNumThread", }; // чет
            th2.Start(num);
            th1.Start(num);
            th2.Join();
            th1.Join();
            Console.WriteLine("------------");
            File.WriteAllText("Task4bii.txt", " ");
            Thread th3 = new Thread(OddNums) { Name = "OddNumThread1", };
            Thread th4 = new Thread(EvenNums) { Name = "EvenNumThread1", }; 
            th3.Start(num);
            th4.Start(num);
            th3.Join();
            th4.Join();
            Console.WriteLine("------------");
            int numb = 0;
            TimerCallback tm = new TimerCallback(Count);
            Timer timer = new Timer(tm, numb, 0, 1000);
            Console.WriteLine("Который час?");
            Console.ReadLine();
        }
        public static void Count(object obj)
        {
            Console.WriteLine(" Время:  " + DateTime.Now.ToLongTimeString());
        }
        public static bool IsPrime(int number)
        {
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
        public static void CountNums(object obj) {
            using (StreamWriter writer = new StreamWriter("Lab14.txt", false))
            {
                writer.WriteLine("Простые числа");
            }
            Console.WriteLine("Имя потока: " + Thread.CurrentThread.Name);
            Console.WriteLine("Приоритет потока: " + Thread.CurrentThread.Priority.ToString());
            Console.WriteLine("Id потока: " + Thread.CurrentThread.ManagedThreadId.ToString());
            Console.WriteLine("Статус потока: " + Thread.CurrentThread.ThreadState.ToString());
            if (obj is int n)
            {
                for (int i = 1; i < n; i++)
                {
                    if (IsPrime(i)) {
                        Console.WriteLine(i);
                        using (StreamWriter writer = new StreamWriter("Lab14.txt", true))
                        {
                            writer.WriteLine(i);
                            writer.Close();
                        }
                    }
                }
            }

        }
        public static void CountOddNums(object obj)
        {
            lock (locker) {
                if (obj is int n)
            {
                for (int i = 0; i < n; i++)
                {
                    if (i % 2 == 1)
                    {
                        Thread.Sleep(600);
                        Console.WriteLine(i);
                        using (StreamWriter writer1 = new StreamWriter("Task4.txt", true))
                        {
                            writer1.WriteLine(i);
                        }
                    }
                }
            }
             }

        }
        public static void CountEvenNums(object obj)
        {
            using (StreamWriter writer1 = new StreamWriter("Task4.txt", false))
            {
                writer1.WriteLine("Задание 3");
            }

            if (obj is int n)
            {
                    for (int i = 0; i < n; i++)
                    {
                        if (i % 2 == 0)
                        {
                        try { 
                        using (StreamWriter writer = new StreamWriter("Task4.txt", true))
                        {
                            writer.WriteLine(i);
                        }
                        }
                        catch (Exception) { }
                        Console.WriteLine(i);
                        }
                    }
            }         

        }
        //-----------------------------
        public static void OddNums(object obj)
        {
            try
            {
                Monitor.Enter(locker);
                {
                    if (obj is int n)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            if (i % 2 == 0)
                            {
                                Console.WriteLine(i);

                                    using (StreamWriter writer = new StreamWriter("Task4bii.txt", true))
                                    {
                                        writer.WriteLine(i);
                                    }
                                
                            }
                        }
                    }

                }
            }
            finally
            {
                Monitor.Exit(locker);
            }

        }
        //-------------- 
        public static void EvenNums(object obj)
        {

            if (obj is int n)
            {
                for (int i = 0; i < n; i++)
                {
                    if (i % 2 == 1)
                    {
                        Console.WriteLine(i);
                        try
                        {
                            File.AppendAllText("Task4bii.txt", $"{i} \n");
                        }
                        catch (Exception) { }
                    }
                }
            }

        }


    }
}