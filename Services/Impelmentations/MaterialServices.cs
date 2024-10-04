using AutoMapper;
using Enities.ViweModel;
using Enities.ViweModel.Material;
using Entites.Models;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impelmentations
{
    public class MaterialServices : IMaterialServices
    {
        private readonly IRepositoryManger _repositoryManger;
        private readonly IMapper _mapper;

        public MaterialServices(IRepositoryManger repositoryManger,IMapper mapper)
        {
            _repositoryManger = repositoryManger;
            _mapper = mapper;
        }
        public async Task<ResponseVM> CreateMaterial(string path, int lessonid)
        {
            var newmaterial = new Material();
            newmaterial.Path = path;
            newmaterial.LessonId = lessonid;
            newmaterial.Type = "Video";
            
            var result=await _repositoryManger.materialRepository.UploadVideo(newmaterial);
            if (result.isSuccess) {
                try
                {
                    await _repositoryManger.Save();
                }
                catch (Exception ex)
                {
                    result.message += ex.Message.ToString();
                }
            }
            return result;
        }

        public async Task<ResponseVM> GetMaterial(int lessonid)
        {
            try
            {
               var material= await _repositoryManger.materialRepository.GetMaterialsByLessonId(lessonid);


                return new ResponseVM { isSuccess = true, message = "success", model = _mapper.Map<List<GetMaterialsVM>>(material) };
            }
            catch(Exception ex) 
            {
                return new ResponseVM { isSuccess = false, message = "Failed To Get Material" };
            }
        }
    }
}
