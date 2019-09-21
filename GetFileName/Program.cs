using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Threading;
using System.Text;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //String rootPath = Directory.GetCurrentDirectory();
            //string parentPath = Directory.GetParent(rootPath).FullName;//上级目录
            DirectoryInfo info = new DirectoryInfo(@"D:\history\1history");

            //获得 cn&world
            DirectoryInfo[] infos = info.GetDirectories();
            List<contai> cs = new List<contai>();
            //获取年代
            var dirs = infos[0].GetDirectories();
            Console.WriteLine(infos[0].FullName);
            for (int j = 0; j < dirs.Length; j++)
            {
                contai c = new contai();
                c.name = dirs[j].Name;
                c.test = new test();
                //获得video、samll、big、文本
                c.test.text = GetText(dirs[0] + "/文字.txt");
                #region big
                var bigs = new DirectoryInfo(dirs[j] + "/big/");
                var imgs = bigs.GetFiles("*.jpg");
                var texts = bigs.GetFiles("*.txt");
                List<big> b = new List<big>();
                if (imgs.Length == 0 && texts.Length == 0)
                {
                    c.test.big = b;
                }
                else
                {

                    var newb = new big();
                    for (int g = 0; g < imgs.Length; g++)
                    {
                        newb.url = (g + 1).ToString() + ".jpg";
                    }

                    for (int g = 0; g < texts.Length; g++)
                    {
                        newb.memo = GetText(dirs[j] + "/big/" + (g + 1).ToString() + ".txt");
                    }
                    b.Add(newb);
                    c.test.big = b;
                }
                #endregion
                #region small
                var smalls = new DirectoryInfo(dirs[j] + "/small/");
                var small_imgs = smalls.GetFiles("*.jpg");
                var small_texts = smalls.GetFiles("*.txt");

                List<small> s = new List<small>();
                if (small_imgs.Length == 0 && small_texts.Length == 0)
                {
                    c.test.small = s;
                }
                else
                {
                    var news = new small();
                    for (int g = 0; g < small_imgs.Length; g++)
                    {
                        news.url = (g + 1).ToString() + ".jpg";
                    }

                    for (int g = 0; g < small_texts.Length; g++)
                    {
                        news.memo = GetText(dirs[j] + "/small/" + (g + 1).ToString() + ".txt");
                    }
                    s.Add(news);
                    c.test.small = s;
                }
                #endregion
                c.test.video = "";
                cs.Add(c);
                Thread.Sleep(300);
            }
            foreach(var i in cs)
            {
                Console.WriteLine(i.name,i.test);
            }
            Console.WriteLine("-----------------------------------------------------分割线");
            string json = JsonConvert.SerializeObject(cs);
            Console.Write(json);
            Console.WriteLine("打印结束");
        }

        public static string GetText(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.GetEncoding("GB2312")))
                {
                    string str = string.Empty;
                    while (sr.Peek() != -1)
                    {
                        str = sr.ReadLine();
                    }
                    sr.Close();
                    return str;
                }
            }
            catch (Exception e) { return string.Empty; }
        }
    }
    public class big
    {
        public string url;
        public string memo;
    }

    public class contai
    {
        public string name;
        public test test;
    }

    public class small
    {
        public string url;
        public string memo;
    }
    public class test
    {
        public List<big> big;

        public List<small> small;

        public string video;
        public string text;
    }
}
