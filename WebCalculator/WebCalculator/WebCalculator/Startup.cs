using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebCalculator
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }
        public static async void HandleParams(HttpContext context)
        {
            string result = "Invalid invalid";
            try
            {
                var param1 = context.Request.Query["param1"];
                var op = context.Request.Query["op"];
                var param2 = context.Request.Query["param2"];
                result = Calculator.Calculate(double.Parse(param1), Double.Parse(param2), op.ToString()).ToString();
            }
            catch
            {
                result = "Invalid Query";
            }
            

            context.Response.Headers.Add("Calc_res",result);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.Run(async context => HandleParams(context));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        
    }
}