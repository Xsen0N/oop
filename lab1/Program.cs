using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool correct = true;
            bool uncorrect = false;

            byte bnum = 127;
            sbyte sbnum = -127;

            short snum = -15;
            ushort usnum = 15;

            int inum = -6;
            uint unum = 6;

            long lnum = -789;
            ulong ulnum = 789;

            float fnum = 123.4f;

            double dnum = 456.864;

            decimal denum = 0.485m;

            char a = 'A';

            string hello = "Hello";

            object obj = 456;

            Console.WriteLine(hello);

            Console.WriteLine($"Целое положительное число: {unum}");

            Console.WriteLine($" Трехзначное число {obj}, {dnum}, {ulnum}");

            Console.WriteLine("Число больше 0: {0}  Буква : {2}  Меньше 0 : {1}", bnum, sbnum, a);
            Console.Write("Введите свое любимое блюдо: ");
            string dish = Console.ReadLine();
            Console.WriteLine($"Отлично! {dish} - это вкусно)");
            //part b
            int changable_first = 2147483647;

            long inconspicuous_first = changable_first; //неявное преобразование

            double changable_second = 1234.7;

            int conspicuous_first = (int)changable_second; //явное преобразование

            sbyte changable_third = 125;

            byte conspicuous_second = (byte)changable_third; // явное преобразование

            short changable_fourth = 31767;

            int inconspicuous_second = changable_fourth; // неявное преобразование 

            ushort changable_fifth = 64535;

            int inconspicuous_third = changable_fifth; //неявное преобразование

            uint changable_sixth = 429496295;

            long inconspicuous_fourth = changable_sixth; //неявное преобразование

            long changable_seventh = 9223372036854775807;

            ulong conspicuous_third = (ulong)changable_seventh; // явное преобразование

            byte changable_eight = 25;

            int inconspicuous_fifth = changable_eight; // неявное преобразование

            short changable_nine = 30;

            ushort conspicuous_fourth = (ushort)changable_nine; //явное преобразование

            int changable_ten = 1000;

            uint conspicuous_fifth = (uint)changable_ten; // явное преобразование

            //part c 
            // стек и куча это области оперативной памяти, для стека выделяется маленькая область, 
            // для кучи большая, для стека выделяется 1мб памяти, для каждого потока, т.е каждый поток имеет свой собственный стек, 
            // используется для хранения данных и методов, т.е для выполнения логики работы программы, это мало, соответственно используется куча, размер зависит от разрядности платформы,
            // для стека доступ к памяти быстрый и эффективный, для кучи нет, также для кучи используется сборщик мусора
            int alfa = 1; // упаковка единицы в переменную alfa

            object beta = alfa; // копируем значение в управляемую кучу, взамен получая ссылку на эти данные

            int omega = (int)beta; // происходит операция распаковки
                                   // операция очень малоэффективна, из-за вызова сборщика мусора а также огромного количества различных действий
                                   // part d
                                   // var -- не тип данных, синтаксис указывающий языку на то что ему необходимо самостоятельно определить тип данных 
            var t = new float[10];

            Console.WriteLine(t.GetType()); // вывод: System.Single[], указывающий на то что это массив типа float
                                            // part e
                                            // Nullable -- фича которая позволяет присвоить значения null значимым типам данных
            string str = null; // ссылочный тип данных может носить значение null

            int? absorb = null; // явный пример применения этой фичи

            Console.WriteLine($"{absorb}");

            //part f
            var example = "Hello world";
            //example = 186;
            //g
            bool expected = true;
            bool unexpected = false;

            if (expected == unexpected)
            {
                Console.WriteLine("Не по плану");
            }
            else
            {
                Console.WriteLine("По плану");
            }
            //Strings
            //a
            string strA = "Hello world";
            string strB = "Hello C#";

            int result = string.Compare(strA, strB);

            Console.WriteLine($"{result}"); //Данная версия метода Compare принимает две строки и возвращает число. Если первая строка по алфавиту стоит выше второй,
                                            //то возвращается число меньше нуля. В противном случае возвращается число больше нуля. 
                                            //И третий случай - если строки равны, то возвращается число 0.
                                            //b
            string str1 = "Motherfucker";
            string str2 = "wake";
            string str3 = "up";

            string str_res = str1 + " " + str2 + " " + str3;
            string str_res_end = string.Concat(str_res, "!!!"); //конкатенация строк

            Console.WriteLine(str_res_end);

            var original = "This is a sentence. This is a second sentence.";
            var sentence1 = original.Substring(0, original.IndexOf(".") + 1);

            Console.WriteLine(original);
            Console.WriteLine(sentence1); // обрезка конкретной части строки

            string text2 = "И поэтому все так произошло";
            //разделение строки на слова
            string[] words = text2.Split(new char[] { ' ' });

            foreach (string s in words)
            {
                Console.WriteLine(s);
            }
            //обрезка через Trim
            string text3 = " hello world ";

            text3 = text3.Trim(); // результат "hello world"

            text3 = text3.Trim(new char[] { 'd', 'h' }); // результат "ello worl"
                                                         //вставка в конкретную позицию через insert
            string text1 = "Хороший день";

            string substring = "замечательный ";

            text1 = text1.Insert(8, substring);

            Console.WriteLine(text1);    // Хороший замечательный день
                                         //удаление подстроки
            string str6 = "GeeksForGeeks";

            Console.WriteLine("NewString: " + str6.Replace('e', ' '));

            string name = "Tom";
            int age = 23;

            Console.WriteLine($"Имя: {name}  Возраст: {age}"); //Знак доллара перед строкой указывает, что будет осуществляться интерполяция строк. 
                                                               //Внутри строки опять же используются плейсхолдеры {...},
                                                               //только внутри фигурных скобок уже можно напрямую писать те выражения, которые мы хотим вывести.
                                                               //Интерполяция по сути представляет более лаконичное форматирование. 
                                                               //При этом внутри фигурных скобок мы можем указывать не только свойства, но и различные выражения языка C#
                                                               //cString.IsNullOrEmpty
            string str8 = null;         // initialize by null value
            bool checkout1 = String.IsNullOrEmpty(str8);
            Console.WriteLine($"{checkout1}");

            string str9 = String.Empty;  // initialize by empty value
            bool checkout2 = String.IsNullOrEmpty(str9);
            Console.WriteLine($"{checkout2}");

            var sb = new StringBuilder("Привет мир");
            sb.Append("!");
            sb.Insert(7, "компьютерный ");
            Console.WriteLine(sb);  // Привет компьютерный мир!

            // заменяем слово
            sb.Replace("мир", "world");
            Console.WriteLine(sb);  // Привет компьютерный world!

            // удаляем 13 символов, начиная с 7-го
            sb.Remove(7, 13);
            Console.WriteLine(sb);  // Привет world!

            // получаем строку из объекта StringBuilder
            string text = sb.ToString();
            Console.WriteLine(text);    // Привет world!

            //Массивы
            // Объявляем двумерный массив
            // part a
            int[,] myArray = new int[,]
            {
                {2, 45, 12, 51, 51},
                {6, 7, 8, 3, 1},
                {1, 5, 65, 78, 12},
                {6, 3, 151, 5, 65}
            };
            int height = myArray.GetLength(0);
            int width = myArray.GetLength(1);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(myArray[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
