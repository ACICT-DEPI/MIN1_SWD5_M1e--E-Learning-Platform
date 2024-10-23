using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enities.ViweModel.AnswerVM
{
    public class CreateAnswerVM
    {
        public int QuestionId { get; set; }
        public string? UserId { get; set; }
        public string Text { get; set; }
        public DateTime AnswerDate { get; set; } = DateTime.Now;
    }
}
