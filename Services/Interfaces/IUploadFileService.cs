using Enities.ViweModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUploadFileService
    {
        public Task<ResponseVM> UploadVideo(IFormFile video, string location);
        public Task<ResponseVM> UploadResourses(IFormFile resourse, string location);
    }
}
