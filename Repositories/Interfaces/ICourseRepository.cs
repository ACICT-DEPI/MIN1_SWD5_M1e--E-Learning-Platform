

using Enities.ViweModel;
using Entites.Models;
using System.Linq.Expressions;

namespace Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task<IQueryable<Course>> GetAllCourcesAsync(bool istraked);
        Task<IQueryable<Course>> GetCoursesunpaidforUsers(string userid,bool istracked);
        Task<Course> GetCourseByIdAsync(int id,bool istracked );
        Task<IQueryable<Course>> GetCourseByUserIdAsync(string id, bool istracked);
        Task<ResponseVM> CreateNewCourse(Course course);
        Task<ResponseVM>UpdateCourse(Course course);
        Task<ResponseVM> DeleteCourse(Course course);
    }
}
