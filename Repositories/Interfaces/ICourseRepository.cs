

using Enities.ViweModel;
using Entites.Models;
using System.Linq.Expressions;

namespace Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task<IQueryable<Course>> GetAllCourcesAsync(bool istraked);
        Task<Course> GetCourseByConditionAsync(int id,bool istracked );
        Task<ResponseVM> CreateNewCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(Course course);
    }
}
