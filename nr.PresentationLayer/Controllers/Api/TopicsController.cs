using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using nr.BusinessLayer.Dto.Courses;
using nr.BusinessLayer.Services;
using nr.PresentationLayer.Controllers.Api.Models.Courses;
using System.Net.Mime;
using System.Reflection;

namespace nr.PresentationLayer.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController(ITopicService topicService, IMapper mapper, ILogger<TopicsController> logger) : ApiControllerBase
    {
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json), Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TopicModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Missing))]
        public async Task<Results<Ok<TopicModel>, BadRequest, InternalServerError>> Add(NewTopicModel topic) {
            if (ModelState.IsValid) {
                try {
                    return TypedResults.Ok(mapper.Map<TopicModel>(await topicService.AddAsync(mapper.Map<TopicDto>(topic))));
                }
                catch (Exception ex) {
                    logger.LogError(ex, "Exception adding topic");
                    return TypedResults.InternalServerError();
                }
            }
            return TypedResults.BadRequest();
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TopicModel>))]
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
    }
}
