using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PruebaIngresoBibliotecario.IoC;
using PruebaIngresoBibliotecario.WebExceptionsPresenter;

namespace PruebaIngresoBibliotecario.API
{
    public static class WebApiHelper
    {
        public static WebApplication CreateWebApp(this WebApplicationBuilder builder)
        {
            //Controladores
            builder.Services.AddControllers(Filters.Register);

            //Services
            builder.Services.AddLibraryServices();

            //Construir
            return builder.Build();
        }

        //Configura Middlewares

        public static WebApplication ConfigureWebApp(this WebApplication app)
        {
            app.UseRouting();
            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllers();
                });

            return app;
        }
    }
}
