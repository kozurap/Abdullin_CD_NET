using System.Threading.Tasks;

namespace calculatorClientCSharp
{
    public interface IExpressionSender
    {
        public Task<double> GetRespAsync(double x, double y, string op);
    }
}