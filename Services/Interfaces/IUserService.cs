using Enities.ViweModel;
using Enities.ViweModel;
using Entites.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        public Task<ResponseVM> loginprocess(LoginVM model);
		public Task<ResponseVM> Registerprocess(LoginVM model);
	}
}
