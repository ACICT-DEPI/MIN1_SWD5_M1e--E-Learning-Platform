using Enities.ViweModel;
using Enities.ViweModel.Material;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IMaterialServices
    {
        Task<ResponseVM> GetMaterial(int lessonid);
        Task<ResponseVM> CreateMaterial(string[] infovideo,int lessonid);
        Task<ResponseVM> UpdateMaterial(string path,int lessonid);
        Task<ResponseVM> DeleteMaterial(int id);
    }
}
