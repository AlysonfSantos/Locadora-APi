﻿using Locadora.Api.Extensions;
using Locadora.Infra.Data.EF.Extensions;
using Locadora.Infra.IoC;

namespace Locadora.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerConfiguration();

            services
                .AddEFConfiguration(Configuration.GetConnectionString("connection"))
                .ConfigureDependencies()
                .ConfigureApplicationServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger().UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("v1/swagger.json", "Locadora Api");
            });
        }
    }
}
