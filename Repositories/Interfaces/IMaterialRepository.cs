using Enities.ViweModel;
using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IMaterialRepository
    {
        Task<IQueryable<Material>> GetMaterialsByLessonId(int lessonid);
        Task<Material> GetMaterialById(int id,bool istracked);
        Task<ResponseVM> CreateMaterial(Material material);
        Task<ResponseVM> UpsateMaterial(Material material);
        Task<ResponseVM> DeleteMaterial(Material material); 

    }
}
