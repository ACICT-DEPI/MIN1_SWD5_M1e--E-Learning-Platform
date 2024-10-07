using Enities.ViweModel;
using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        public Task<IQueryable<Question>> GetAllQuestionsByCourseId(int id, bool isTracked);
        public Task<IQueryable<Question>> GetAllQuestionsByLessonId(int id, bool isTracked);
        public Task<ResponseVM> CreateQuestion(Question question);
    }
}
