using System;
using System.Text;

namespace Strings
{
    class Strings
    {
        static void Main(string[] args)
        {
            char[] a1 = { 'w', 'o', 'r', 'd' };
            string string1 = new string(a1);
            Console.WriteLine(string1);

            string string2 = new string('k', 10);
            Console.WriteLine(string2);

            string string3 = null;
            Console.WriteLine(string3);

            Console.WriteLine("плохая погода");
            Console.WriteLine("Привет всем \"Вам\"");
            Console.WriteLine("Привет \nи мне\n");

//------------------------задание 2------------------------
            // объединение //

            string s1 = "Кот";
            string s2 = "ики";
            string s3 = "рыбка!";
            Console.WriteLine(s1 + s2);
            Console.WriteLine(String.Concat(s1, s2));  //Метод Concat является статическим методом класса String
            string stringLine6 = String.Join(" -> ", s1, s3); 
            Console.WriteLine(stringLine6);
            string[] values = new string[] { s1, s3 };

            Console.WriteLine($"{s1}{s2}");
            int x = 8;
            int y = 7;
            string result = $"{x} + {y} = {x + y}";
            Console.WriteLine(result); 
            Console.WriteLine(x +" + "+ y +" = " + (x+y));//развносильно result 
            //Интерполяция - форматирование строки - способ соединения строк через вставку значений переменных в строку-шаблон с помощью фигурных скобок.

            // копирование строк //
            // Clone - возвращает ссылку на данный экземпляр класса String.

            string p = s1;

            char[] charArr = new char[] { 'H', 'e', 'l', 'l', 'o', ' ', 'w', 'o', 'r', 'l', 'd' };
            string s4 = "string";
            s4.CopyTo(0, charArr, 6, 4);
            Console.WriteLine(charArr);

            string s5 = String.Copy(s3);
            Console.WriteLine(s5);

            // выделение подстроки
            string newString = "Привет тебе и тебе";
            string subNewString = "тебе";
            int indexOfSub = newString.IndexOf(subNewString);
            int indexOfSub1 = newString.LastIndexOf(subNewString);
            Console.WriteLine("Первый индекс: " + indexOfSub + ", последний индекс: " + indexOfSub1);

            // разделение строки на слова//
            string s = "You win. You lose.";
            string[] subs = s.Split(' ');
            foreach (var word in subs)
            {
                Console.WriteLine($"Substring: {word}");
            }

            // вставка подстроки //
            string text = "Хороший день";
            string subString = "сегодня ";
            text = text.Insert(8, subString);
            Console.WriteLine(text);

            // удаление заданной подстроки //

            // индекс последнего символа
            int ind = text.Length - 4;
            // вырезаем последний символ
            text = text.Remove(ind);
            Console.WriteLine(text);
            // вырезаем первые 3 символа
            text = text.Remove(0, 3);
            Console.WriteLine(text);

            string phrase = "хороший день";
            Console.WriteLine("До: " + phrase);
            phrase = phrase.Replace("хороший", "холодный");
            Console.WriteLine("После 1: " + phrase);
            phrase = phrase.Replace("о", "-");
            Console.WriteLine("После 2: " + phrase);

            //------------------- задание 3-------------

            string emptyString = "";
            string emptyString1 = string.Empty;
            string nullString = null;
            string notAnEmpty = "Не путая строка";

            string[] array = { emptyString, nullString };

            Console.WriteLine(String.IsNullOrEmpty(emptyString));
            Console.WriteLine(String.IsNullOrEmpty(emptyString1));
            Console.WriteLine(String.IsNullOrEmpty(nullString));
            Console.WriteLine(String.IsNullOrEmpty(notAnEmpty));

            string con = emptyString + nullString; //сцепление
            Console.WriteLine(con);
            Console.WriteLine("Equals: " + (emptyString.Equals(nullString)));
            Console.WriteLine("CompareTo: " + emptyString.CompareTo(nullString));
            Console.WriteLine("String.Concat: " + String.Concat(nullString, emptyString));
            Console.WriteLine("Interpolation: " + $"{nullString}{emptyString}");

            //---------------------------задание 4
            //StringBuilder - класс - Предоставляет изменяемую строку символов. Этот класс не наследуется.
            StringBuilder sb = new StringBuilder("Hello, World");
            Console.WriteLine($"Удаление c 1 позиций 3-ух символов: {sb.Remove(1, 3)}");
            sb = sb.Insert(0, "!!!");
            sb = sb.Insert(7, "!!!");
            Console.WriteLine($"Добавление новых символов в начало и в середину строки: {sb}");
        }
    }
}
