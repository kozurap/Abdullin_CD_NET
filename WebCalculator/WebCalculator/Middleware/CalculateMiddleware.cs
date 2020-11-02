using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebCalculator;

namespace WebCalculator.Middleware
{
    public class CalculateMiddleware
    {
        private readonly RequestDelegate _next;
        private ICalculator _calculator;

        public CalculateMiddleware(RequestDelegate next, ICalculator calculator)
        {
            _next = next;
            _calculator = calculator;
        }

        public async Task Invoke(HttpContext context)
        {
            var param1 = context.Request.Query["param1"];
            var op = context.Request.Query["op"];
            if (op == "%2b") op = "+";
            var param2 = context.Request.Query["param2"];
            try
            {
                var res = _calculator.Calculate(double.Parse(param1), double.Parse(param2), op);
                context.Response.Headers.Add("Calc_res", res.ToString());
            }
            catch
            {
                context.Response.StatusCode = 404;
            }
            await _next(context);
        }
    }
}