using Enities.ViweModel;
using Entites.Data;
using Entites.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Impelmentations
{
    public class MaterialRepository : BaseRepository<Material>, IMaterialRepository
    {
        public MaterialRepository(ElearingDbcontext context) : base(context)
        {
        }

      

        public async Task<IQueryable<Material>> GetMaterialsByLessonId(int lessonid)
        {
            return await FindByCondition((m => m.LessonId == lessonid&& !m.IsDeleted), false);
        }
        public async Task<Material> GetMaterialById(int id, bool istracked)
        {
             var material= await FindByCondition(m=>m.Id==id&&!m.IsDeleted, istracked);
            return await material.FirstOrDefaultAsync();
        }
        public async Task<ResponseVM> CreateMaterial(Material material)
        {
           return await Create(material);
        }

        public async Task<ResponseVM> UpsateMaterial(Material material)
        {
           return await Update(material);
        }
        public async Task<ResponseVM> DeleteMaterial(Material material)
        {
           return await Delete(material);   
        }

      
    }
}
