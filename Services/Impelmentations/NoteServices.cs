using AutoMapper;
using Enities.ViweModel;
using Enities.ViweModel.Note;
using Entites.Models;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impelmentations
{
    public sealed class NoteServices : INoteServices
    {
        private readonly IRepositoryManger _repositoryManger;
        private readonly IMapper _mapper;

        public NoteServices(IRepositoryManger repositoryManger, IMapper mapper)
        {
            _repositoryManger = repositoryManger;
            _mapper = mapper;
        }
        public async Task<GetNoteVM> GetNoteById(int noteId)
        {
            try
            {
                var note = await _repositoryManger.noteRepository.GetNoteById(noteId, false);
                var notesVM = _mapper.Map<GetNoteVM>(note);
                return notesVM;
            }
            catch
            {
                return new GetNoteVM();
            }
        }

        public async Task<List<GetNoteVM>> GetAllNotesByLessonId(int lessonId)
        {
            try
            {
                var notes = await _repositoryManger.noteRepository.GetAllNotesByLessonId(lessonId, false);
                var notesVM = _mapper.Map<List<GetNoteVM>>(notes);
                return notesVM;
            }
            catch
            {
                return new List<GetNoteVM>();
            }
        }
        public async Task<ResponseVM> CreateNote(CreateNoteVM note)
        {
            var notes = _mapper.Map<Note>(note);
            notes.UserId = "new-id";
            var result = await _repositoryManger.noteRepository.CreateNote(notes);
            if (result.isSuccess)
            {
                try
                {
                    await _repositoryManger.Save();
                }
                catch (Exception ex)
                {
                    result.message = ex.Message.ToString();
                }

            }
            return result;
        }

        public async Task<ResponseVM> UpdateNote(UpdateNoteVM note)
        {
            var oldNote = await _repositoryManger.noteRepository.GetNoteById(note.Id, false);
            if (oldNote != null)
            {
                oldNote.Text = note.Text;
                oldNote.NoteDate = note.NoteDate;
                var result = await _repositoryManger.noteRepository.UpdateNote(oldNote);

                if (result.isSuccess)
                {
                    try
                    {
                        await _repositoryManger.Save();
                    }
                    catch (Exception ex)
                    {
                        result.message = ex.Message.ToString();
                    }

                }
                return result;
            }
            return new ResponseVM { isSuccess = false, message = "Note is note found" };
        }


        public async Task<ResponseVM> DeleteNote(int Id)
        {
            var oldNote = await _repositoryManger.noteRepository.GetNoteById(Id, true);
            if (oldNote != null)
            {
                var result = await _repositoryManger.noteRepository.DeleteNote(oldNote);

                if (result.isSuccess)
                {
                    try
                    {
                        await _repositoryManger.Save();
                    }
                    catch (Exception ex)
                    {
                        result.message = ex.Message.ToString();
                    }

                }
                return result;
            }
            return new ResponseVM { isSuccess = false, message = "Note is note found" };

        }

    }
}
