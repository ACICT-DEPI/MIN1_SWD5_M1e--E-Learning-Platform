using Enities.ViweModel;
using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface INoteRepository
    {
<<<<<<< HEAD
        public Task<IQueryable<Note>> GetAllNotesByLessonId(int lessonId,bool istracked);
        public Task<IQueryable<Note>> GetAllNotesByCourseId(int courseId,bool istracked);
=======
       public Task<IQueryable<Note>> GetAllNotesByLessonId(int lessonId,bool istracked);
       public Task<Note> GetNoteById(int noteId,bool istracked);
>>>>>>> 8e10893e88dd6c86584d62f2f556832a856ee210
        public Task<ResponseVM> CreateNote (Note note);
        public Task<ResponseVM> UpdateNote (Note note);
        public Task<ResponseVM> DeleteNote (Note note);

    }
}
