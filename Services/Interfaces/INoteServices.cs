using Enities.ViweModel;
using Enities.ViweModel.Note;
using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface INoteServices
    {
        public Task<List<GetNoteVM>> GetAllNotesByLessonId(int lessonId);
        public Task<GetNoteVM> GetNoteById(int noteId);
        public Task<ResponseVM> CreateNote(CreateNoteVM note);
        public Task<ResponseVM> UpdateNote(UpdateNoteVM note);
        public Task<ResponseVM> DeleteNote(int Id);
    }
}
