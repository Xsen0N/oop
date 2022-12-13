using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    public static class ZKMFileInfo
    {
        public static void FileInfo(string path)
        {
            FileInfo file = new FileInfo(path);
            Console.WriteLine($"Полный путь: {file.FullName}");
            Console.WriteLine($"Имя файла: {file.Name}");
            Console.WriteLine($"Расширение: {file.Extension}");
            Console.WriteLine($"Размер: {file.Length}");
            Console.WriteLine($"Дата создания: {file.CreationTime}\n");
            ZKMLog.Write("Функция, отображающая все о файле", path, file.Name);
        }
    }
}
