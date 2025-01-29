using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using nr.BusinessLayer.Dto.Courses;
using nr.BusinessLayer.Services;
using nr.PresentationLayer.Controllers.Api.Models.Courses;

namespace nr.PresentationLayer.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(ICourseService courseService, IMapper mapper, ILogger<CoursesController> logger) : ApiControllerBase
    {
        [HttpPost]
        public async Task<Results<Ok<CourseModel>, BadRequest>> AddCourse([FromBody] CourseModel courseModel) {
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
