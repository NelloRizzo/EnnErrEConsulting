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
    /// Endpoint API per la gestione dei corsi.
    /// </summary>
    /// <param name="courseService">Servizio di business per i corsi.</param>
    /// <param name="mapper">Mapper per AutoMapper.</param>
    /// <param name="logger">Logger.</param>
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(ICourseService courseService, IMapper mapper, ILogger<CoursesController> logger) : ApiControllerBase
    {
        /// <summary>
        /// Aggiunge un corso.
        /// </summary>
        /// <param name="courseModel">I dati per l'inserimento del corso.</param>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json), Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(CourseModel), StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest, MediaTypeNames.Text.Plain)]
        public async Task<Results<Ok<CourseModel>, InternalServerError, BadRequest<string>>> AddCourse([FromBody] NewCourseModel courseModel) {
            if (ModelState.IsValid)
                try {
                    var course = await courseService.AddAsync(mapper.Map<CourseDto>(courseModel), courseModel.Topics);
                    return TypedResults.Ok(mapper.Map<CourseModel>(course));
                }
                catch (Exception ex) {
                    logger.LogError(ex, "Exception adding course");
                    return TypedResults.InternalServerError();
                }
            return TypedResults.BadRequest("Invalid model");
        }

        /// <summary>
        /// Recupera tutti i corsi.
        /// </summary>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<CourseModel>), StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Results<Ok<IEnumerable<CourseModel>>, InternalServerError>> GetAll() {
            try {
                return TypedResults.Ok(mapper.Map<IEnumerable<CourseModel>>(await courseService.GetAllAsync()));
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception getting all couses");
                return TypedResults.InternalServerError();
            }
        }
        /// <summary>
        /// Collega degli argomenti ad un corso.
        /// </summary>
        /// <param name="courseId">Chiave del corso.</param>
        /// <param name="model">Indicazioni degli argomenti da collegare.</param>
        /// <returns>Il corso modificato a seguito dell'operazione.</returns>
        [ProducesResponseType(typeof(CourseModel), StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("{courseId}/Topics/Link")]
        public async Task<Results<Ok<CourseModel>, InternalServerError>> LinkTopics([FromRoute] int courseId, [FromBody] LinkTopicsModel model) {
            try {
                return TypedResults.Ok(mapper.Map<CourseModel>(await courseService.LinkTopicAsync(courseId, model.Order, model.TopicIds)));
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception linking topics {} to course {}", model.TopicIds, courseId);
                return TypedResults.InternalServerError();
            }
        }
        /// <summary>
        /// Scollega degli argomenti da un corso.
        /// </summary>
        /// <param name="courseId">Chiave del corso.</param>
        /// <param name="model">Indicazioni degli argomenti da scollegare.</param>
        /// <returns>Il corso modificato a seguito dell'operazione.</returns>
        [ProducesResponseType(typeof(CourseModel), StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("{courseId}/Topics/Unlink")]
        public async Task<Results<Ok<CourseModel>, InternalServerError>> UnlinkTopics([FromRoute] int courseId, [FromBody] UnlinkTopicModel model) {
            try {
                return TypedResults.Ok(mapper.Map<CourseModel>(await courseService.UnlinkTopicAsync(courseId, model.TopicIds)));
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception linking topics {} to course {}", model.TopicIds, courseId);
                return TypedResults.InternalServerError();
            }
        }
    }
}
