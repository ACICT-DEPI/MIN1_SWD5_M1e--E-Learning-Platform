
using Enities.ViweModel;
using Enities.ViweModel.Course;
using Entites.Models;

namespace Services.Interfaces
{
    public interface ICourseServices
    {
       Task<List<Course>> GetAllCourcesAsync(bool istraked);
        Task<Course> GetCourseByIdAsync(int id, bool istracked);
        Task<ResponseVM> CreateNewCourse(CreateorUpdateCourseVM course);
        Task<ResponseVM> UpdateCourse(CreateorUpdateCourseVM courseVM,int id);
        Task<ResponseVM> DeleteCourseAsync(int id);

    }
}
