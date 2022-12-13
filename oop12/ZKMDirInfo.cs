using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    public static class ZKMDirInfo
    {
        public static void ShowFiles(string dirName) {
            try
            {
                Directory.GetFiles(dirName);
                DirectoryInfo dir = new DirectoryInfo(dirName);
                Console.WriteLine($"Количестве файлов: {dir.GetFiles().Length}");
                Console.WriteLine($"Название каталога: {dir.Name}");
                Console.WriteLine($"Время создания каталога: {dir.CreationTime}");
                Console.WriteLine($"Корневой каталог: {dir.Root}");
                Console.WriteLine($"Количестве поддиректориев: {dir.GetDirectories().Length}");
                ZKMLog.Write("Функция, отображающая все файлы в директории, информацию", dirName, "-");
            }
            catch (Exception ex) { 
            Console.WriteLine(ex.Message);
            }
        }
    }
}
