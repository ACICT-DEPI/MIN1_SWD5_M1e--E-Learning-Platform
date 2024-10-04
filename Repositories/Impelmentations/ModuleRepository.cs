using Enities.ViweModel;
using Entites.Data;
using Entites.Models;
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

        public async Task<ResponseVM> CreateNewModule(Module module)
        {
            return await Create(module);
        }


    }
}
