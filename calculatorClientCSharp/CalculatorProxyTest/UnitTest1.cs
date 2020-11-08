using System;
using System.Linq.Expressions;
using calculatorClientCSharp;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CalculatorProxyTest
{
    public class UnitTest1
    {
        public ServiceProvider ServiceProvider;
        void Configure(ServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IExpressionSender,StubExpressionSender>();
            serviceCollection.AddSingleton<CalculatorProxy>();
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public UnitTest1()
        {
            var sercviceCollection = new ServiceCollection();
            Configure(sercviceCollection);
        }

        [Theory]
        [InlineData("15/3+2*3")]
        [InlineData("2+2")]
        [InlineData("15/3*3-5+6")]
        [InlineData("2*2*3*4*5")]
        [InlineData("100/10/10")]
        [InlineData("11/1+2")]
        [InlineData("55/5*2")]
        [InlineData("13-2")]
        [InlineData("(2+2)*2")]
        [InlineData("14/7*(13-3)")]
        public void Test1(string s)
        {
            var calculatorProxy = ServiceProvider.GetRequiredService<CalculatorProxy>();
            var expression = ExpressionParser.CreateMathExpression(s);
            var compiledExpression = Expression.Lambda<Func<double>>(expression).Compile();
            Assert.Equal(calculatorProxy.Calculate(s).Result,compiledExpression());
        }
    }
}