using nr.BusinessLayer.Dto.Planning;

namespace nr.BusinessLayer.Services
{
    public interface IPlanningService : IService
    {
        Task<CoursePlanDto> AddWeeklyPlanningAsync(WeeklyCoursePlanDto coursePlanDto);
        Task<CoursePlanDto> AddLongPlanningAsync(LongPeriodCoursePlanDto coursePlanDto);
        Task<CoursePlanDto> AddPlanningAsync(CoursePlanDto coursePlanDto);
        Task<CoursePlanDto> UpdatePlanningAsync(int coursePlanId, CoursePlanDto coursePlanDto);
        Task<CoursePlanDto> DeletePlanningAsync(int coursePlanId);
        Task<CoursePlanDto> GetPlanningAsync(int coursePlanId);
        Task<IEnumerable<PlanDateDto>> GetDates(DateOnly startDate, DateOnly endDate);
    }
}
