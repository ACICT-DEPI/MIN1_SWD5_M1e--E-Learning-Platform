using Enities.ViweModel;
using Entites.Data;
using Entites.Models;
using Microsoft.EntityFrameworkCore;
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
		private readonly ElearingDbcontext _context;

		public QuestionRepository(ElearingDbcontext context) : base(context)
		{
			_context = context;
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

        public  async Task<Question> GetQuestionById(int id, bool isTracked)
		{
			var question = await FindByCondition(x => x.Id == id,isTracked);
			return question.First();
		}


        public async Task<IQueryable<Question>> GetAllQuestionsByCourseId(int id, bool isTracked)
		{
			return _context.Questions.Include(x => x.Answers).AsNoTracking().Where(x => x.CourseId == id);
		}

		public Task<IQueryable<Question>> GetAllQuestionsByLessonId(int id, bool isTracked)
		{
			return FindByCondition(q => q.LessonId == id, isTracked);
		}

	}
}
