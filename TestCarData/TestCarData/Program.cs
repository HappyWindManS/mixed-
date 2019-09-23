using System;
using System.IO;
using System.Net;

namespace TestCarData
{
    class Program
    {
        static void Main(string[] args)
        {
            //string url = "";
            //HttpWebRequest car = (HttpWebRequest)WebRequest.Create(url);
            //car.KeepAlive = false;
            //car.Timeout = 30 * 1000;
            Console.WriteLine(GetWebClient(UrlInfo("", "", "", "")));
            Console.ReadLine();
        }
        //读取网页信息
        public static string UrlInfo(string local_province_id, string local_type_id, string school_id, string year)
        {
            string p = string.Format(@"auto.sohu.com/s2013/60yearpeople/index.shtml");
            return str(GetWebClient("https://" + p));
        }
        //获取的网页信息转换成string
        public static string GetWebClient(string url)
        {
            string strHTML = "";
            WebClient myWebClient = new WebClient();
            Stream myStream = myWebClient.OpenRead(url);
            StreamReader sr = new StreamReader(myStream, System.Text.Encoding.GetEncoding("utf-8"));
            strHTML = sr.ReadToEnd();
            myStream.Close();
            return strHTML;
        }

        private static string str(string st)
        {
            int num = st.IndexOf("[");
            int num1 = st.IndexOf("]");
            st = st.Substring(num, num1 - num + 1);
            return st;
        }
    }
}
