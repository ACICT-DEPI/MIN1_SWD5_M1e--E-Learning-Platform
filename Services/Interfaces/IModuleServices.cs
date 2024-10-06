using Enities.ViweModel;
using Enities.ViweModel.Module;
using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IModuleServices
    {
        Task<IEnumerable<GetModuleVM>> GetAllModule(bool istracked);
       
        Task<ResponseVM> CreateNewModule(CreateorUpdateModuleVM module,int courseid);
        Task<ResponseVM> UpdateModule(CreateorUpdateModuleVM moduleVM,int courseid);
        Task<ResponseVM> DeleteModule(int id);
        
    }
}
