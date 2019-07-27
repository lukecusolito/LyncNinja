using LyncNinja.Services.Interfaces.Data;
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
            services.AddTransient<IDataService, DataService>();
            services.AddTransient<ILinkedResourceData, LinkedResourceData>();

            return services;
        }
    }
}
