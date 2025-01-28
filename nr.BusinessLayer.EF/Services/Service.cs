using AutoMapper;
using Microsoft.Extensions.Logging;
using nr.BusinessLayer.EF.DataLayer;
using nr.BusinessLayer.Services;

namespace nr.BusinessLayer.EF.Services
{
    public class Service(ILogger<Service> logger, ApplicationDBContext context) : IService
    {
        protected ILogger<Service> logger = logger;
        protected ApplicationDBContext context = context;
        protected IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingsProfile>()).CreateMapper();
    }
}
