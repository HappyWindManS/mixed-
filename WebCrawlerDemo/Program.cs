using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            #region
            ////WebProxy proxyObject = new WebProxy(IP, PORT);//这里我是用的代理。

            ////向指定地址发送请求
            ////HttpWebRequest HttpWReq = (HttpWebRequest)WebRequest.Create("https://news.baidu.com");
            //HttpWebRequest HttpWReq = (HttpWebRequest)WebRequest.Create("https://gkcx.eol.cn/school/96");
            ////HttpWReq.Proxy = proxyObject;
            //HttpWReq.Timeout = 10000;
            //HttpWebResponse HttpWResp = (HttpWebResponse)HttpWReq.GetResponse();
            //StreamReader sr = new StreamReader(HttpWResp.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
            //HtmlDocument doc = new HtmlDocument();
            //doc.Load(sr);
            ////HtmlNodeCollection ulNodes = doc.DocumentNode.SelectSingleNode("//div[@id='pane-news']").SelectNodes("ul");
            ////HtmlNodeCollection ulNodes = doc.DocumentNode.SelectSingleNode("//div[class='mod-tab-content']").SelectNodes("ul");
            //HtmlNodeCollection ulNodes = doc.DocumentNode.SelectSingleNode("//div[@id='root']").SelectNodes("tr");
            ////HtmlNodeCollection ulNodes = doc.DocumentNode.SelectSingleNode("//div[@class='scoreLine-table']").SelectNodes("td");
            //Console.WriteLine("传输成功，且返回数据不为空");
            ////if (ulNodes != null && ulNodes.Count > 0)
            ////{
            ////    for (int i = 0; i < ulNodes.Count; i++)
            ////    {
            ////        HtmlNodeCollection liNodes = ulNodes[i].SelectNodes("li");
            ////        for (int j = 0; j < liNodes.Count; j++)
            ////        {
            ////            string title = liNodes[j].SelectSingleNode("a").InnerHtml.Trim();
            ////            string href = liNodes[j].SelectSingleNode("a").GetAttributeValue("h" +
            ////                "ref", "").Trim();
            ////            Console.WriteLine("新闻标题：" + title + ",链接：" + href);
            ////        }
            ////    }
            ////}
            //if (ulNodes != null && ulNodes.Count > 0)
            //{
            //    for (int i = 0; i < ulNodes.Count; i++)
            //    {
            //        HtmlNodeCollection liNodes = ulNodes[i].SelectNodes("tr");
            //        for (int j = 0; j < liNodes.Count; j++)
            //        {
            //            //string title = liNodes[j].SelectSingleNode("a").InnerHtml.Trim();
            //            //string href = liNodes[j].SelectSingleNode("a").GetAttributeValue("h" +
            //            //    "ref", "").Trim();
            //            Console.WriteLine(liNodes[j].SelectSingleNode("td"));
            //        }
            //    }
            //}
            //Console.WriteLine("打印结束");
            //Console.ReadLine();
            //sr.Close();
            //HttpWResp.Close();
            //HttpWReq.Abort();
            #endregion
            string url = "https://gkcx.eol.cn/school/96";
            HttpWebRequest gkpc = (HttpWebRequest)WebRequest.Create(url);
            //持续性链接
            gkpc.KeepAlive = false;
            //超时
            gkpc.Timeout = 30 * 1000;
            //请求方法
            gkpc.Method = "get";
            //文件头
            gkpc.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3";
            //来源
            gkpc.Host = "gkcx.eol.cn";
            //主机
            //gkpc.Referer = "";
            //不知道是啥反正填上就是了
            gkpc.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.0.3770.100 Safari/537.36";
            //格林威治时间
            var time = DateTime.Now;
            gkpc.Date = time.AddHours(-5);
            

            //接收来自网页的返回值
            HttpWebResponse gkdata = (HttpWebResponse)gkpc.GetResponse();

            if(gkdata.StatusCode==HttpStatusCode.OK)
            {
                Console.WriteLine("网页连通成功");
            }
            else
            {
                Console.WriteLine("网页连通失败");
            }

            using(StreamReader date = new StreamReader(gkdata.GetResponseStream()))
            {
                Console.WriteLine(date .ReadToEnd());
            }

            Console.ReadKey();
        }
    }
}