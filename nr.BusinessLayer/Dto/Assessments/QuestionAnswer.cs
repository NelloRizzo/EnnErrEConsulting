using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nr.BusinessLayer.Dto.Assessments
{
    public class QuestionAnswer
    {
        public required string Answer { get; set; }
        public bool IsRight { get; set; }
        public decimal Weight { get; set; } 
    }
}
