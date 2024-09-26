
using Enities.ViweModel;
using Enities.ViweModel.Course;
using Entites.Models;

namespace Services.Interfaces
{
    public interface ICourseServices
    {
        IQueryable<GetCourseVM> GetAllCourcesAsync(bool istraked);
        GetCourseVM GetCourseByConditionAsync(int id, bool istracked);
        Task<ResponseVM> CreateNewCourse(CreateCourseVM course);

    }
}
