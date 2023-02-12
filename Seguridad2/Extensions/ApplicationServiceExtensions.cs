using Microsoft.EntityFrameworkCore;
using Seguridad2.Data;
using Seguridad2.Interfaces;
using Seguridad2.Services;

namespace Seguridad2.Extensions
{
    
    public static class ApplicationServiceExtensions
    {
        //Metodo de Extensión para Configurar el Sistema de Persistencia
        public static IServiceCollection 
            AddApplicationServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddDbContext<DataContext>(options =>
                        options.UseSqlServer(
                            configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
