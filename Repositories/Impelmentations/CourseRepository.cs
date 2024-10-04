using Entites.Data;
using Entites.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Enities.ViweModel;
using Microsoft.VisualBasic;
namespace Repositories.Impelmentations
{ 
    public class CourseRepository:BaseRepository<Course>,ICourseRepository
    {
     
        private readonly ElearingDbcontext _context;
        public CourseRepository(ElearingDbcontext context) : base(context)
        {
            _context=context;
        }

        public async Task<IQueryable<Course>> GetAllCourcesAsync(bool istracked)
        {

            return await FindByCondition(c=>!c.IsDeleted,istracked);
        }

        public async Task<Course> GetCourseByIdAsync(int id, bool istracked)
        {
            return await _context.Courses
                .Include(c=>c.Modules)
                .ThenInclude(m=>m.Lessons)
                .ThenInclude(l=>l.Materials)
                .AsNoTracking()
                .FirstOrDefaultAsync(e=>e.Id==id)
                ;

        }

        public async Task<ResponseVM> CreateNewCourse(Course course)
        {
           return await Create(course);
        }

        public Task<ResponseVM> UpdateCourse(Course course)
        {
           return Update(course);
        }

        public Task<ResponseVM> DeleteCourse(Course course)
        {
          return  Delete(course);
        }
    }
}
