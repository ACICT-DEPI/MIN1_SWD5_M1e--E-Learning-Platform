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
        Task<ResponseVM> CreateMaterial(string path,int lessonid);
    }
}
