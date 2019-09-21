using System;
using System.IO;

namespace GetFileName
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\AU";
            DirectoryInfo root = new DirectoryInfo(path);
            FileInfo[] files = root.GetFiles();
            foreach (var item in files)
            {
                Console.Write(item.FullName);
            }
            Console.ReadKey();
        }
    }
}
