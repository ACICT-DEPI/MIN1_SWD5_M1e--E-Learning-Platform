using Microsoft.AspNetCore.Http;
using Services.Interfaces;
using Enities.ViweModel;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Services.Implementations
{
    public sealed class UploadFileService : IUploadFileService
    {
        private string[] videoExtensions = new string[] { ".mp4", ".m4v", ".svi" ,".webm"};
        private string[] fileExtensions = new string[] { ".pdf"};
        private string[] imageExtensions = new string[] { ".JPG",".PNG" };
        private string[] info = new string[2];


        public async Task<ResponseVM> UploadVideo(IFormFile video, string location)
        {
            string extension = Path.GetExtension(video.FileName);


            info[1] = "Video";
            info[0] = video.FileName;
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
                    return new ResponseVM { isSuccess = true, message = "success",model=info };

                }
                catch (Exception ex) 
                {
                    return new ResponseVM { isSuccess = false, message =  ex.Message.ToString()};
                }
            }

        }
        public async Task<ResponseVM> UploadResourses(IFormFile file, string location)
        {
            string extension = Path.GetExtension(file.FileName);
            info[1] = "File";
            info[0] = file.FileName;
            if (string.IsNullOrEmpty(extension) || !fileExtensions.Contains(extension))
            {

                return new ResponseVM { isSuccess = false, message = "The Files extension should be one of the following types: {\".pdf\"}" };
            }
            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Resourses", location);
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            string filePath = Path.Combine(uploadPath, file.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                try
                {
                    await file.CopyToAsync(fileStream);
                    return new ResponseVM { isSuccess = true, message = "success", model = info };

                }
                catch (Exception ex)
                {
                    return new ResponseVM { isSuccess = false, message = ex.Message.ToString() };
                }
            }

        }

        public async Task<ResponseVM> UplaodUserImage(IFormFile file, string location)
        {
            string extension = Path.GetExtension(file.FileName);
            info[1] = "Image";
            info[0] = file.FileName;
            if (string.IsNullOrEmpty(extension) || !imageExtensions.Contains(extension))
            {

                return new ResponseVM { isSuccess = false, message = "The Files extension should be one of the following types: {\".JPG\", \".PNG\"}" };
            }
            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UserImage", location);
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            string filePath = Path.Combine(uploadPath, file.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                try
                {
                    await file.CopyToAsync(fileStream);
                    return new ResponseVM { isSuccess = true, message = "success", model = info };

                }
                catch (Exception ex)
                {
                    return new ResponseVM { isSuccess = false, message = ex.Message.ToString() };
                }
            }
        }

       
    }
}
