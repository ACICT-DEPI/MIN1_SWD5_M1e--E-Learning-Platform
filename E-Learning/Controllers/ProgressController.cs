using Enities.ViweModel.Progress;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace E_Learning.Controllers
{
    public class ProgressController : Controller
    {
		private readonly IServicesManger _servicesManger;

		public ProgressController(IServicesManger servicesManger)
        {
			_servicesManger = servicesManger;
		}
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProgress(CreateProgressVM model)
        {
			if (ModelState.IsValid)
			{
				var result = await _servicesManger.progressServices.AddProgress(model);
				if (result.isSuccess)
				{
					return Ok(result);
				}
				
			}
			return BadRequest();
		}
        [HttpDelete]
        public async Task<IActionResult> DeleteProgress(int lessonid)
        {
			var result = await _servicesManger.progressServices.DeleteProgress(lessonid) ;
			if (result.isSuccess)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

    }
}
