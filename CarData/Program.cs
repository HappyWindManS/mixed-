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
            string path = @"C:/Users/MR/Desktop/CarData.txt";
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
            int num = 0;
            int num1 = 0;
            int num2 = 0;
            for (int i = 0; i < str.Length - 1; i++)
            {
                if(str.Substring(0,1)=="<")
                {
                    str = str.Substring(1, str.Length - 1);
                }
                num = str.IndexOf("<");
                num1 = str.IndexOf(">");
                num2 = str.IndexOf("]");
                if(str.Substring(num1+1,1)=="[")
                {               
                    str = str.Substring(num2+2, str.Length - num2-2);
                }
                else
                {
                    Console.WriteLine(str.Substring(num1+1,num-num1-1));
                    str = str.Substring(num+1 , str.Length - num-1);
                }
            }
            return "";
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
