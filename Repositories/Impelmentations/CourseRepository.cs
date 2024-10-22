using Entites.Data;
using Entites.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Enities.ViweModel;
using Microsoft.VisualBasic;

using Microsoft.AspNetCore.Identity;
using System.Net.Http;
namespace Repositories.Impelmentations
{ 
    public class CourseRepository:BaseRepository<Course>,ICourseRepository
    {
     
        private readonly ElearingDbcontext _context;
        public CourseRepository(ElearingDbcontext context) : base(context)
        {
            _context=context;
        }
        //private async Task<string> GetUserId()
        //{
        //    var user = await _userManager.FindByNameAsync(_httpContext.HttpContext.User.Identity.Name);
        //    return user.Id;
        //}
        public async Task<IQueryable<Course>> GetAllCourcesAsync(bool istracked)
        {

            return  _context.Courses
                .Include(c=>c.User)
                .Include(c => c.Modules.Where(m => !m.IsDeleted))
                .ThenInclude(m => m.Lessons.Where(l => !l.IsDeleted))
                .ThenInclude(l => l.Materials.Where(m => !m.IsDeleted))
                .AsNoTracking()
                ;
        }
        public async Task<IQueryable<Course>> GetCoursesunpaidforUsers(string userid,bool istracked)
        {
            string currentUserId =userid;

            var courses = _context.Courses
                .Include(c=>c.User)
               .Where(course => course.InstractourId != currentUserId&&!course.IsDeleted)
               .Where(course => !_context.Enrolments.Any(enrollment =>
                   enrollment.CourseId == course.Id && enrollment.UserId == currentUserId)); 

            return istracked ? courses : courses.AsNoTracking();
        }

        public async Task<Course> GetCourseByIdAsync(int id,bool istracked)
        {
            return await _context.Courses
                .Include(c=>c.User)
                .Include(c=>c.Modules.Where(m=>!m.IsDeleted))
                .ThenInclude(m=>m.Lessons.Where(l=>!l.IsDeleted))
                .ThenInclude(l=>l.Materials.Where(m=>!m.IsDeleted))
                .AsNoTracking()
                .FirstOrDefaultAsync(e=>e.Id==id&&!e.IsDeleted)
                ;
        }

        public async Task<IQueryable<Course>> GetCourseByUserIdAsync(string id, bool istracked)
        {
            return  _context.Courses
               .Include(c => c.User)
               .Include(c => c.Modules.Where(m => !m.IsDeleted))
               .ThenInclude(m => m.Lessons.Where(l => !l.IsDeleted))
               .ThenInclude(l => l.Materials.Where(m => !m.IsDeleted))
               .AsNoTracking()
               .Where(e => e.InstractourId == id && !e.IsDeleted)
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

        public async Task<IQueryable<Course>> GetCourseByTeacherIdAsync(string id, bool istracked)
        {
            return _context.Courses
     .Include(c => c.User)
     .Include(c => c.Modules.Where(m => !m.IsDeleted))
     .ThenInclude(m => m.Lessons.Where(l => !l.IsDeleted))
     .ThenInclude(l => l.Materials.Where(m => !m.IsDeleted))
     .AsNoTracking()
     .Where(e => e.InstractourId == id && !e.IsDeleted)
     ;
        }
      
    }
}
