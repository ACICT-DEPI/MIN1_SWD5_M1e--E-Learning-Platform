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
	public class ModuleServices : IModuleServices
	{
		private readonly IRepositoryManger _repositoryManger;
		private readonly IMapper _mapper;

		public ModuleServices(IRepositoryManger repositoryManger, IMapper mapper) 
		{
			_repositoryManger = repositoryManger;
			_mapper = mapper;
		}
        public async Task<List<GetModuleVM>> GetAllModule(bool istracked)
        {
            var modules= await _repositoryManger.moduleRepository.GetAllModule(istracked);
            var modulesvm = _mapper.Map<List<GetModuleVM>>(modules);
			return modulesvm;
        }
        public async Task<ResponseVM> CreateNewModule(CreateModuleVM module,int courseid)
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

       
    }
}
