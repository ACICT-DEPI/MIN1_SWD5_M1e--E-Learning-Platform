
using Enities.ViweModel.User;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
		public IActionResult Login(LoginVM model)
		{
			if (ModelState.IsValid) { 
			  
			}
			return View();
		}
		public IActionResult Register()
		{
			return View("Register");
		}
	}

}
