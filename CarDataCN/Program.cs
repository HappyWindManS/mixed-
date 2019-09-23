using System;
using System.Collections.Generic;
using System.IO;

namespace CarDataCN
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> CnName = new List<string>();
            List<string> CnCode = new List<string>();
            StreamReader sR1 = new StreamReader(@"C:\Users\MR\Desktop\人物TXT.txt");

            string str = string.Empty;
            int i = 3;
            while (sR1.Peek() != -1)
            {              
                str = sR1.ReadLine();
                str.Trim();
                if (str == string.Empty)
                {

                }
                else if(i%2==0)
                {
                    CnCode.Add(str);
                    i++;
                }
                else
                {
                    CnName.Add(str);
                    i++;
                }
            }
            sR1.Close();
            string st = string.Empty;
            for(int l=0;l<60;l++)
            {
                string sr = ((l+1)+".jpg");
                st += ("'"+(l+1)+"'"+ ":{ 'name':'"+CnName[l]+"'," +
                    "'content':[{'content':'"+CnCode[l]+"'," +
                    "'url':'"+sr+"'}]},");
            }
            Console.WriteLine(st);
            Console.ReadKey();
        }
    }
}
