using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace calculatorClientCSharp
{
    class Program
    {
        public static IServiceProvider ServiceProvider;
        static void Configure(ServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IExpressionSender,ExpressionSender>();
            serviceCollection.AddSingleton<CalculatorProxy>();
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
        static async Task Main(string[] args)
        {
            var ServiceCollection = new ServiceCollection();
            Configure(ServiceCollection);
            string s = Console.ReadLine();
            var proxy = ServiceProvider.GetRequiredService<CalculatorProxy>();
            proxy.Calculate(s);
        }
    }
}