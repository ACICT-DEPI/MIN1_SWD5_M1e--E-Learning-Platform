using Entites.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;
using Services.Interfaces;

namespace E_Learning.Controllers
{
    public class MaterialController : Controller
    {
        private readonly IServicesManger _servicesManger;

        public MaterialController(IServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }
        [HttpGet]
        public async Task<IActionResult> GetMaterialByLessonId(int lessonId)
        {
            if (lessonId != 0)
            {
                var result = await _servicesManger.materialServices.GetMaterial(lessonId);
                if (result.isSuccess)
                    return Ok(result.model);
                return BadRequest(result.message);
            }
            return BadRequest("the lessonid not sent");
        }
        [HttpPost]
        public async Task<IActionResult> CreateMaterialVideo(IFormFile file,string location, int lessonid)
        {
            if (ModelState.IsValid)
            {
                var result = await _servicesManger.uploadFileServices.UploadVideo(file, location);
                if (result.isSuccess)
                {
                    result = await _servicesManger.materialServices.CreateMaterial(result.model, lessonid);
                    return Ok();
                }
                return BadRequest( result.message);
            }
            return BadRequest(ModelState);
            
        }
        [HttpPost]
        public async Task<IActionResult> CreateMaterialResourses(IFormFile file, string location, int lessonid)
        {
            if (ModelState.IsValid)
            {
                var result = await _servicesManger.uploadFileServices.UploadResourses(file, location);
                if (result.isSuccess)
                {
                    result = await _servicesManger.materialServices.CreateMaterial(result.model, lessonid);
                    return Ok();
                }

                return BadRequest(result.message);
            }
            return BadRequest(ModelState);

        }
    }
    
}
