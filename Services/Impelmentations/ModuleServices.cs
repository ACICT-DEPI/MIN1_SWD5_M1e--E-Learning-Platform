using AutoMapper;
using Enities.ViweModel;
using Enities.ViweModel.Module;
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
	public sealed class ModuleServices : IModuleServices
	{
		private readonly IRepositoryManger _repositoryManger;
		private readonly IMapper _mapper;

		public ModuleServices(IRepositoryManger repositoryManger, IMapper mapper) 
		{
			_repositoryManger = repositoryManger;
			_mapper = mapper;
		}
        public async Task<IEnumerable<GetModuleVM>> GetAllModule(bool istracked)
        {
            var modules= await _repositoryManger.moduleRepository.GetAllModule(istracked);
            var modulesvm = _mapper.Map<IEnumerable<GetModuleVM>>(modules);
			return modulesvm;
        }
        public async Task<ResponseVM> CreateNewModule(CreateorUpdateModuleVM module,int courseid)
		{
			var newmodule= _mapper.Map<Module>(module);
			newmodule.CourseId = courseid;
			var result =await _repositoryManger.moduleRepository.CreateNewModule(newmodule);
			if (result.isSuccess)
			{
				try
				{
					await _repositoryManger.Save();
					
				}
				catch (Exception ex) { 
					result.message += ex.Message;
				}
			}
			return result;
		}

        public async Task<ResponseVM> UpdateModule(CreateorUpdateModuleVM moduleVM, int id)
        {
            var module = await _repositoryManger.moduleRepository.GetModuleById(id, false);
            if (module == null)
                return new ResponseVM { isSuccess = false, message = "No Found Course with this id" };
            var updatedmodule = _mapper.Map<Module>(moduleVM);
            updatedmodule.Id = module.Id;
            updatedmodule.CourseId = module.CourseId;
            var result = await _repositoryManger.moduleRepository.UpdateModule(updatedmodule);
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

        public async Task<ResponseVM> DeleteModule(int id)
        {
            var module = await _repositoryManger.moduleRepository.GetModuleById(id, false);
            if (module == null)
                return new ResponseVM { isSuccess = false, message = "No Found Course with this id" };
            var result = await _repositoryManger.moduleRepository.DeleteModule(module);
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
