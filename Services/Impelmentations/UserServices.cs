using AutoMapper;
using Enities.ViweModel;
using Enities.ViweModel.User;
using Entites.Models;
using Microsoft.AspNetCore.Identity;
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
		private readonly SignInManager<User> _signInManager;
		private readonly IMapper _mapper;

		public UserServices(SignInManager<User> signInManager,IMapper mapper) {
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
	}
}
