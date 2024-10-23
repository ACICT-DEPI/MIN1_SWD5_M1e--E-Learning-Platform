using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enities.ViweModel.Question
{
	public class CreateQuestionVM
	{
		public string Text { get; set; }
		public DateTime QuestionDate { get; set; } = DateTime.Now;
		public string? UserId { get; set; }
		public int CourseId { get; set; }
		public int? LessonId { get; set; }
	}
}
