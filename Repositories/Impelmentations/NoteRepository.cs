using Enities.ViweModel;
using Entites.Data;
using Entites.Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Impelmentations
{
    internal class NoteRepository : BaseRepository<Note>, INoteRepository

    {
        public NoteRepository(ElearingDbcontext context) : base(context)
        {
        }
        public Task<IQueryable<Note>> GetAllNotesByCourseId(int courseId, bool istracked)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<Note>> GetAllNotesByLessonId(int lessonId, bool istracked)
        {
            return await FindByCondition(e=>e.LessonId== lessonId, istracked);
        }
        public async Task<ResponseVM> CreateNote(Note note)
        {
            return await Create(note);
        }

        public async Task<ResponseVM> UpdateNote(Note note)
        {
            return await Update(note);
        }
        public async Task<ResponseVM> DeleteNote(Note note)
        {
            return await Delete(note);
        }

    }
}
