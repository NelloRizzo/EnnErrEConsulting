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
    public class CoursesController(ICourseService courseService, IMapper mapper, ILogger<CoursesController> logger) : ApiControllerBase
    {
        /// <summary>
        /// Aggiunge un corso.
        /// </summary>
        /// <param name="courseModel">I dati per l'inserimento del corso.</param>
        [HttpPost]
        public async Task<Results<Ok<CourseModel>, BadRequest>> AddCourse([FromBody] NewCourseModel courseModel) {
            if (ModelState.IsValid)
                try {
                    var course = await courseService.AddAsync(mapper.Map<CourseDto>(courseModel));
                    return TypedResults.Ok(mapper.Map<CourseModel>(course));
                }
                catch (Exception ex) {
                    logger.LogError(ex, "Exception adding course");
                }
            return TypedResults.BadRequest();
        }

        /// <summary>
        /// Recupera tutti i corsi.
        /// </summary>
        [HttpGet]
        public async Task<Results<Ok<IEnumerable<CourseModel>>, BadRequest>> GetAll() {
            try {
                return TypedResults.Ok(mapper.Map<IEnumerable<CourseModel>>(await courseService.GetAllAsync()));
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception getting all couses");
                return TypedResults.BadRequest();
            }
        }
    }
}
