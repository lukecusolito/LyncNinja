using Microsoft.Extensions.DependencyInjection;

namespace LyncNinja.Services.DataService
{
    public static class DataServiceModule
    {
        public static IServiceCollection AddDataService(this IServiceCollection services)
        {
            services.AddDependencies();

            return services;
        }

        private static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            return services;
        }
    }
}
