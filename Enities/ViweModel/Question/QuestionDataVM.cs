using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enities.ViweModel.Question
{
    public class QuestionDataVM
    {
        public int CourseId {  get; set; }
        public int LessonId { get; set; }
        public List<GetQuestionVM> getQuestionVMs { get; set; }
    }
}
