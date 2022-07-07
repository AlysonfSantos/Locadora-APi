using AutoMapper;
using Locadora.Application.Mapper;
using Locadora.Application.Services;
using Locadora.Application.Services.Interfaces;
using Locadora.Domain.Interfaces.Repositories;
using Locadora.Domain.Interfaces.Services;
using Locadora.Domain.Services;
using Locadora.Infra.Data.Repositoreis;
using Microsoft.Extensions.DependencyInjection;

namespace Locadora.Infra.IoC
{
    public static class LocadoraModule
    {
        private static void ConfigureMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainToViewModelProfile());
            });

            services.AddSingleton(mapperConfig.CreateMapper());
        }
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
        {
            services.ConfigureMapper();

            return services;
        }

        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<IFilmeAppService, FilmesAppService>();
            services.AddScoped<ILocacaoAppService, LocacaoAppService>();
            services.AddScoped<IFilmeService, FilmeService>();
            services.AddScoped<IClienteService,ClienteService>();
            services.AddScoped<ILocacaoService, LocacaoService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IFilmeRepository, FilmeRepository>();
            services.AddScoped<ILocacaoRepository, LocacaoRepository>();

            return services;
        }
    }
}
