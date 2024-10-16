using Enities.ViweModel.Payment;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace E_Learning.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IServicesManger _servicesManger;

        public CheckoutController(IServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }
        public IActionResult Index()
        {
            return View("Checkout");
        }
        [HttpPost]
        public async Task<IActionResult> Checkout([FromBody] CreateCheckoutVM createCheckout)
        {
            var session = await _servicesManger.stripeServices.CreateCheckout(createCheckout);
            return Ok(new { sessionId = session.Id });
        }
        [HttpGet]
        public IActionResult Success()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Cancel()
        {
            return View();
        }
    }
}
