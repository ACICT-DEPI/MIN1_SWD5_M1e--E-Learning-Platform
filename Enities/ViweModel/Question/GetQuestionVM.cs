using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enities.ViweModel.Question
{
	public class GetQuestionVM
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public DateTime QuestionDate { get; set; }
		public string UserId { get; set; }
	}
}
