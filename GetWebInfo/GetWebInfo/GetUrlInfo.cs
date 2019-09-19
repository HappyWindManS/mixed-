using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GetWebInfo
{
    public class GetUrlInfo
    {
        public string UrlInfo(string local_province_id,string local_type_id,string school_id,string year)
        {
            string p = string.Format(@"api.eol.cn/gkcx/api/?access_token=&local_province_id={0}&
                                     local_type_id={1}&school_id={2}&signsafe=&uri=apidata/api/gk/score/province&year={3}",
                                     local_province_id, local_type_id, school_id, year);
            return GetWebClient("https://" + p);
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
    }
}
