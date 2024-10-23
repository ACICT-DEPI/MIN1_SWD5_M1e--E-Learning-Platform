using AutoMapper;
using Enities.ViweModel;
using Enities.ViweModel.User;
using Entites.Models;
using Entites.ViewModel.User;
using Microsoft.AspNetCore.Identity;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impelmentations
{
	public sealed class UserServices : IUserService
	{
        private readonly IRepositoryManger _repositoryManger;
        private readonly UserManager<User> _userManager;
		private readonly IMapper _mapper;

        public UserServices(IRepositoryManger repositoryManger,
			UserManager<User> userManager,IMapper mapper) 
		{
            _repositoryManger = repositoryManger;
            _userManager = userManager;
			_mapper = mapper;
        }
		public async Task<ResponseVM> loginprocess(LoginVM model)
		{
			var user = _mapper.Map<User>(model);
			throw new NotImplementedException();
		}

		public Task<ResponseVM> Registerprocess(LoginVM model)
		{
			throw new NotImplementedException();
		}

        public async Task<ResponseVM> UpdateProfile(UpadateProfileVM model,string image)
		{ 
			var user = await _userManager.FindByIdAsync(await _repositoryManger.GetCurrentUserId());
			if (user != null)
			{
				if(_userManager.FindByNameAsync(model.UserName)!=null)
				{
					user.UserName = model.UserName;
					user.Email = model.Email;
					user.image =image;
				}
			   await _userManager.UpdateAsync(user);
				return new ResponseVM { isSuccess = true, message = "this process is success" };
			}

            return new ResponseVM { isSuccess = false, message = "this process is Faild" };

        }
    }
}
