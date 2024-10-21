using Enities.ViweModel.Anouncment;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace E_Learning.Controllers
{
	public class AnouncmentController : Controller
	{
		private readonly IServicesManger _servicesManger;

		public AnouncmentController(IServicesManger servicesManger)
        {
			_servicesManger = servicesManger;
		}
        public async Task<IActionResult> GetAnouncmentForStudent(int Id)
		{
			try
			{
				var allAnouncment = await _servicesManger.anouncmentServices.GetAnouncmentForStudent(Id);
				return Ok(allAnouncment);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

	}
}
