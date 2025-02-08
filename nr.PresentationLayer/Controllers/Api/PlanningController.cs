using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using nr.BusinessLayer.Dto.Planning;
using nr.BusinessLayer.Services;
using nr.PresentationLayer.Controllers.Api.Models.Planning;

namespace nr.PresentationLayer.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanningController(IPlanningService planningService, ILogger<PlanningController> logger, IMapper mapper) : ApiControllerBase
    {
        [HttpPost("weeks")]
        public async Task<Results<Ok<CoursePlanModel>, BadRequest<string>, InternalServerError>> AddWeekPlanning(WeeklyCoursePlanModel model) {
            if (ModelState.IsValid)
                try {
                    var result = await planningService.AddWeeklyPlanningAsync(mapper.Map<WeeklyCoursePlanDto>(model));
                    return TypedResults.Ok(mapper.Map<CoursePlanModel>(result));
                }
                catch (Exception ex) {
                    logger.LogError(ex, "Unattended exception adding planning");
                    return TypedResults.InternalServerError();
                }
            return TypedResults.BadRequest("Invalid model");
        }
        [HttpPost("long")]
        public async Task<Results<Ok<CoursePlanModel>, BadRequest<string>, InternalServerError>> AddLongPlanning(LongPeriodCoursePlanModel model) {
            if (ModelState.IsValid)
                try {
                    var result = await planningService.AddLongPlanningAsync(mapper.Map<LongPeriodCoursePlanDto>(model));
                    return TypedResults.Ok(mapper.Map<CoursePlanModel>(result));
                }
                catch (Exception ex) {
                    logger.LogError(ex, "Unattended exception adding planning");
                    return TypedResults.InternalServerError();
                }
            return TypedResults.BadRequest("Invalid model");
        }
        [HttpPost()]
        public async Task<Results<Ok<CoursePlanModel>, BadRequest<string>, InternalServerError>> AddPlanning(CoursePlanModel model) {
            if (ModelState.IsValid)
                try {
                    var result = await planningService.AddPlanningAsync(mapper.Map<CoursePlanDto>(model));
                    return TypedResults.Ok(mapper.Map<CoursePlanModel>(result));
                }
                catch (Exception ex) {
                    logger.LogError(ex, "Unattended exception adding planning");
                    return TypedResults.InternalServerError();
                }
            return TypedResults.BadRequest("Invalid model");
        }
    }
}
