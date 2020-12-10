using Microsoft.AspNetCore.Builder;

namespace WebCalculator.Middleware
{
    public static class AddExtensions
    {
        public static IApplicationBuilder UseCalculator(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CalculateMiddleware>();
        }
    }
}