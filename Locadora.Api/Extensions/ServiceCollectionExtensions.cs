using Microsoft.OpenApi.Models;

namespace Locadora.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Locadora Api",
                    Version = "v1",
                    Description = "Locadora Online"
                });
            });

            return services;
        }
    }
}
