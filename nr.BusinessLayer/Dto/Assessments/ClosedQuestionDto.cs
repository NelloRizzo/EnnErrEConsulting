using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nr.BusinessLayer.Dto.Assessments
{
    public class ClosedQuestionDto : QuestionDto
    {
        public IEnumerable<QuestionAnswer> Answers { get; set; } = [];
        public bool IsMultipleChoiceAllowed {  get; set; }
    }
}
