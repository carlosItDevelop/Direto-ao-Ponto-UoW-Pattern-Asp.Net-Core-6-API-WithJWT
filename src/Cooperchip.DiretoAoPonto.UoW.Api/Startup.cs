using Cooperchip.DiretoAoPonto.UoW.Api.Configurations.Extensions;
using Cooperchip.DiretoAoPonto.UoW.Api.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Cooperchip.DiretoAoPonto.UoW.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (hostEnvironment.IsDevelopment() || hostEnvironment.IsStaging() || hostEnvironment.IsProduction())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        public void Configureservices(IServiceCollection services)
        {

            services.AddApiConfig();


            services.AddAutoMapper(typeof(AutoMapperConfig));
            services.AddDIRepositoryConfig();
            services.AddDbContextConfig(Configuration);

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddSwaggerConfig();
            
            services.AddAppSettingsConfig(Configuration);

            services.AddControllers();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerConfig(provider);

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


    }
}
