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
            var calc = new ExpressionCalcVisitor(_sender);
            var x =await calc.Calculate(a);
            return double.Parse(x.ToString());
        }
    }
}