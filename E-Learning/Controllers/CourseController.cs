using Enities.ViweModel.Course;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace E_Learning.Controllers
{
    public class CourseController : Controller
    {
        private readonly IServicesManger _servicesManger;

        public CourseController(IServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }
        public IActionResult Index()
        {
            _servicesManger.courseServices.GetAllCourcesAsync(true);
            return View();
        }
        [HttpGet]
        public IActionResult CreateCourse() 
        {
            return View();
        }
        [HttpPost]
		public async Task<IActionResult> CreateCourse(CreateCourseVM model)
		{
            if (ModelState.IsValid)
            {
               var result= await _servicesManger.courseServices.CreateNewCourse(model);
                if(result.isSuccess)
                {
                    return View("Index");
                }
                else
                    return View();
            }
			return View();
		}
	}
}
