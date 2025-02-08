using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Logging;
using nr.BusinessLayer.Dto.Courses;
using nr.BusinessLayer.Dto.Customers;
using nr.BusinessLayer.Dto.Planning;
using nr.BusinessLayer.EF.DataLayer;
using nr.BusinessLayer.EF.DataLayer.Entities.Courses;
using nr.BusinessLayer.EF.DataLayer.Entities.Customers;
using nr.BusinessLayer.EF.DataLayer.Entities.Planning;
using nr.BusinessLayer.Services;
using nr.BusinessLayer.Services.Exceptions;
using nr.Validation;

namespace nr.BusinessLayer.EF.Services
{
    public class PlanningService(ApplicationDBContext context, ILogger<PlanningService> logger) : Service, IPlanningService
    {
        public async Task<CoursePlanDto> AddLongPlanningAsync(LongPeriodCoursePlanDto coursePlanDto) {
            try {
                if (!coursePlanDto.IsValid()) throw new InvalidDtoException { InvalidDto = coursePlanDto };
                var course = await context.Courses.FindAsync(coursePlanDto.CourseId) ?? throw new EntityNotFoundException { SearchedKey = coursePlanDto.CourseId, SearchedType = typeof(CourseDto) };
                var customer = await context.Customers.FindAsync(coursePlanDto.CustomerId) ?? throw new EntityNotFoundException { SearchedKey = coursePlanDto.CustomerId, SearchedType = typeof(CustomerDto) };
                var date = coursePlanDto.StartDate;
                if (coursePlanDto.StartsAtMonday ?? true && date.DayOfWeek != DayOfWeek.Monday)
                    date = date.DayOfWeek == DayOfWeek.Monday ? date.AddDays(1) : date.AddDays(DayOfWeek.Monday - date.DayOfWeek);
                var endDate = coursePlanDto.EndDate;
                if (coursePlanDto?.EndsAtFriday ?? true && endDate.DayOfWeek != DayOfWeek.Friday)
                    endDate = date.DayOfWeek == DayOfWeek.Saturday ? endDate.AddDays(-1) : endDate.AddDays(DayOfWeek.Friday - endDate.DayOfWeek);
                var d = new List<PlanDateEntity>();
                do {
                    d.Add(new PlanDateEntity { Date = date, EndTime = new TimeOnly(18, 0), StartTime = new TimeOnly(9, 0) });
                    do { date = date.AddDays(1); } while (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday);
                } while (date.CompareTo(endDate) <= 0);
                var entity = await AddAsync(course, customer, d);
                return mapper.Map<CoursePlanDto>(entity);
            }
            catch (ServiceException) {
                throw;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception adding planning");
                throw new ServiceException(innerException: ex);
            }
        }

        public async Task<CoursePlanDto> AddPlanningAsync(CoursePlanDto coursePlanDto) {
            try {
                if (!coursePlanDto.IsValid()) throw new InvalidDtoException { InvalidDto = coursePlanDto };
                var course = await context.Courses.FindAsync(coursePlanDto.CourseId) ?? throw new EntityNotFoundException { SearchedKey = coursePlanDto.CourseId, SearchedType = typeof(CourseDto) };
                var customer = await context.Customers.FindAsync(coursePlanDto.CustomerId) ?? throw new EntityNotFoundException { SearchedKey = coursePlanDto.CustomerId, SearchedType = typeof(CustomerDto) };
                var entity = await AddAsync(course, customer, mapper.Map<IEnumerable<PlanDateEntity>>(coursePlanDto.Dates));
                return mapper.Map<CoursePlanDto>(entity);
            }
            catch (ServiceException) {
                throw;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception adding planning");
                throw new ServiceException(innerException: ex);
            }
        }

        private async Task<CoursePlanEntity> AddAsync(CourseEntity course, CustomerEntity customer, IEnumerable<PlanDateEntity> dates) {
            var entity = new CoursePlanEntity { Course = course, Customer = customer, CustomerId = customer.Id, Dates = dates };
            context.Planning.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<CoursePlanDto> AddWeeklyPlanningAsync(WeeklyCoursePlanDto coursePlanDto) {
            try {
                if (!coursePlanDto.IsValid()) throw new InvalidDtoException { InvalidDto = coursePlanDto };
                var course = await context.Courses.FindAsync(coursePlanDto.CourseId) ?? throw new EntityNotFoundException { SearchedKey = coursePlanDto.CourseId, SearchedType = typeof(CourseDto) };
                var customer = await context.Customers.FindAsync(coursePlanDto.CustomerId) ?? throw new EntityNotFoundException { SearchedKey = coursePlanDto.CustomerId, SearchedType = typeof(CustomerDto) };
                var date = coursePlanDto.StartDate;
                if (coursePlanDto.StartsAtMonday ?? true && date.DayOfWeek != DayOfWeek.Monday)
                    date = date.DayOfWeek == DayOfWeek.Monday ? date.AddDays(1) : date.AddDays(DayOfWeek.Monday - date.DayOfWeek);
                var endDate = date.AddDays(coursePlanDto.Weeks * 7);
                if (coursePlanDto?.EndsAtFriday ?? true && endDate.DayOfWeek != DayOfWeek.Friday)
                    endDate = date.DayOfWeek == DayOfWeek.Saturday ? endDate.AddDays(-1) : endDate.AddDays(DayOfWeek.Friday - endDate.DayOfWeek);
                var d = new List<PlanDateEntity>();
                do {
                    d.Add(new PlanDateEntity { Date = date, EndTime = new TimeOnly(18, 0), StartTime = new TimeOnly(9, 0) });
                    do { date = date.AddDays(1); } while (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday);
                } while (date.CompareTo(endDate) <= 0);
                var entity = await AddAsync(course, customer, d);
                return mapper.Map<CoursePlanDto>(entity);
            }
            catch (ServiceException) {
                throw;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception adding planning");
                throw new ServiceException(innerException: ex);
            }
        }

        public Task<CoursePlanDto> DeletePlanningAsync(int coursePlanId) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PlanDateDto>> GetDates(DateOnly startDate, DateOnly endDate) {
            throw new NotImplementedException();
        }

        public Task<CoursePlanDto> GetPlanningAsync(int coursePlanId) {
            throw new NotImplementedException();
        }

        public Task<CoursePlanDto> UpdatePlanningAsync(int coursePlanId, CoursePlanDto coursePlanDto) {
            throw new NotImplementedException();
        }
    }
}
