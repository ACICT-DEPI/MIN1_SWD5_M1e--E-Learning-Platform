using Enities.ViweModel.Lesson;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace E_Learning.Controllers
{
    public class LessonController : Controller
    {
        private readonly IServicesManger _servicesManger;

        public LessonController(IServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }
        [HttpGet]
        public async Task<IActionResult> GetLessonByModuleId(int moduleid)
        {
            try
            {
                var result = await _servicesManger.lessonServices.GetLessons(moduleid);

				return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<string> CreateLesson(CreateLessonVM model,int moduleid )
        {
            var result = await _servicesManger.lessonServices.CreateLesson(model, moduleid);
            if (result.isSuccess)
            {
                return result.message;
            }
            return result.message;
        }
    }
}
