
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            return View("Login");
        }
		public IActionResult Register()
		{
			return View("Register");
		}
	}

}
