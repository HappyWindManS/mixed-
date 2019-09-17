using Amazon.CloudSearchDomain.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace CHAR
{
    class Program
    {
        static void Main(string[] args)
        {
            ////序列化对象
            //Student one = new Student()
            //{ ID = 1, Name = "武松", Age = 250, Sex = "男" };

            ////序列化
            //string jsonData = JsonConvert.SerializeObject(one);

            //Console.WriteLine(jsonData);  //显示结果
            //Console.ReadLine();

            //反序列化对象
            string str = "{\"ID\":2,\"Name\":\"鲁智深\",\"Age\":230,\"Sex\":\"男\"}{\"ID\":2,\"Name\":\"鲁智深\",\"Age\":230,\"Sex\":\"男\"}";

            //反序列化
            Student two = JsonConvert.DeserializeObject<Student>(str);

            Console.WriteLine(
                   string.Format("学生信息  ID:{0},姓名:{1},年龄:{2},性别:{3}",
                   two.ID, two.Name, two.Age, two.Sex));//显示结果
            Console.ReadLine();

        }
        public class Student
        {
            public int ID { get; set; }

            public string Name { get; set; }

            public int Age { get; set; }

            public string Sex { get; set; }
        }

    }
}
