using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace calculatorClientCSharp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string s = Console.ReadLine();
            var a =ExpressionParser.CreateMathExpression(s);
            var x = await Task.Run(()=>ExpressionCalcVisitor.Calculate(a));
            Console.WriteLine("Конечный ответ: " + x);
        }
    }
}