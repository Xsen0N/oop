using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static lab12.ZKMDiskInfo;
namespace lab12
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = "zkmlogfile.txt";
            File.WriteAllText(path, "------Документация-------\n");
            DriveInfo[] drives = DriveInfo.GetDrives();
            ShowFreeSpace(drives);
            ShowFileSys(drives);
            ShowAllInform(drives);
            ZKMFileInfo.FileInfo(path);
            ZKMDirInfo.ShowFiles(@"D:\лр\ООП\lab12");
            ZKMForFileInfo fileInfo = new ZKMForFileInfo();
            ZKMLog log = new ZKMLog();
            Console.WriteLine("--------------------------------------");

            ZKMFileInfo.FileInfo(path);

            ZKMDirInfo.ShowFiles(@"D:\лр\ООП");

            ZKMFileManager.AllAboutDrive("D");

            ZKMFileManager.FileDirCreate("ZKMInspect", "ZKMdirinfo", "testFileCopy");

            ZKMFileManager.ZKMFiles(@"D:\лр\ООП\lab12\lab12", "txt");

            ZKMFileManager.Zip();

            ZKMFileManager.UnZip(@"D:\лр\ООП\lab12\lab12\bin\Debug\net6.0\ZKMInspect\UnZip");
            CheckedInfo.CheckedActions();
        }
    }
}