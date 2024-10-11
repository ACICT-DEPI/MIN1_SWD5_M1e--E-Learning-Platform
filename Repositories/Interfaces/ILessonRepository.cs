using Enities.ViweModel;
using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface ILessonRepository
    {
        Task<IQueryable<Lesson>> GetAllLesson(bool istracked);
        Task<IQueryable<Lesson>> GetAllLessonByMOduleId(int moduleid);
        Task<Lesson> GetLessonById(int id, bool istracked);
        Task<ResponseVM> CreateNewLesson(Lesson lesson);
        Task<ResponseVM> UpdateLesson(Lesson lesson);
        Task<ResponseVM> DeleteLesson(Lesson lesson);


	}
}
