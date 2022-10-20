using Microsoft.OpenApi.Models;

namespace Cooperchip.DiretoAoPonto.IdentidadeApi.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "DiretoAoPonto - UoW Enterprise - Identity API",
                    Description = "Esta API serve para consumir a API de Identidade do DiretoAoPonto-Uow c/JWT.",
                    Contact = new OpenApiContact() { Name = "Carlos A Santos", Email = "carlos.itdeveloper@gmail.com" },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
                });
            });

            return services;

        }
    }
}
