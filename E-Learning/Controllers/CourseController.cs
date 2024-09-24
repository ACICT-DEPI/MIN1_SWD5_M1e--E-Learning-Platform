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
            return View("Login");
        }
    }
}
