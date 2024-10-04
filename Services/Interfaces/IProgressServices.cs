using Enities.ViweModel;
using Enities.ViweModel.Progress;
using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProgressServices
    {
        Task<ResponseVM> AddProgress(CreateProgressVM model);
        Task<ResponseVM> DeleteProgress(int lessonid);
    }
}
