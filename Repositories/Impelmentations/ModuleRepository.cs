using Enities.ViweModel;
using Entites.Data;
using Entites.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Impelmentations
{
    public class ModuleRepository : BaseRepository<Module>, IModuleRepository
    {
        public ModuleRepository(ElearingDbcontext context) : base(context)
        {
        }
        public async Task<IEnumerable<Module>> GetAllModule(bool istracked)
        {
            return await FindByCondition(m=>!m.IsDeleted,istracked);
        }
        public async Task<Module> GetModuleById(int moduleId, bool istracked)
        {
            var module = await FindByCondition(m => m.Id == moduleId, istracked);
            return await module.FirstOrDefaultAsync();
        }
        public async Task<ResponseVM> CreateNewModule(Module module)
        {
            return await Create(module);
        }

        public async Task<ResponseVM> UpdateModule(Module module)
        {
           return await Update(module);
        }

        public async Task<ResponseVM> DeleteModule(Module module)
        {
           return await Delete(module);
        }

     
    }
}
