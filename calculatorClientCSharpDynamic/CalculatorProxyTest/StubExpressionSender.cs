using System.Threading.Tasks;
using calculatorClientCSharp;
using CalculatorStub;

namespace CalculatorProxyTest
{
    public class StubExpressionSender:IExpressionSender
    {
        public Task<double> GetRespAsync(double x, double y, string op)
        {
            var calculator = new CalculatorStub.Calculator(x,y,op);
            return Task.FromResult(calculator.Calculate());
        }
    }
}