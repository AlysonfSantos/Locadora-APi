using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql;


namespace Locadora.Infra.Data.EF.Extensions
{
    public static class EntityFrameworkExtensions
    {
        public static IServiceCollection AddEFConfiguration(this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<LocadoraContext>(options =>
                {
                    options.UseSqlServer(connectionString);
                    //options.UseMySql(connectionString, ServerVersion.Parse("10.3.35-MariaDB"));
                },
                ServiceLifetime.Scoped);

            return services;
        }
    }
}
