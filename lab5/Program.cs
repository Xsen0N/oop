using System.Collections.Generic;
using System.Reflection;
using System.Runtime.ExceptionServices;

namespace pract
{
    public class Program
    {
        public static void Operation(int x1, int x2, Action<int, int> op) => op(x1, x2);
        static int Oper(int x1, Func<int, int> retF) => x1 < 0 ? 0 : retF(x1);
        static void Main(string[] args)
        {
            //----------кортежи
            //var tuple = (first: "Anna", second: 3);
            //Console.WriteLine(tuple.GetType());
            //Console.WriteLine(tuple.Item1);

            //(int, string) tuple2 = (12, "lublu_tebia+");
            //ValueTuple<char, int> stud = ('a', 12);
            //Console.WriteLine(stud.GetType().Name);

            //var Wer = CreateCortage("Anna");
            //Console.WriteLine(Wer.GetType().Name);
            //Console.WriteLine(Wer.Item1.ToString() + Wer.Item2 + Wer.Item3);
            ////----------------индексаторы и структуры
            //Person per = new Person("sdsd");
            //Person per1 = new Person("sdsd");
            //try
            //{
            //    per.Age = -12;
            //    ; var person3 = per.Age;
            //    Console.WriteLine(person3);
            //}
            //catch (AgeExep) {
            //    Console.WriteLine("Ошибка обработана");
            //}
            //var App = new Company(new[]
            //    { new Person("Mike"),new Person("Sam"), new Person("Anna"),}
            //    );
            //Console.WriteLine(App[1].Name);
            //var wer = default(Person);
            //Console.WriteLine(" - -  - -- - - - -  -- - ");
            //Dog dog = new Dog(12);
            ////----------------переопределение базовых методов
            //Console.WriteLine(per.GetHashCode());
            //Console.WriteLine(per.ToString());
            //Console.WriteLine(per.Equals(per1));
            ////----------------
            //Rectangle r = new Rectangle();
            //var dat = r + 2;
            //foreach (var item in dat)
            //    Console.WriteLine(item);
            ////------------is / as
            //Animal animal = new Animal("cat");
            //Cat cat = new Cat("cat", 2);
            //if (cat is Animal) {
            //    Console.Write("dsdsd");
            //    animal = (Animal)cat;
            //}
            //var sed = cat as Animal;
            //if (sed != null)
            //    Console.WriteLine("123");
            ////------------------
            //int[] ar = { 12, 3 };
            //int[,] ar2 = { { 1, 3 }, { 2, 5 } };
            ////-------------
            //Mind m = new Mind();
            //Leg l = new Leg();
            //Eye e = new Eye();
            //m.Go += new SomeDelegate(l.ObGo);
            //m.Go += new SomeDelegate(e.ObGo);
            //m.CommanGo();
            ////----var2
            //CallMen qwer = new CallMen();
            //Men n = new Men();
            //qwer.Tr += n.Answer;
            //qwer.Call();
            //Action<int, int> op;
            //op = (int a, int b) => { int с = a + b; };
            //Operation(10, 6, op);
            //string str = "wer";
            //Func<string, string> convert = delegate (string str)
            //{ return str.Insert(str.Length, "!!!!!"); };
            //Console.WriteLine(Oper(6, x => x + 9));
            //// метод расширения
            //Predicate<int> isLong = (int x) => x > 5;
            //Console.WriteLine(isLong(str.Length));
            //str.isLetter('e');
            //Animal a1 = new Animal("dcnj", 2);
            //Animal a2 = new Animal("dcnj", 2, 6);
            //Animal a3 = new Animal("dcnj");
            //int value = 12;
            //NewStringFunction.Sum(ref value, 12);
            //Console.WriteLine(value);
            //int b = 9;
            //NewStringFunction.Sum1(0, out b);
            //Console.WriteLine(b);
            //Class2 class2 = new Class2(Class2.WDay.M);
            //Class2 class1 = new Class2(Class2.WDay.M);
            //Console.WriteLine(class2 == class1);
            //PropertyInfo[] propertyInfos = typeof(Class2).GetProperties();
            //foreach (var item in propertyInfos) { 
            //Console.WriteLine(item.Name);
            //    Console.WriteLine(item.DeclaringType);
                
            //}
            //(Iqwert.qwert).Go();
            Qwert qwert1 = new Qwert();
            qwert1.Go();
            ((Iqwert)qwert1).Go();

        }
        (int, char) Tuple1(string name) {
            int len = name.Length;
            char let = (char)(name[0]);
            return (f: len, s: let);
        }

        static Tuple<int, string, char> CreateCortage(string name) {
            int len = name.Length;
            char let = (char)(name[0]);
            string n = "Dear " + name;
            return Tuple.Create<int, string, char>(len, n, let);
        }

    }


    public static class NewStringFunction
    {
        public static int Sum(ref int a, int b)
        {
            a = a + 6;
            return a + b;
        }
        public static int Sum1( int a, out int b)
        {
            b = a + 6;
            return b;
        }
        public static bool isLetter(this String st, char a)
        {
            for (int i = 0; i < st.Length; i++)
            {
                if (st[i] == a) return true;
            }
            return false;
        }
    }

}