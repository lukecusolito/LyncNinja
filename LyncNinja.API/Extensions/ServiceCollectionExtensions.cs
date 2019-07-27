using LyncNinja.Data;
using LyncNinja.Domain;
using LyncNinja.Services.DataService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LyncNinja.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLyncNinjaMvc(this IServiceCollection services)
        {
            services
                .AddMvc()
                .AddJsonOptions(config =>
                {
                    config.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
                    config.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    config.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            return services;
        }

        public static IServiceCollection AddLyncNinjaModules(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddData(configuration);
            services.AddDataService();
            services.AddDomainModule(configuration);

            return services;
        }
    }
}
