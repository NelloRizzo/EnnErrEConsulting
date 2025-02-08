using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using nr.BusinessLayer.Dto.Courses;
using nr.BusinessLayer.Services;
using nr.PresentationLayer.Controllers.Api.Models.Courses;
using System.Net.Mime;

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
    public class TopicsController(ITopicService topicService, IMapper mapper, ILogger<TopicsController> logger) : ApiControllerBase
    {
        const string CREATED_AT_ROUTE = $"{nameof(TopicsController)}_{nameof(GetTopicById)}";
        /// <summary>
        /// Aggiunge un argomento.
        /// </summary>
        /// <param name="topic">I dati da inserire.</param>
        /// <returns>L'argomento inserito.</returns>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(TopicModel), StatusCodes.Status201Created, MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest, MediaTypeNames.Text.Plain)]
        public async Task<Results<CreatedAtRoute<TopicModel>, BadRequest, InternalServerError>> Add(NewTopicModel topic) {
            if (ModelState.IsValid) {
                try {
                    var t = await topicService.AddAsync(mapper.Map<TopicDto>(topic));
                    return TypedResults.CreatedAtRoute(mapper.Map<TopicModel>(t), CREATED_AT_ROUTE, new { topicId = t.Id });
                }
                catch (Exception ex) {
                    logger.LogError(ex, "Exception adding topic");
                    return TypedResults.InternalServerError();
                }
            }
            return TypedResults.BadRequest();
        }
        /// <summary>
        /// Recupera tutti gli argomenti.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TopicModel>), StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Results<Ok<IEnumerable<TopicModel>>, InternalServerError>> GetAll() {
            try {
                return TypedResults.Ok(mapper.Map<IEnumerable<TopicModel>>(await topicService.GetAllAsync()));
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception retrieving all topics");
            }
            return TypedResults.InternalServerError();
        }
        /// <summary>
        /// Recupera un argomento tramite la chiave.
        /// </summary>
        /// <param name="topicId">Chiave dell'argomento.</param>
        [HttpGet("{topicId}", Name = CREATED_AT_ROUTE)]
        [ProducesResponseType(typeof(TopicModel), StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Results<Ok<TopicModel>, InternalServerError>> GetTopicById([FromRoute] int topicId) {
            try {
                return TypedResults.Ok(mapper.Map<TopicModel>(await topicService.GetAsync(topicId)));
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception retrieving topic {}", topicId);
            }
            return TypedResults.InternalServerError();
        }
    }
}
