using Entites.Data;
using Entites.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Enities.ViweModel;
namespace Repositories.Impelmentations
{ 
    public class CourseRepository:BaseRepository<Course>,ICourseRepository
    {
     

        public CourseRepository(ElearingDbcontext context) : base(context)
        {
            
        }

        public async Task<IQueryable<Course>> GetAllCourcesAsync(bool istracked)
        {
            return await FindAll(istracked);
        }

        public async Task<Course> GetCourseByConditionAsync(int id, bool istracked)
        {
           return await FindByCondition(c => c.Id.Equals(id), istracked).SingleOrDefaultAsync();
        }

        public async Task<ResponseVM> CreateNewCourse(Course course)
        {
           return await Create(course);
        }

        public void UpdateCourse(Course course)
        {
            Update(course);
        }

        public void DeleteCourse(Course course)
        {
            Delete(course);
        }
    }
}
