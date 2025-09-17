using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using nr.BusinessLayer.Dto.Courses;
using nr.BusinessLayer.Services;
using nr.PresentationLayer.Controllers.Api.Models.Courses;

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
    public class CoursesController(ICourseService courseService, IMapper mapper) : ApiControllerBase
    {
        const string CREATED_AT_ROUTE = $"{nameof(CoursesController)}_{nameof(GetCourseById)}";
        /// <summary>
        /// Aggiunge un corso.
        /// </summary>
        /// <param name="courseModel">I dati per l'inserimento del corso.</param>
        [HttpPost]
        public async Task<CreatedAtRoute<CourseModel>> AddCourse([FromBody] NewCourseModel courseModel) {
            var course = await courseService.AddAsync(mapper.Map<CourseDto>(courseModel), courseModel.Topics);
            return TypedResults.CreatedAtRoute(mapper.Map<CourseModel>(course), CREATED_AT_ROUTE, new { courseId = course.Id });
        }

        /// <summary>
        /// Recupera tutti i corsi.
        /// </summary>
        [HttpGet]
        public async Task<Ok<IEnumerable<CourseModel>>> GetAll() {
            return TypedResults.Ok(mapper.Map<IEnumerable<CourseModel>>(await courseService.GetAllAsync()));
        }
        /// <summary>
        /// Collega degli argomenti ad un corso.
        /// </summary>
        /// <param name="courseId">Chiave del corso.</param>
        /// <param name="model">Indicazioni degli argomenti da collegare.</param>
        /// <returns>Il corso modificato a seguito dell'operazione.</returns>
        [HttpPost("{courseId}/Topics/Link")]
        public async Task<Ok<CourseModel>> LinkTopics([FromRoute] int courseId, [FromBody] LinkTopicsModel model) {
            return TypedResults.Ok(mapper.Map<CourseModel>(await courseService.LinkTopicAsync(courseId, model.Order, model.TopicIds)));
        }
        /// <summary>
        /// Scollega degli argomenti da un corso.
        /// </summary>
        /// <param name="courseId">Chiave del corso.</param>
        /// <param name="model">Indicazioni degli argomenti da scollegare.</param>
        /// <returns>Il corso modificato a seguito dell'operazione.</returns>
        [HttpPost("{courseId}/Topics/Unlink")]
        public async Task<Ok<CourseModel>> UnlinkTopics([FromRoute] int courseId, [FromBody] UnlinkTopicModel model) {
            return TypedResults.Ok(mapper.Map<CourseModel>(await courseService.UnlinkTopicAsync(courseId, model.TopicIds)));
        }

        /// <summary>
        /// Recupera un corso.
        /// </summary>
        /// <param name="courseId">Chiave del corso.</param>
        [HttpGet("{courseId}", Name = CREATED_AT_ROUTE)]
        public async Task<Ok<CourseModel>> GetCourseById([FromRoute] int courseId) {
            return TypedResults.Ok(mapper.Map<CourseModel>(await courseService.GetAsync(courseId)));
        }
    }
}
