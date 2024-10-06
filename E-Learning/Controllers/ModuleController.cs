using Enities.ViweModel.Module;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace E_Learning.Controllers
{
	public class ModuleController : Controller
	{
		private readonly IServicesManger _servicesManger;

		public ModuleController(IServicesManger servicesManger)
        {
			_servicesManger = servicesManger;
		}
		[HttpGet]
        public async Task<IActionResult> Index()
		{
			var modules = await _servicesManger.moduleServices.GetAllModule(false);
            return View(modules);
		}

		[HttpGet]
		public async Task<IActionResult> CreateModule()
		{
			
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateModule(CreateorUpdateModuleVM model,int courseid)
		{
			var result= await _servicesManger.moduleServices.CreateNewModule(model, courseid);
			return RedirectToAction("Index");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateModule(CreateorUpdateModuleVM model ,int moduleid)
		{
			var result= await _servicesManger.moduleServices.UpdateModule(model,moduleid);
			if (result.isSuccess)
				return Ok();
			return BadRequest(result);
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteModule(int id)
		{
            var result = await _servicesManger.moduleServices.DeleteModule(id);
            if (result.isSuccess)
                return Ok();
            return BadRequest(result);
        }


    }
}
