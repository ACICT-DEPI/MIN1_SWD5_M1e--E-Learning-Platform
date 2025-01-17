﻿using Enities.ViweModel.Course;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
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
        [HttpGet]
        public async Task<IActionResult> Index()
        {
           var courses=await _servicesManger.courseServices.GetAllCourcesAsync(false);
            return View(courses);
        }
        [HttpGet]
        public async Task<IActionResult> Unbuyedcourses()
        {
            var courses = await _servicesManger.courseServices.GetCoursesunpaidforUsers(false);
            return View("Index",courses);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var course = await _servicesManger.courseServices.GetCourseByIdAsync(id, false);
                return View(course);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> ManageCourse(int id)
        {
            var course = await _servicesManger.courseServices.GetCourseByIdAsync(id,true);
            if(course!=null)
                return View(course);
             return BadRequest("course not found");
        }
        [HttpGet]
        public async Task<IActionResult> DisplayCourse(int id)
        {
            var course = await _servicesManger.courseServices.GetCourseByIdAsync(id, true);
            return View(course);
        }
        [HttpGet]
        public IActionResult CreateCourse() 
        {
            return View();
        }
        [HttpPost]
		public async Task<IActionResult> CreateCourse(CreateorUpdateCourseVM model)
		{
            var image = await _servicesManger.uploadFileServices.UplaodCourseImage(model.file);
            if (ModelState.IsValid)
            {
               var result= await _servicesManger.courseServices.CreateNewCourse(model);
                if(result.isSuccess)
                {
                    return RedirectToAction("ManageCourse",new { id = result.model.Entity.Id });
                }
                else
                    return View();
            }
			return View();
		}
	}
}
