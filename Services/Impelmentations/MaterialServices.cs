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
    public sealed class MaterialServices : IMaterialServices
    {
        private readonly IRepositoryManger _repositoryManger;
        private readonly IMapper _mapper;

        public MaterialServices(IRepositoryManger repositoryManger,IMapper mapper)
        {
            _repositoryManger = repositoryManger;
            _mapper = mapper;
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
        public async Task<ResponseVM> CreateMaterial(string[] infovideo, int lessonid)
        {
            var newmaterial = new Material();
            newmaterial.Path = infovideo[0];
            newmaterial.LessonId = lessonid;
            newmaterial.Type = infovideo[1];

            var result = await _repositoryManger.materialRepository.CreateMaterial(newmaterial);
            if (result.isSuccess)
            {
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

        public Task<ResponseVM> UpdateMaterial(string path, int lessonid)
        {
            throw new NotImplementedException();
        }
        public async Task<ResponseVM> DeleteMaterial( int id)
        {
            var material = await _repositoryManger.materialRepository.GetMaterialById(id, false);
            if (material == null)
                return new ResponseVM { isSuccess = false, message = "No Found material with this id" };
            var result = await _repositoryManger.materialRepository.DeleteMaterial(material);
            if (result.isSuccess)
            {
                try
                {
                    await _repositoryManger.Save();

                }
                catch (Exception ex)
                {
                    result.message += ex.Message;
                }
            }
            return result;
        }
    }
}
