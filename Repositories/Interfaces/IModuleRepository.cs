﻿using Enities.ViweModel;
using Entites.Models;

namespace Repositories.Interfaces
{
    public interface IModuleRepository
    {
        Task<IEnumerable<Module>> GetAllModule(bool istracked);
        Task<Module> GetModuleById(int moduleId,bool istracked);
        Task<ResponseVM> CreateNewModule(Module module);
        Task<ResponseVM> UpdateModule(Module module);
        Task<ResponseVM> DeleteModule(Module module);
    }
}
