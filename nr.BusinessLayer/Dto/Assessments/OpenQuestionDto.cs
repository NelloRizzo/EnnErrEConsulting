using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nr.BusinessLayer.Dto.Assessments
{
    public class OpenQuestionDto : QuestionDto
    {
        public required string Response {  get; set; }

    }
}
