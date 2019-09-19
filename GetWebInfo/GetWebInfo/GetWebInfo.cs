using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetWeb
{
    public class GetWebInfo
    {
        //json列表数据的反序列化
        public static List<T> JsonCnvList<T>(string jsondata)
        {
            List<T> ret = JsonConvert.DeserializeObject<List<T>>(jsondata);
            return ret;
        }
        //json数据的反序列化
        public static T JsonCnvString<T>(string jsondata)
        {
            return JsonConvert.DeserializeObject<T>(jsondata);
        }


    }

  
}
