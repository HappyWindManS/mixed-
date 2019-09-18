using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.DirectoryServices;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //string result = UTools.ToGB2312("");
            //Console.Write("\u4e13\u79d1\u6279\uff08CD\uff09");

            //Console.ReadKey();


            int local_province_id = 45;
            int local_type_id = 1;
            int school_id = 125;
            int year = 2018;

            //string p = string.Format(@"api.eol.cn/gkcx/api/?access_token=&local_province_id={0}&
            //local_type_id ={1}&school_id={2}&signsafe=&uri=apidata/api/gk/score/special&year={3}", local_province_id, local_type_id, school_id, year);
            string p = string.Format(@"api.eol.cn/gkcx/api/?access_token=&local_province_id={0}&
              local_type_id={1}&school_id={2}&signsafe=&uri=apidata/api/gk/score/province&year={3}",
               local_province_id, local_type_id, school_id, year);
            string url = "https://" + p;
            string lol= GetWebClient(url);
            var s = STrin(lol);
            var two = JsonConvert.DeserializeObject<JsonData>(s);
            //List<JsonData> twoList = JsonConvert.DeserializeObject<List<JsonData>>(lol);

            //JObject googleSearch = JObject.Parse(lol);
            //// get JSON result objects into a list
            //IList<JToken> results = googleSearch["responseData"]["results"].Children().ToList();
            //// serialize JSON results into .NET objects
            //IList<SearchResult> searchResults = new List<SearchResult>();
            //foreach (JToken result in results)
            //{
            //    // JToken.ToObject is a helper method that uses JsonSerializer internally
            //    SearchResult searchResult = result.ToObject<SearchResult>();
            //    searchResults.Add(searchResult);
            //    Console.WriteLine(result);
            //}
            //foreach (var two in twoList)
            //{
                Console.WriteLine(string.Format("学校信息  地址:{0},分科:{1},最低分数:{2},校名:{3}",
                            two.local_province_name, two.local_type_name, two.min, two.name));//显示结果
            //}
            Console.ReadLine();
            Console.WriteLine(GetWebClient(url));
            Console.ReadKey();


        }   
        public static string STrin(string str)
        {
            int num = str.Length;
            str=str.Substring(1, str.Length-1);
            num = str.IndexOf("{");
            str = str.Substring(num,str.Length-num);
            str = str.Substring(1, str.Length - 1);
            num = str.IndexOf("{");
            str = str.Substring(num,str.Length-num);
            num = str.LastIndexOf("}");
            str = str.Substring(0, num);
            num = str.LastIndexOf("}");
            str = str.Substring(0, num);
            num = str.LastIndexOf("}");
            str = str.Substring(0, num);
            num = str.LastIndexOf("{"); ;
            str = str.Substring(0, num-1);
            return str;
        }
        private static string GetWebClient(string url)
        {
            string strHTML = "";
            WebClient myWebClient = new WebClient();
            Stream myStream = myWebClient.OpenRead(url);
            StreamReader sr = new StreamReader(myStream, System.Text.Encoding.GetEncoding("utf-8"));
            strHTML = sr.ReadToEnd();
            myStream.Close();
            return strHTML;
        }

        private static string GetWebRequest(string url)
        {
            Uri uri = new Uri(url);
            WebRequest myReq = WebRequest.Create(uri);
            WebResponse result = myReq.GetResponse();
            Stream receviceStream = result.GetResponseStream();
            StreamReader readerOfStream = new StreamReader(receviceStream, System.Text.Encoding.GetEncoding("utf-8"));
            string strHTML = readerOfStream.ReadToEnd();
            readerOfStream.Close();
            receviceStream.Close();
            result.Close();
            return strHTML;
        }

        private static string GetHttpWebRequest(string url)
        {
            Uri uri = new Uri(url);
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(uri);
            myReq.UserAgent = "User-Agent:Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705";
            myReq.Accept = "*/*";
            myReq.KeepAlive = true;
            myReq.Headers.Add("Accept-Language", "zh-cn,en-us;q=0.5");
            HttpWebResponse result = (HttpWebResponse)myReq.GetResponse();
            Stream receviceStream = result.GetResponseStream();
            StreamReader readerOfStream = new StreamReader(receviceStream, System.Text.Encoding.GetEncoding("utf-8"));
            string strHTML = readerOfStream.ReadToEnd();
            readerOfStream.Close();
            receviceStream.Close();
            result.Close();
            return strHTML;
        }
    }
}
