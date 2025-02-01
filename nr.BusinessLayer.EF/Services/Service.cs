using AutoMapper;
using nr.BusinessLayer.Services;

namespace nr.BusinessLayer.EF.Services
{
    /// <summary>
    /// Classe di base per tutti i servizi.
    /// </summary>
    public class Service : IService
    {
        /// <summary>
        /// Mapper di AutoMapper.
        /// </summary>
        protected IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingsProfile>()).CreateMapper();
    }
}
