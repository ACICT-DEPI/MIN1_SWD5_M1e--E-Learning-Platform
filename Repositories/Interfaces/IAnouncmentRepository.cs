using Enities.ViweModel;
using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IAnouncmentRepository
    {
        public Task<IEnumerable<Anouncment>> GetAllAnouncmentsByCourseId(int courseId,bool istracked);
        public Task<Anouncment> GetAnouncmentsById(int Id);
        public Task<ResponseVM> CreateNewAnoundment(Anouncment anouncment);
        public Task<ResponseVM> UpdateNewAnoundment(Anouncment anouncment);
        public Task<ResponseVM> DeleteNewAnoundment(Anouncment anouncment);
       
    }
}
