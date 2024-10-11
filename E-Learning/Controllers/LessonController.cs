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
        public async Task<IActionResult> CreateLesson(CreateorUpdateLessonVM model,int moduleid )
        {
            if (ModelState.IsValid)
            {
                var result = await _servicesManger.lessonServices.CreateLesson(model, moduleid);
                if (result.isSuccess)
                {
                    return Ok(result.message);
                }
                return BadRequest( result.message);
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateLesson(CreateorUpdateLessonVM model, int id)
        {
            if (ModelState.IsValid)
            {
                var result = await _servicesManger.lessonServices.UpdateLesson(model, id);
                if (result.isSuccess)
                {
                    return Ok(result.message);
                }
                return BadRequest(result.message);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            var result= await _servicesManger.lessonServices.DeleteLesson(id);
            if(result.isSuccess)
                return Ok(result.message);
            return BadRequest(result.message);
        }
    }
}
