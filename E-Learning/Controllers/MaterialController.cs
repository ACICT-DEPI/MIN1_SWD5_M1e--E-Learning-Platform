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
                var result= await _servicesManger.materialServices.GetMaterial(lessonId);
            if(result.isSuccess)
                return Ok(result.model);
            return BadRequest();
        }
        public async Task<string> CreateMaterial(IFormFile file,string location, int lessonid)
        {
           var result =await _servicesManger.uploadFileServices.UploadVideo(file,location);
            if (result.isSuccess)
            { 
               result= await _servicesManger.materialServices.CreateMaterial(result.message, lessonid);
            }
           
            return result.message;
            
        }
    }
    
}
