using System.Threading.Tasks;

namespace calculatorClientCSharp
{
    public interface IExpressionSender
    {
        public Task<double> GetRespAsync(string x, string y, string op);
    }
}