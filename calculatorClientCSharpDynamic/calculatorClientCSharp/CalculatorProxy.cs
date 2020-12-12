using System;
using System.Threading.Tasks;

namespace calculatorClientCSharp
{
    public class CalculatorProxy
    {
        private IExpressionSender _sender;

        public CalculatorProxy(IExpressionSender sender)
        {
            _sender = sender;
        }

        public async Task<double> Calculate(string s)
        {
            var a =ExpressionParser.CreateMathExpression(s);
            var calc = new DynamicCalculatorExpressionVisitor(_sender);
            var x = await calc.VisitTree(a);
            return x;
        }
    }
}