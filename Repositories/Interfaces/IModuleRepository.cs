using Enities.ViweModel;
using Entites.Models;

namespace Repositories.Interfaces
{
    public interface IModuleRepository
    {
        Task<IEnumerable<Module>> GetAllModule(bool istracked);
        Task<ResponseVM> CreateNewModule(Module module);
    }
}
