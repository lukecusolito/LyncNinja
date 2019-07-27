using LyncNinja.API.Middleware;
using Microsoft.AspNetCore.Builder;

namespace LyncNinja.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseLyncNinjaRequestMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<LyncNinjaRequestMiddleware>();

            return builder;
        }
    }
}
