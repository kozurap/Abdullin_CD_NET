using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
namespace calculatorClientCSharp
{
    public class ExpressionSender:IExpressionSender
    {
        public async Task<double> GetRespAsync(double x, double y, string op)
        {
            if (op == "+")
                op = "%2B";
            HttpClient proxy = new HttpClient();
            var resp = await proxy.GetAsync(
                string.Format("https://localhost:5001/?param1={0}&op={1}&param2={2}", x, op, y));
            var answer = resp.Headers.GetValues("Calc_res");
            return double.Parse(answer.First());
        }
    }
}