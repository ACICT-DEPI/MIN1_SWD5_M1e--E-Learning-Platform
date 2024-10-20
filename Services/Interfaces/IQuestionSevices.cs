using Enities.ViweModel;
using Enities.ViweModel.Question;
using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
	internal interface IQuestionSevices
	{
		public Task<List<GetQuestionVM>> GetAllQuestionsByCourseId(int id);
		public Task<List<GetQuestionVM>> GetAllQuestionsByLessonId(int id);
		public Task<ResponseVM> CreateQuestion(CreateQuestionVM question);
		public Task<ResponseVM> UpdateQuestion(UpdateQuestionVM question);
		public Task<ResponseVM> DeleteQuestion(int Id);
	}
}
