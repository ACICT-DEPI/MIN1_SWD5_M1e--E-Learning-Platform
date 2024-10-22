using Entites.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Diagnostics;

namespace E_Learning.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> userManager;
        private readonly IServicesManger servicesManger;

        public HomeController(ILogger<HomeController> logger,UserManager<User> userManager,IServicesManger servicesManger)
        {
            this.userManager = userManager;
            this.servicesManger = servicesManger;
            _logger = logger;
        }
        public IActionResult ReadMore()
        {
            return View("readmore");
        }
        public IActionResult About()
        {
            return View("about");
        }
        public async Task<IActionResult> Index()
        {
            var course = await servicesManger.courseServices.GetAllCourcesAsync(false);
            return View(course);
        }
        [Authorize]  
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
