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
        Task<ResponseVM> CreateNewLesson(Lesson lesson);


	}
}
