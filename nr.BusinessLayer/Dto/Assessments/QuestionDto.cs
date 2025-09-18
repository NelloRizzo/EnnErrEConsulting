using nr.BusinessLayer.Dto.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nr.BusinessLayer.Dto.Assessments
{
    public class QuestionDto: BaseDto
    {
        public decimal Points {  get; set; }
        public IEnumerable<TopicDto> LinkedTopics { get; set; } = [];
        public IEnumerable<CourseDto> LinkedCourses { get; set; } = [];
    }
}
