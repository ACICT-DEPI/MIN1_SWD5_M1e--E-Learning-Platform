using Microsoft.AspNetCore.Http;
using Services.Interfaces;
using Enities.ViweModel;
using Microsoft.Extensions.Hosting;

namespace Services.Implementations
{
    public class UploadFileService : IUploadFileService
    {
        private string[] videoExtensions = new string[] { ".mp4", ".m4v", ".svi" ,".webm"};
       
        

        public async Task<ResponseVM> UploadVideo(IFormFile video, string location)
        {
            string extension = Path.GetExtension(video.FileName);

            if (string.IsNullOrEmpty(extension) || !videoExtensions.Contains(extension))
            {
                return new ResponseVM { isSuccess = false, message = "The video extension should be one of the following types: {\".mp4\", \".m4v\", \".svi\"}" };
            }
            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","videos", location);
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            string filePath = Path.Combine(uploadPath, video.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                try
                {
                    await video.CopyToAsync(fileStream);
                    return new ResponseVM { isSuccess = true, message = video.FileName };

                }
                catch (Exception ex) 
                {
                    return new ResponseVM { isSuccess = false, message =  ex.Message.ToString()};
                }
            }

        }
    }
}
