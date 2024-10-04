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
        Task<ResponseVM> CreateLesson(CreateLessonVM model,int moduleid);

    }
}
