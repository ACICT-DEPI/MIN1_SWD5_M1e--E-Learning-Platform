using Entites.Data;
using Entites.Models;
using Repositories.Interfaces;

namespace Repositories.Impelmentations
{ 
    public class CourseRepository:BaseRepository<Course>,ICourseRepository
    {
        public CourseRepository(ElearingDbcontext context):base(context)
        {
            
        }

        public Task<IQueryable<Course>> GetAllCourcesAsync(bool istracked)
        {
            throw new NotImplementedException();
        }
    }
}
