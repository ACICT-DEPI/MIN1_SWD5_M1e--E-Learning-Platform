using AutoMapper;
using Enities.ViweModel;
using Enities.ViweModel.Note;
using Enities.ViweModel.Question;
using Entites.Models;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impelmentations
{
	internal class QuestionServices: IQuestionServices
	{
		private readonly IRepositoryManger _repositoryManger;
		private readonly IMapper _mapper;

		public QuestionServices(IRepositoryManger repositoryManger, IMapper mapper)
		{
			_repositoryManger = repositoryManger;
			_mapper = mapper;
		}

		public async Task<ResponseVM> CreateQuestion(CreateQuestionVM question)
		{
            var questionMapped = _mapper.Map<Question>(question);
            questionMapped.UserId = await _repositoryManger.GetUserId();
            var result = await _repositoryManger.questionRepository.CreateQuestion(questionMapped);
            if (result.isSuccess)
            {
                try
                {
                    await _repositoryManger.Save();
                }
                catch (Exception ex)
                {
                    result.message = ex.Message.ToString();
                }

            }
            return result;
        }

        public async Task<ResponseVM> UpdateQuestion(UpdateQuestionVM question)
        {
            var oldQuestion = await _repositoryManger.questionRepository.GetQuestionById(question.Id, false);
            if (oldQuestion != null)
            {
                oldQuestion.Text = question.Text;
                oldQuestion.QuestionDate = question.QuestionDate;
                var result = await _repositoryManger.questionRepository.UpdateQuestion(oldQuestion);

                if (result.isSuccess)
                {
                    try
                    {
                        await _repositoryManger.Save();
                    }
                    catch (Exception ex)
                    {
                        result.message = ex.Message.ToString();
                    }

                }
                return result;
            }
            return new ResponseVM { isSuccess = false, message = "Question is not found" };
        }

        public async Task<ResponseVM> DeleteQuestion(int Id)
		{
            var oldQuestion = await _repositoryManger.questionRepository.GetQuestionById(Id, true);
            if (oldQuestion != null)
            {
                var result = await _repositoryManger.questionRepository.DeleteQuestion(oldQuestion);

                if (result.isSuccess)
                {
                    try
                    {
                        await _repositoryManger.Save();
                    }
                    catch (Exception ex)
                    {
                        result.message = ex.Message.ToString();
                    }

                }
                return result;
            }
            return new ResponseVM { isSuccess = false, message = "Question is not found" };
        }

		public async Task<List<GetQuestionVM>> GetAllQuestionsByCourseId(int id)
		{
			try
			{
				var questions = await _repositoryManger.questionRepository.GetAllQuestionsByCourseId(id, false);
				var questionsVM = _mapper.Map<List<GetQuestionVM>>(questions);
				return questionsVM;
			}
			catch(Exception ex) 
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

		
	}
}
