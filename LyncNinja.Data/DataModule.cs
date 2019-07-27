using LyncNinja.Data.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LyncNinja.Data
{
    public static class DataModule
    {
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LyncNinjaContext>(option => option.UseSqlServer(configuration.GetConnectionString(nameof(LyncNinjaContext))));

            return services;
        }
    }
}
