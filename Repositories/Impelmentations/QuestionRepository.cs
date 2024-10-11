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
			throw new NotImplementedException();
		}

		public Task<ResponseVM> DeleteQuestion(Question question)
		{
			throw new NotImplementedException();
		}

		public Task<IQueryable<Question>> GetAllQuestionsByCourseId(int id, bool isTracked)
		{
			throw new NotImplementedException();
		}

		public Task<IQueryable<Question>> GetAllQuestionsByLessonId(int id, bool isTracked)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseVM> UpdateQuestion(Question question)
		{
			throw new NotImplementedException();
		}
	}
}
