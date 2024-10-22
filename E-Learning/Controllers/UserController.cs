
using Entites.ViewModel;
using Entites.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Enities.ViewModel.User;
using Entites.ViewModel.User;
using Enities.ViweModel.User;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Text.RegularExpressions;
using Repositories.Interfaces;
using Services.Interfaces;

namespace E_Learning.Controllers
{
	public class UserController : Controller
    {
		private readonly SignInManager<User> signinmanger;
		private readonly UserManager<User> userManager;
        private readonly IServicesManger _servicesManger;

        public UserController(SignInManager<User> signinmanger,UserManager<User>userManager,IServicesManger servicesManger)
        {
			this.signinmanger = signinmanger;
			this.userManager = userManager;
            _servicesManger = servicesManger;
        }
        public async Task<IActionResult> TeacherProfile()
        {
			try
			{
				var result = await _servicesManger.courseServices.GetCourseByUserIdAsync();
                return View("teacherprofile",result);
            }
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
          
        }
        public IActionResult UserProfile()
        {
            return View("profile");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
		public async Task <IActionResult> Login(LoginVM model)
		{
			if (ModelState.IsValid) {
				var result = await signinmanger.PasswordSignInAsync(model.UserName!,model.Password!,model.RememberMe,false);
				if (result.Succeeded)
				{
					return RedirectToAction("index", "Home");
				}
				ModelState.AddModelError("","invalid log in attempt ");
				return View(model);
			}
              
			return View(model);
		}
		
		public IActionResult Register()
		{
			return View("Register");
		}
		[HttpPost]
        public async Task <IActionResult> Register(RegisterVM model)
        {
			if (ModelState.IsValid) {
				User user = new()
				{
					Name = model.Name
					,
					Email = model.Email,
					password = model.Password,
					UserName = model.Name

				};
				var result = await userManager.CreateAsync(user,model.Password!);
				if (result.Succeeded) {
					await signinmanger.SignInAsync(user,false);
					RedirectToAction("Index", "Home");
				}
				foreach (var item in result.Errors) {
					ModelState.AddModelError("",item.Description);
				}
			}
            return View(model);
        }
		public async Task<IActionResult> verifyEmail() { 
		 return View();
        }
        [HttpPost]
		public async Task<IActionResult> verifyEmail(verifyEmailVM model) {
			if (ModelState.IsValid)
			{
                var allUsers = userManager.Users;
                var user = allUsers.FirstOrDefault(x => x.Email == model.Email);
                
				if (user == null)
				{
					ModelState.AddModelError("", "Somthing went wrong!");
					return View(model);
				}
				else {
					return RedirectToAction("changePassword", "User", new { username = user.UserName });
				}
			}
		 return View(model);
		}
        
        public async Task<IActionResult> changePassword(string username)
        {
			if (string.IsNullOrEmpty(username))
			{
				return RedirectToAction("verifyEmail", "User");
			}
			
            return View("changePassword",new changePasswordVM {Email=username });
	

        }
		[HttpPost]
        public async Task<IActionResult> changePassword(changePasswordVM model)
        {
			if (ModelState.IsValid)
			{
				var user = await userManager.FindByNameAsync(model.Email);
				if (user != null)
				{
					var result = await userManager.RemovePasswordAsync(user);
					if (result.Succeeded)
					{
						result = await userManager.AddPasswordAsync(user, model.NewPassword);
						return RedirectToAction("Login", "User");
					}
					else
					{
						foreach (var item in result.Errors)
						{
							ModelState.AddModelError("", item.Description);
						}
						return View(model);
					}
				}
				else
				{
					ModelState.AddModelError("", "Email not found!");
					return View(model);
				}

			}
			else 
			{
                ModelState.AddModelError("", "something went wrong! . try again ");
                return View(model);
            }
           
        }

        public async Task<IActionResult> Logout() {
			await signinmanger.SignOutAsync();
			return RedirectToAction("Index","Home");
 		}
	}

}
