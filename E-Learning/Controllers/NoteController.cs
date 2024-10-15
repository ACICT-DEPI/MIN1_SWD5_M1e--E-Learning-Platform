using Enities.ViweModel.Note;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace E_Learning.Controllers
{
	public class NoteController : Controller
	{
		private readonly IServicesManger _servicesManger;

		public NoteController(IServicesManger servicesManger)
		{
			_servicesManger = servicesManger;
		}
		public async Task<IActionResult> GetAllNotesByLessonId(int id)
		{
			var allNotes = await _servicesManger.noteServices.GetAllNotesByLessonId(id);

			return Ok(allNotes);

		}
		[HttpPost]
		public async Task<IActionResult> CreateNote(CreateNoteVM newNote)
		{
			if (ModelState.IsValid) 
			{ 
				var result = await _servicesManger.noteServices.CreateNote(newNote);
				if (result.isSuccess)
				{
					return Ok(result.message);
				}
				return BadRequest(result.message);
			}
			return BadRequest(ModelState);
		}
		[HttpPost]
		public async Task<IActionResult> UpdateNote(UpdateNoteVM updateNote)
		{
			if (ModelState.IsValid) 
			{ 
				var result = await _servicesManger.noteServices.UpdateNote(updateNote);
				if (result.isSuccess)
				{
					return Ok(result.message);
				}
				return BadRequest(result.message);
			}
			return BadRequest(ModelState);
		}

		public async Task<IActionResult> DeleteNote(int id) 
		{
			var result = await _servicesManger.noteServices.DeleteNote(id);
			if (result.isSuccess)
			{
				return Ok(result.message);
			}
			return BadRequest(result.message);
		}

	}
}
