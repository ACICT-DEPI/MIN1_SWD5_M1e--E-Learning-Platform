using Enities.ViweModel.Question;
using Microsoft.AspNetCore.Mvc;
using Services.Impelmentations;
using Services.Interfaces;
using System.Xml.Linq;

namespace E_Learning.Controllers
{
	public class QuestionController : Controller
	{
		private readonly IServicesManger _servicesManger;

		public QuestionController(IServicesManger servicesManger)
        {
			_servicesManger = servicesManger;
		}

        public async Task<IActionResult> GetAllQuestionsAndAnswersByCourseId(int id,int LessonId)
		{
			var QestionsAndAnswers=await _servicesManger.questionServices.GetAllQuestionsByCourseId(id);
			QuestionDataVM qvm=new QuestionDataVM();
			qvm.CourseId = id;
			qvm.LessonId = LessonId;
			qvm.getQuestionVMs = QestionsAndAnswers;
            return PartialView("_QuestionPartialView",qvm);
		}

		[HttpPost]
		public async Task<IActionResult> CreateQuestion(CreateQuestionVM model)
		{

            if (ModelState.IsValid)
            {
                var result = await _servicesManger.questionServices.CreateQuestion(model);
                if (result.isSuccess)
                {
                    return Ok(result.model);
                }
                return BadRequest(result.message);
            }
            return BadRequest(ModelState);
        }
	}
}
