using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;



namespace Locadora.Infra.Data.EF.Extensions
{
    public static class EntityFrameworkExtensions
    {
        public static IServiceCollection AddEFConfiguration(this IServiceCollection services,
            string connectionString)
        {
            services.AddEntityFrameworkMySql()
                .AddDbContext<LocadoraContext>(options =>
                {
                    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                },
                ServiceLifetime.Scoped);

            return services;
        }
    }
}
