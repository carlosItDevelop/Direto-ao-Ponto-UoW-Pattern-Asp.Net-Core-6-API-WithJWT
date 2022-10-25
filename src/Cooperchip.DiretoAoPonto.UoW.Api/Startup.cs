using Cooperchip.DiretoAoPonto.UoW.Api.Configurations.Extensions;
using Cooperchip.DiretoAoPonto.UoW.Api.Mapper;
using Cooperchip.DiretoAoPonto.WebApiCore.Extensions;
using Cooperchip.DiretoAoPonto.WebApiCore.Identidade;
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

            /*
             * CORS - Cross-Origin Resource Sharing (Compartilhamento de recursos com origens diferentes) é um mecanismo que usa cabeçalhos adicionais HTTP para informar a um navegador que permita que um aplicativo Web seja executado em uma origem (domínio) com permissão para acessar recursos selecionados de um servidor em uma origem distinta. Um aplicativo Web executa uma requisição cross-origin HTTP ao solicitar um recurso que tenha uma origem diferente (domínio, protocolo e porta) da sua própria origem.
             * 
             * Leia mais no link abaixo, pois ele traz todas as informações necessárias para a sua compreesão e aplicação.
             * https://developer.mozilla.org/pt-BR/docs/Web/HTTP/CORS
             * 
             */
            services.AddCors(options =>
            {
                options.AddPolicy("Total",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });


            services.AddAutoMapper(typeof(AutoMapperConfig));
            services.AddDIRepositoryConfig();
            services.AddDbContextConfig(Configuration);

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddSwaggerConfig();
            
            services.AddAppSettingsConfig(Configuration);

            services.AddJwtConfig(Configuration);

            services.AddControllers();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwaggerConfig(provider);
            app.UseBasicApplicationBuilder();
        }
    }
}
