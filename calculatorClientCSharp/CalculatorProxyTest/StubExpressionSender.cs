using System.Threading.Tasks;
using calculatorClientCSharp;
using CalculatorStub;

namespace CalculatorProxyTest
{
    public class StubExpressionSender:IExpressionSender
    {
        public Task<double> GetRespAsync(string x, string y, string op)
        {
            var calculator = new CalculatorStub.Calculator(double.Parse(x),double.Parse(y),op);
            return Task.FromResult(calculator.Calculate());
        }
    }
}