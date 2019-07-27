using FluentValidation.AspNetCore;
using LyncNinja.Common.Extensions;
using LyncNinja.Domain.Models;
using LyncNinja.Domain.Models.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace LyncNinja.Domain
{
    public static class DomainModule
    {
        public static IServiceCollection AddDomainModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(options => configuration.GetSection("AppSettings").Bind(options));

            services.AddMvc().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining(typeof(DomainModule)));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                // Generates a validation error response
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState.Values.SelectMany(x =>
                        x.Errors.Select(y =>
                            new ValidationError { Message = y.ErrorMessage, Property = ((string)x.GetType().GetProperty("Key").GetValue(x, null))?.ToCamelCase() }
                    )).ToList();

                    return new BadRequestObjectResult(new ValidationErrorResponse
                    {
                        ValidationErrors = errors
                    });
                };
            });

            return services;
        }
    }
}
