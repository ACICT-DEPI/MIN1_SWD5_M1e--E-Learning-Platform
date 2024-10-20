using Enities.ViweModel.Enrollment;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace E_Learning.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IServicesManger _servicesManger;

        public EnrollmentController(IServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }
        [HttpGet]
        public async Task<IActionResult> GetEnrollmentsForUser()
        {
            try
            {
                var enrollments = await _servicesManger.enrollmentServices.GettEnrollmentByUserId();
                return View(enrollments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateEnrollment(CreateEnrollmentVM createEnrollmentVM)
        {
            try
            {
                var result = await _servicesManger.enrollmentServices.CreateEnrollment(createEnrollmentVM);
                if (result.isSuccess)
                    return Ok();
                return BadRequest(result.message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
