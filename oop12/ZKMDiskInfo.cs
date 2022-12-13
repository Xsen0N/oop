using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    public static class ZKMDiskInfo
    {
        public static void ShowFreeSpace(DriveInfo[] drives) {
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Свободное пространство: {drive.TotalFreeSpace}");
                }
                Console.WriteLine();
                ZKMLog.Write("Функция, отображающая все о директории", drive.Name, "директорий");
            }
        }
        public static void ShowFileSys(DriveInfo[] drives)
        {
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveFormat}");
                Console.WriteLine($"Тип: {drive.DriveType}");
                Console.WriteLine();
                ZKMLog.Write("Функция, отображающая тип директория", drive.Name, "директорий");
            }
        }
        public static void ShowAllInform(DriveInfo[] drives)
        {
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Объем диска: {drive.TotalSize}");
                    Console.WriteLine($"Свободное пространство: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Метка диска: {drive.VolumeLabel}");
                }
                Console.WriteLine();
                ZKMLog.Write("Функция, отображающая всю информацию директория", drive.Name, "директорий");
            }
        }

    }

}
