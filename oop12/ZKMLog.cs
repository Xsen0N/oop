using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace lab12
{
    public class ZKMLog
    {
        readonly DateTime DateNow = DateTime.Now;
        public static string path = @"D:\лр\ООП\lab12\lab12\bin\Debug\net6.0\zkmlogfile.txt";
        public static void Write(string action, string path1, string fileName1)
        {
            DateTime DateNow = DateTime.Now;
            using (StreamWriter sw = new StreamWriter(path, true, Encoding.UTF8)) { 
            sw.WriteLine("Имя файла: " + fileName1);
            sw.WriteLine("Путь к файлу " + path1);
            sw.WriteLine("Дата создания: " + DateNow);
            sw.WriteLine(action);
            sw.WriteLine("------------------------------------------");
            }
        }
        public void Read(string text) {
            File.ReadAllLines(path);
            ZKMLog.Write("Чтения файла", path, text);
        }
        public void Find(string text, string words)
        {
            string[] fileInfo = File.ReadAllLines(path);
            for (int i = 0; i < fileInfo.Length; i++)
                if (fileInfo.Contains(words))
                    Console.WriteLine($"{words} содержится в файле");
            else Console.WriteLine($"{words} не содержится в файле");
            ZKMLog.Write("Поиск ", path, text);
        }
        
    }
    public class ZKMForFileInfo
    {
        private string action;
        public string FullPath(string path = @"D:\лр\ООП\lab12\lab12\bin\Debug\net6.0\zkmlogfile.txt")
        {
            FileInfo f = new FileInfo(path);
            action = "Полный путь к файлу: " + f.DirectoryName;
            return action;
        }
        public string Info(string path = @"D:\лр\ООП\lab12\lab12\bin\Debug\net6.0\zkmlogfile.txt")
        {
            FileInfo f = new FileInfo(path);
            action = "Размер: " + f.Length + "байт. ";
            action += "Расширение: " + f.Extension + ". ";
            action += "Имя: " + f.FullName + ". ";
            return action;
        }
        public string Dates(string path = @"D:\лр\ООП\lab12\lab12\bin\Debug\net6.0\zkmlogfile.txt")
        {
            FileInfo f = new FileInfo(path);
            action = "Дата создания: " + f.CreationTime + ". ";
            action += "Дата изменения: " + f.LastWriteTime + ". ";
            return action;
        }
    }
}
