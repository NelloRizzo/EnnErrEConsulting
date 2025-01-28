using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using nr.BusinessLayer.EF.DataLayer;
using nr.BusinessLayer.EF.Services;
using nr.BusinessLayer.Services;

namespace nr.BusinessLayer.EF
{
    public static class Configuration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services, Action<DbContextOptionsBuilder> options) =>
            services
                .AddDbContext<ApplicationDBContext>(options)
                .AddScoped<IUserService, UserService>()
                .AddScoped<ICustomerService, CustomerService>()
            ;
    }
}
