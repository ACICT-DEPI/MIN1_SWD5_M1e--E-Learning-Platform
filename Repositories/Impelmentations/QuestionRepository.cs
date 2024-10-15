using Enities.ViweModel;
using Entites.Data;
using Entites.Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Impelmentations
{
	public sealed class QuestionRepository : BaseRepository<Question>,IQuestionRepository
	{
		public QuestionRepository(ElearingDbcontext context) : base(context)
		{
		}

		public Task<ResponseVM> CreateQuestion(Question question)
		{
			return Create(question);
		}

		public Task<ResponseVM> UpdateQuestion(Question question)
		{
			return Update(question);
		}

		public Task<ResponseVM> DeleteQuestion(Question question)
		{
			return Delete(question);
		}

		public Task<IQueryable<Question>> GetAllQuestionsByCourseId(int id, bool isTracked)
		{
			return FindByCondition(q => q.CourseId == id, isTracked);
		}

		public Task<IQueryable<Question>> GetAllQuestionsByLessonId(int id, bool isTracked)
		{
			return FindByCondition(q => q.LessonId == id, isTracked);
		}

	}
}
