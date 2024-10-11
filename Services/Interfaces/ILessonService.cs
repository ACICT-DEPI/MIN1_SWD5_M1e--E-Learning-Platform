using Enities.ViweModel;
using Enities.ViweModel.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ILessonService
    {
        Task<List<GetLessonVM>> GetLessons(int moduleid);
        Task<ResponseVM> CreateLesson(CreateorUpdateLessonVM model,int moduleid);
        Task<ResponseVM> UpdateLesson(CreateorUpdateLessonVM model,int id);
        Task<ResponseVM> DeleteLesson(int id);
    }
}
