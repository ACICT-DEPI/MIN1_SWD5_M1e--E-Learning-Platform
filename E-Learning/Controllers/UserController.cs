<<<<<<< Updated upstream
﻿using Microsoft.AspNetCore.Mvc;
=======
using Microsoft.AspNetCore.Mvc;
>>>>>>> Stashed changes

namespace E_Learning.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View("Login");
        }
    }
}
