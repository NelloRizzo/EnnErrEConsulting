using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddDbContext<ApplicationDBContext>(opt => {
                    opt.UseSqlServer(configuration[configuration["Misc:Connection"]!] ?? throw new NullReferenceException("Unable to read connection string"));
                    opt.UseLazyLoadingProxies();
                })
                .AddScoped<IUserService, UserService>()
                .AddScoped<ICustomerService, CustomerService>()
                .AddScoped<ICourseService, CourseService>()
                .AddScoped<ITopicService, TopicService>()
                .AddScoped<IAttachmentService, AttachmentService>()
                .AddScoped<IPlanningService, PlanningService>()
            ;
    }
}
