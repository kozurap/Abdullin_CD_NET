using System;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
namespace calculatorClientCSharp
{
    public static class ExpressionSender
    {
        public static async Task<double> GetRespAsync(string x, string y, string op)
        {
            Console.WriteLine("Считаю " + x + op + y);
            if (op == "+")
                op = "%2B";
            HttpClient proxy = new HttpClient();
            
            var resp = await proxy.GetAsync("localhost:5000/?param1=" + x + "&op=" + op + "&param2=" + y);
            var answer = resp.Headers.ToString();
            return double.Parse(answer);
        }
    }
}