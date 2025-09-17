using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using nr.BusinessLayer.Dto.Planning;
using nr.BusinessLayer.Services;
using nr.PresentationLayer.Controllers.Api.Models.Planning;

namespace nr.PresentationLayer.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanningController(IPlanningService planningService, IMapper mapper) : ApiControllerBase
    {
        [HttpPost("weeks")]
        public async Task<Ok<CoursePlanModel>> AddWeekPlanning([FromBody] WeeklyCoursePlanModel model) {
            var result = await planningService.AddWeeklyPlanningAsync(mapper.Map<WeeklyCoursePlanDto>(model));
            return TypedResults.Ok(mapper.Map<CoursePlanModel>(result));
        }

        [HttpPost("long")]
        public async Task<Ok<CoursePlanModel>> AddLongPlanning([FromBody] LongPeriodCoursePlanModel model) {
            var result = await planningService.AddLongPlanningAsync(mapper.Map<LongPeriodCoursePlanDto>(model));
            return TypedResults.Ok(mapper.Map<CoursePlanModel>(result));
        }
        [HttpPost()]
        public async Task<Ok<CoursePlanModel>> AddPlanning([FromBody] CoursePlanModel model) {
            var result = await planningService.AddPlanningAsync(mapper.Map<CoursePlanDto>(model));
            return TypedResults.Ok(mapper.Map<CoursePlanModel>(result));
        }
    }
}
