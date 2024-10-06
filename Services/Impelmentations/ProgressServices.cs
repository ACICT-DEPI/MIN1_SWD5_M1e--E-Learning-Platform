using AutoMapper;
using Enities.ViweModel;
using Enities.ViweModel.Progress;
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
	public sealed class ProgressServices : IProgressServices
	{
		private readonly IRepositoryManger _repositoryManger;
		private readonly IMapper _mapper;

		public ProgressServices(IRepositoryManger repositoryManger,IMapper mapper)
        {
			_repositoryManger = repositoryManger;
			_mapper = mapper;
		}
        public async Task<ResponseVM> AddProgress(CreateProgressVM model)
		{
			var progress = _mapper.Map<Progress>(model);
			progress.UserId = "new-id";
			var result = await _repositoryManger.progressRepository.CreateProgress(progress);
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

		public async Task<ResponseVM> DeleteProgress(int lessonid)
		{
			
			var progress = await _repositoryManger.progressRepository.GetProgress("new-id", lessonid);
			var result = new ResponseVM() ;
			if (progress!=null||progress.Count()>0)
			 result = await _repositoryManger.progressRepository.DeleteProgress(progress.First());
			else
			{
				result.isSuccess=false;
				result.message = "NoProgress with this id";
			}
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
	}
}
