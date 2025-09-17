using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using nr.BusinessLayer.Dto.Courses;
using nr.BusinessLayer.Services;
using nr.PresentationLayer.Controllers.Api.Models.Courses;

namespace nr.PresentationLayer.Controllers.Api
{
    /// <summary>
    /// Endpoint API per la gestione degli argomenti.
    /// </summary>
    /// <param name="topicService">Servizio di gestione degli argomenti.</param>
    /// <param name="mapper">Gestore del mapping tra layers.</param>
    /// <param name="logger">Logger.</param>
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController(ITopicService topicService, IMapper mapper) : ApiControllerBase
    {
        const string CREATED_AT_ROUTE = $"{nameof(TopicsController)}_{nameof(GetTopicById)}";
        /// <summary>
        /// Aggiunge un argomento.
        /// </summary>
        /// <param name="topic">I dati da inserire.</param>
        /// <returns>L'argomento inserito.</returns>
        [HttpPost]
        public async Task<CreatedAtRoute<TopicModel>> Add([FromBody] NewTopicModel topic) {
            var t = await topicService.AddAsync(mapper.Map<TopicDto>(topic));
            return TypedResults.CreatedAtRoute(mapper.Map<TopicModel>(t), CREATED_AT_ROUTE, new { topicId = t.Id });
        }
        /// <summary>
        /// Recupera tutti gli argomenti.
        /// </summary>
        [HttpGet]
        public async Task<Ok<IEnumerable<TopicModel>>> GetAll() {
            return TypedResults.Ok(mapper.Map<IEnumerable<TopicModel>>(await topicService.GetAllAsync()));
        }

        /// <summary>
        /// Recupera un argomento tramite la chiave.
        /// </summary>
        /// <param name="topicId">Chiave dell'argomento.</param>
        [HttpGet("{topicId}", Name = CREATED_AT_ROUTE)]
        public async Task<Ok<TopicModel>> GetTopicById([FromRoute] int topicId) {
            return TypedResults.Ok(mapper.Map<TopicModel>(await topicService.GetAsync(topicId)));
        }
    }
}
