using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace CarData
{
    class Program
    {
        static void Main(string[] args)
        {
            //调用解码包
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //string p = string.Format(@"auto.sohu.com/s2013/60yearpeople/index.shtml"
            //                         );
            //var data=GetWebClient("https://" + p);
            string path = @"C:/Users/ND01/Desktop/新建文本文档.txt";
            StreamReader sr = new StreamReader(path, Encoding.GetEncoding("GB2312"));
            String line;
            string data = "";
            while ((line = sr.ReadLine()) != null)
            {
                data += (line.ToString());
            }

            Console.WriteLine(StringConformity(data));
            Console.WriteLine("打印结束");
            Console.ReadLine();
        }
        public static string GetWebClient(string url)
        {
            string strHTML = "";
            WebClient myWebClient = new WebClient();
            Stream myStream = myWebClient.OpenRead(url);
            StreamReader sr = new StreamReader(myStream, System.Text.Encoding.GetEncoding("GB2312"));
            strHTML = sr.ReadToEnd();
            myStream.Close();
            return strHTML;
        }
        public static string StringConformity(string str)
        {
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str.Substring(i, 1) == " ")
                {

                }
                else if (str.Substring(i, 1) == "年")
                {
                    if (str.Substring(i, 4) == "年筑梦人")
                    {
                        str = str.Remove(i, 4);
                        str = str.Insert(i, " ");
                    }
                    else if (!CheckStringChineseReg(str.Substring(i, 1)) && !isTel(str.Substring(i, 1)))
                    {
                        str = str.Remove(i, 1);
                        str = str.Insert(i, " ");
                    }
                }
                else if(!CheckStringChineseReg(str.Substring(i, 1)) && !isTel(str.Substring(i, 1)))
                {
                    str = str.Remove(i, 1);
                    str = str.Insert(i, " ");
                }
               
            }
            return str;
        }
        /// <summary>
        /// 用 正则表达式 判断字符是不是汉字
        /// </summary>
        /// <param name="text">待判断字符或字符串</param>
        /// <returns>真：是汉字；假：不是</returns>
        public static bool CheckStringChineseReg(string text)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(text, @"[\u4e00-\u9fbb]");
        }
        public static bool isTel(string strInput)
        {
            return Regex.IsMatch(strInput, @"^[+-]?\d*$");
        }
    }
}
