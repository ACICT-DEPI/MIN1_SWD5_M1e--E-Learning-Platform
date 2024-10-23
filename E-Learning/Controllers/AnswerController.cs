using Microsoft.AspNetCore.Mvc;
using Enities.ViweModel.AnswerVM;
using Services.Interfaces;
namespace E_Learning.Controllers
{
    public class AnswerController : Controller
    {
        private readonly IServicesManger _servicesManger;

        public AnswerController(IServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAnswer(CreateAnswerVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _servicesManger.answerServices.CreateAnswer(model);
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
