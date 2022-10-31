using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop07
{
    public class CollectionType<T> : IGenIntr<T> where T : new()
    {
        public List<T> MyColection =  new();
        public void Add(T i)
        {
            MyColection.Add(i);
        }
        public void Remove(T i)
        {
            if(MyColection.Contains(i))
            MyColection.Remove(i);
            else throw new Exception("Отсутствует такой элемент");
        }
        public void Show()
        {
            for (int i = 0; i < MyColection.Count; i++)
            {
                Console.WriteLine(MyColection[i]);
            }
        }

        internal void Add(string v)
        {
            throw new NotImplementedException("Необходимо число");
        }
        public void WriteTextFile() // запись в файл
        {
            string path = @"D:\\лр\\ООП\\oop07\\oop07\\Lab7.txt";
            foreach (var item in MyColection)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(item.ToString());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
        public void ReadTextFile() // чтение из файла
        {
            string path = @"D:\\лр\\ООП\\oop07\\oop07\\Lab7.txt";
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                Console.WriteLine("\n[+] Вывод информации из файла:");
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        public void FileInfo() // информация о файле
        {
            string path = @"D:\\лр\\ООП\\oop07\\oop07\\Lab7.txt";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                Console.WriteLine();
                Console.WriteLine($"Имя файла: {fileInf.Name}");
                Console.WriteLine($"Время создания: {fileInf.CreationTime}");
                Console.WriteLine($"Размер: {fileInf.Length}");
                Console.WriteLine();
            }
        }
    }
}
