using AutoMapper;
using nr.BusinessLayer.Services;

namespace nr.BusinessLayer.EF.Services
{
    /// <summary>
    /// Classe di base per tutti i servizi.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="context"></param>
    public class Service : IService
    {
        protected IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingsProfile>()).CreateMapper();
    }
}
