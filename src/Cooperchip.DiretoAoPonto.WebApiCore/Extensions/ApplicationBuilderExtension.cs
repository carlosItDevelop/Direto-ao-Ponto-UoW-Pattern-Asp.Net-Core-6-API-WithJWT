using Microsoft.AspNetCore.Builder;

namespace Cooperchip.DiretoAoPonto.WebApiCore.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static void UseBasicApplicationBuilder(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
