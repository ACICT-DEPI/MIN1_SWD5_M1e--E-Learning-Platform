using AutoMapper;
using Enities.ViweModel;
using Enities.ViweModel.Note;
using Enities.ViweModel.Question;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impelmentations
{
	internal class QuestionServices: IQuestionSevices
	{
		private readonly IRepositoryManger _repositoryManger;
		private readonly IMapper _mapper;

		public QuestionServices(IRepositoryManger repositoryManger, IMapper mapper)
		{
			_repositoryManger = repositoryManger;
			_mapper = mapper;
		}

		public Task<ResponseVM> CreateQuestion(CreateQuestionVM question)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseVM> DeleteQuestion(int Id)
		{
			throw new NotImplementedException();
		}

		public async Task<List<GetQuestionVM>> GetAllQuestionsByCourseId(int id)
		{
			try
			{
				var questions = await _repositoryManger.questionRepository.GetAllQuestionsByCourseId(id, false);
				var questionsVM = _mapper.Map<List<GetQuestionVM>>(questions);
				return questionsVM;
			}
			catch
			{
				return new List<GetQuestionVM>();
			}
		}

		public async Task<List<GetQuestionVM>> GetAllQuestionsByLessonId(int id)
		{
			try
			{
				var questions = await _repositoryManger.questionRepository.GetAllQuestionsByCourseId(id, false);
				var questionsVM = _mapper.Map<List<GetQuestionVM>>(questions);
				return questionsVM;
			}
			catch
			{
				return new List<GetQuestionVM>();
			}
		}

		public Task<ResponseVM> UpdateQuestion(UpdateQuestionVM question)
		{
			throw new NotImplementedException();
		}
	}
}
