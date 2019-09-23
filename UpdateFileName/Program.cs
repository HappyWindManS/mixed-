using System;
using System.IO;

namespace UpdateFileName
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\MR\Desktop\image";
            // 判断给定的目录是否存在  
            if (!Directory.Exists(path))
            {
                Console.WriteLine("目录不存在");
                return;
            }
            // 返回当前按下目录下的文件列表  
            DirectoryInfo di = new DirectoryInfo(path);
            var files = di.GetFiles();
            var count = 0;
            // 遍历这个目录  
            foreach (var f in files)
            {
                count++;
                f.MoveTo(Path.Combine(path, count + f.Extension));
            }
            Console.WriteLine("成功修改{0}个文件名", count);
            Console.ReadKey();
        }
    }
}
