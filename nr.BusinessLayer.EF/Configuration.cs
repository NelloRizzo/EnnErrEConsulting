using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using nr.BusinessLayer.EF.DataLayer;
using nr.BusinessLayer.EF.Services;
using nr.BusinessLayer.Services;

namespace nr.BusinessLayer.EF
{
    /// <summary>
    /// Configurazione del layer di business.
    /// </summary>
    public static class Configuration
    {
        /// <summary>
        /// Configura i servizi.
        /// </summary>
        /// <param name="options">Opzioni per la configurazione del database.</param>
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services, Action<DbContextOptionsBuilder> options) =>
            services
                .AddDbContext<ApplicationDBContext>(options)
                .AddScoped<IUserService, UserService>()
                .AddScoped<ICustomerService, CustomerService>()
            ;
    }
}
