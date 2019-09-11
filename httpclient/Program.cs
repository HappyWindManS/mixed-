using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace httpclient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

        }

        private async Task GetDataSimpleAsync()
        {
            using (var client = new HttpClient())
            {

            }
        }

        
    }
}
