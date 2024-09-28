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
		public async Task<IActionResult> CreateModule(CreateModuleVM model)
		{
			var result= await _servicesManger.moduleServices.CreateNewModule(model,2);
			return RedirectToAction("Index");
		}
	}
}
