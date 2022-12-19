using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using static System.Console;


namespace OOP_Lab15
{
    partial class Program
    {
        static void Main(string[] args)
        {
            WriteLine("-------------------------------------------");
            Action action1 = new Action(SieveOfEratosthenes);
            Stopwatch watch = Stopwatch.StartNew();
            task1 = Task.Factory.StartNew(action1);
            task1.Wait();
            task1.Dispose();
            watch.Stop();

            WriteLine($"Таск №1 выполнен: " + task1.IsCompleted.ToString());
            WriteLine("Статус таска: " + task1.Status.ToString());
            WriteLine("Время выполнения для таска: " + watch.Elapsed);

            WriteLine("-------------------------------------------");
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            (task1 = new Task(action1, tokenSource.Token)).Start();
            tokenSource.Cancel();

            Console.WriteLine($"Статус таска: {task1.Status}");
            WriteLine("Токен отмены сработал!");
            WriteLine("-------------------------------------------");

            Task<int> rand1 = new Task<int>(Sum),
                      rand2 = new Task<int>(Mult),
                      rand3 = new Task<int>(Diff);

            rand1.Start();
            WriteLine($"Первое значение: {rand1.Result}");
            
            rand2.Start();
            WriteLine($"Второе значение: {rand2.Result}");
            
            rand3.Start();
            WriteLine($"Третье значение: {rand3.Result}");

            Task<int> result = new Task<int>(() => Formula(rand1.Result, rand2.Result, rand3.Result));
            result.Start();
            WriteLine($"Итоговое значение: {result.Result}");
            WriteLine("-------------------------------------------");
            
            //Таск продолжения:

            Task<int> con1 = new Task<int>(Sum);
            Task<int> con2 = con1.ContinueWith((task) => Mult());
            Task<int> con3 = con2.ContinueWith((task) => Diff());
            Task<int> con4 = con3.ContinueWith((task) => Formula(con1.Result, con2.Result, con3.Result));
            con1.Start();

            WriteLine($"Первое значение: {con1.Result}");
            WriteLine($"Второе значение: {con2.Result}");
            WriteLine($"Третье значение: {con3.Result}");
            WriteLine($"Итоговое значение: {con4.Result}");
            
            con1.Dispose();
            con2.Dispose();
            con3.Dispose();
            con4.Dispose();

            Task<int> wait = Task.Run(() => Enumerable.Range(1, 10000).Count(n => (n % 3 == 0)));
            TaskAwaiter<int> awaiter = wait.GetAwaiter();
            awaiter.OnCompleted(() => { int res = awaiter.GetResult(); WriteLine(res); });
            WriteLine(awaiter.GetResult());
            WriteLine("-------------------------------------------");

            Stopwatch watch2 = Stopwatch.StartNew();
            int[] arr1 = new int[1000000];
            int[] arr2 = new int[1000000];
            Random random = new Random();
            watch2.Restart();

            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = random.Next(0, 100);
                arr2[i] = random.Next(0, 100);
            }

            watch2.Stop();
            WriteLine($"Время заполнения массивов через For: {watch2.Elapsed}");


            watch2.Restart();

            Parallel.For(0, arr1.Length, i =>
            { 
                arr1[i] = random.Next(0, 100); arr2[i] = random.Next(0, 100);
            });

            watch2.Stop();

            WriteLine($"Время заполнения массивов через параллельный For: {watch2.Elapsed}");

            watch2.Restart();

            Parallel.ForEach<int>(arr1, (i) =>
            { 
                arr1[i] = random.Next(0, 100); arr2[i] = random.Next(0, 100); 
            });
            watch2.Stop();
            WriteLine($"Время заполнения массивов через параллельный ForEach: {watch2.Elapsed}");

            Parallel.Invoke(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    WriteLine("Параллельное выполнение блока 1 - " + i);
                }

                WriteLine("1 готов!");
            },
            () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    WriteLine("Параллельное выполнение 2 - " + i);
                }

                WriteLine("2 готов!");
            });
            WriteLine("-------------------------------------------");

            MyBlock = new BlockingCollection<string>(5);
            Task Shop = new Task(AddProduct);
            Task Clients = new Task(PurchasedProduct);
            Shop.Start();
            Clients.Start();
            Shop.Wait();
            Clients.Wait();
            WriteLine("-------------------------------------------");
            Async();
            string p = ReadLine();
            WriteLine(p + p + p + "Enter...");
            ReadKey();


        }
    }
}