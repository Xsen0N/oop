using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace lab12
{
    public static class ZKMFileManager
    {
        public static void AllAboutDrive(string disk)
        {
            string path;
            if (disk.ToLower() == "d")
            {
                path = @"D:\";
            }
            else
            {
                throw new Exception("Неверный ввод.");
            }

            DirectoryInfo dir = new DirectoryInfo(path);

            Console.WriteLine("\nСписок папок диска:");
            foreach (DirectoryInfo name in dir.GetDirectories())
            {
                Console.WriteLine(name.Name);
            }

            Console.WriteLine("\nСписок файлов диска:");
            foreach (FileInfo name in dir.GetFiles())
            {
                Console.WriteLine(name.Name);
            }
            Console.WriteLine("--------------------------------------");
            ZKMLog.Write("Вывод информации о диске", disk, "-");
        }

        public static void FileDirCreate(string dirName, string fileName, string fileName2)
        {
            string dirPath = @"D:\лр\ООП\lab12\lab12\bin\Debug\net6.0\" + dirName;
            DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            string filePath = dirPath + "\\" + fileName + ".txt";
            FileInfo fileInf = new FileInfo(filePath);
            if (!fileInf.Exists)
            {
                fileInf.Create();
            }
            try
            {
                using StreamWriter sw = new StreamWriter(filePath, false, System.Text.Encoding.Default);
                sw.WriteLine("Информация");
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            string filePath2 = dirPath + "\\" + fileName2 + ".txt";
            try {File.Copy(filePath, filePath2, true);
                File.Delete(filePath);
            }
            catch { Console.WriteLine("уже есть"); }
            ZKMLog.Write($"Создания файлов .txt и запись информации, директориев", $"{filePath}", $"{filePath2}") ;
        }

        public static void ZKMFiles(string path, string ext)
        {
            string dirPath = @"D:\ZKMFiles";
            DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            DirectoryInfo userDirInfo = new DirectoryInfo(path);
            foreach (FileInfo file in userDirInfo.GetFiles())
            {
                if (file.Extension == ("." + ext))
                    file.CopyTo(dirPath + "\\" + file.Name, true);
            }
            try { 
            dirInfo.MoveTo(@"D:\лр\ООП\lab12\lab12\bin\Debug\net6.0\ZKMInspect\ZKMFiles");}
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
            ZKMLog.Write($"Создания файлов .{ext} и запись информации", dirPath, $"Файлы с расширением {ext}") ;
        }
        public static void Zip()
        {
            DirectoryInfo source = new DirectoryInfo(@"D:\лр\ООП\lab12\lab12\bin\Debug\net6.0\ZKMInspect\ZKMFiles");
            try { ZipFile.CreateFromDirectory(source.FullName, source.FullName + ".zip"); } catch { Console.WriteLine("Архив уже создан"); }
            ZKMLog.Write($"Создания архива", source.FullName, $"{source.FullName}.zip");
        }
        public static void UnZip(string FolderName)
        {

            DirectoryInfo source = new DirectoryInfo(@"D:\лр\ООП\lab12\lab12\bin\Debug\net6.0\ZKMInspect\ZKMFiles");
            try { ZipFile.ExtractToDirectory(source.FullName + ".zip", FolderName); }
            catch (Exception) { }

            Console.WriteLine("Архив разархивирован!");
            ZKMLog.Write($"Разархивирование", source.FullName, $"{source.FullName}.zip");
        }
    }
    public static class CheckedInfo
    {
        private const string path = @"zkmlogfile.txt";
        public static void CheckedActions()
        {
            try
            {
                using (StreamReader sr = new StreamReader(path, Encoding.Default))
                {
                    int count = 0;
                    Console.WriteLine("Введите ключевое слово для поиска по файлу лога: ");
                    string word = Console.ReadLine();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains(word))
                        {
                            Console.WriteLine("Найдена запись: ");
                            Console.WriteLine(line);
                            count++;
                        }
                    }
                    Console.WriteLine($"Количество найденных записей: {count}");
                }
                using (StreamReader sr = new StreamReader(path, Encoding.Default))
                {
                    int count = 0;
                    Console.WriteLine("\nВведите дату слово для поиска по файлу лога: ");
                    string date = Console.ReadLine();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains(date))
                        {
                            Console.WriteLine("Найдена запись: ");
                            Console.WriteLine(line);
                            count++;
                        }
                    }
                    Console.WriteLine($"Количество найденных записей: {count}");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}

