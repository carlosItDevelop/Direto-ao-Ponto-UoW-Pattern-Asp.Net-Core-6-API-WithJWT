using Cooperchip.DiretoAoPonto.IdentidadeApi.Configuration;
using Cooperchip.DiretoAoPonto.IdentidadeApi.Services;
using Cooperchip.DiretoAoPonto.WebApiCore.Extensions;
using Cooperchip.DiretoAoPonto.WebApiCore.Identidade;

namespace Cooperchip.DiretoAoPonto.IdentidadeApi
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

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddIdentityConfiguration(Configuration);
            services.AddSwaggerConfiguration();

            // jWT
            services.AddJwtConfig(Configuration);

            // UserAdmin
            services.AddScoped<IUserService, UserService>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cooperchip Identidade - v1");
            });
            app.UseBasicApplicationBuilder();
        }
    }
}