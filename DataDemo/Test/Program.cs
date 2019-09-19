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
using GetWeb;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //string result = UTools.ToGB2312("");
            //Console.Write("\u4e13\u79d1\u6279\uff08CD\uff09");

            //Console.ReadKey();

            List<JsonData> lalla = new List<JsonData>();
            for (int i = 0; i < 1000; i++)
            {
                int local_province_id = 45;
                int local_type_id = 1;
                int school_id = i;
                int year = 2018;
                var shcool = GetUrlInfo.UrlInfo(local_province_id.ToString(), local_type_id.ToString(), school_id.ToString(), year.ToString());
                if (shcool != null)
                {
                    var shcoollist = GetWebInfo.JsonCnvList<JsonData>(shcool);
                    foreach (var shcools in shcoollist)
                    {
                        lalla.Add(shcools);
                    }
                }
                else
                {

                }
                Console.WriteLine("爬取了{0}次", i);
                //System.Threading.Thread.Sleep(2000);
               
            }
            foreach(var s in lalla)
            {
                Console.WriteLine("学校名称:{0},分数线:{1},分科:{2}",s.name,s.min,s.local_type_name);
            }
            
            #region 完成文件
            ////string p = string.Format(@"api.eol.cn/gkcx/api/?access_token=&local_province_id={0}&
            ////local_type_id ={1}&school_id={2}&signsafe=&uri=apidata/api/gk/score/special&year={3}", local_province_id, local_type_id, school_id, year);

            //string p = string.Format(@"api.eol.cn/gkcx/api/?access_token=&local_province_id={0}&
            //  local_type_id={1}&school_id={2}&signsafe=&uri=apidata/api/gk/score/province&year={3}",
            //   local_province_id, local_type_id, school_id, year);
            //string lol= GetWebClient("https://" + p);
            //var s = STrin(lol);
            //var two = JsonConvert.DeserializeObject<JsonData>(s);


            //Console.WriteLine(two.name+two.school_id);

            //List<SchoolData> twoList = JsonConvert.DeserializeObject<List<SchoolData>>("[{ 'name':'\u5317\u4eac','code':'11'},{ 'name':'\u5929\u6d25','code':'12'},{ 'name':'\u6cb3\u5317','code':'13'},{ 'name':'\u5c71\u897f','code':'14'},{ 'name':'\u5185\u8499\u53e4','code':'15'},{ 'name':'\u8fbd\u5b81','code':'21'},{ 'name':'\u5409\u6797','code':'22'},{ 'name':'\u9ed1\u9f99\u6c5f','code':'23'},{ 'name':'\u4e0a\u6d77','code':'31'},{ 'name':'\u6c5f\u82cf','code':'32'},{ 'name':'\u6d59\u6c5f','code':'33'},{ 'name':'\u5b89\u5fbd','code':'34'},{ 'name':'\u798f\u5efa','code':'35'},{ 'name':'\u6c5f\u897f','code':'36'},{ 'name':'\u5c71\u4e1c','code':'37'},{ 'name':'\u6cb3\u5357','code':'41'},{ 'name':'\u6e56\u5317','code':'42'},{ 'name':'\u6e56\u5357','code':'43'},{ 'name':'\u5e7f\u4e1c','code':'44'},{ 'name':'\u5e7f\u897f','code':'45'},{ 'name':'\u6d77\u5357','code':'46'},{ 'name':'\u91cd\u5e86','code':'50'},{ 'name':'\u56db\u5ddd','code':'51'},{ 'name':'\u8d35\u5dde','code':'52'},{ 'name':'\u4e91\u5357','code':'53'},{ 'name':'\u897f\u85cf','code':'54'},{ 'name':'\u9655\u897f','code':'61'},{ 'name':'\u7518\u8083','code':'62'},{ 'name':'\u9752\u6d77','code':'63'},{ 'name':'\u5b81\u590f','code':'64'},{ 'name':'\u65b0\u7586','code':'65'},{ 'name':'\u53f0\u6e7e','code':'71'},{ 'name':'\u9999\u6e2f','code':'81'},{ 'name':'\u6fb3\u95e8','code':'82'}]");

            //foreach (SchoolData stu in twoList)
            //{
            //    Console.WriteLine(
            //    string.Format("学校信息 学校名称:{0},学校ID：{1}",
            //                                 stu.name, stu.code));//显示结果   
            //}
            #endregion
            #region 测试
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
            //Console.WriteLine(string.Format("学校信息  地址:{0},分科:{1},最低分数:{2},校名:{3}",
            //                two.local_province_name, two.local_type_name, two.min, two.name));//显示结果
            //}
            //Console.ReadLine();
            //Console.WriteLine(GetWebClient(url));
            #endregion
            Console.ReadKey();


        }
        public static string ReadTxtContent(string Path)
        {
            Path = "D://下载/1.json";
            StreamReader sr = new StreamReader(Path, Encoding.Default);
            string content;
            string str="";
            while ((content = sr.ReadLine()) != null)
            {
                str+=content.ToString();
            }
            //str = str.Substring(1, str.Length - 2);
            return str;
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
