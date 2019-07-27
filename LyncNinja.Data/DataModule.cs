using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LyncNinja.Data
{
    public static class DataModule
    {
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
