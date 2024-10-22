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
        private readonly SignInManager<User> _signInManager;
		private readonly IMapper _mapper;

		public UserServices(IRepositoryManger repositoryManger,UserManager<User> userManager,SignInManager<User> signInManager,IMapper mapper) {
            _repositoryManger = repositoryManger;
            _userManager = userManager;
            _signInManager = signInManager;
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

        public async Task<ResponseVM> UpdateProfile(UpadateProfileVM model)
        {
            //var user= await _userManager.FindByIdAsync(await _repositoryManger.Ge)
            throw new NotImplementedException();

        }
    }
}
