using Enities.ViweModel.Payment;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Stripe.Checkout;

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
            try
            {
                var session = await _servicesManger.stripeServices.CreateCheckout(createCheckout);

                return Ok(new { sessionId = session.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Success(string session_id)
        {
            if (string.IsNullOrEmpty(session_id))
            {
                return BadRequest("Session ID is missing.");
            }

            try
            {
                // Retrieve the session from Stripe
                var service = new SessionService();
                var session = await service.GetAsync(session_id);

                // Perform your business logic here (e.g., saving the payment and enrollment data)
                await _servicesManger.paymentServices.CreatePayment(session);
                await _servicesManger.enrollmentServices.CreateEnrollment(session);

                return View("Success");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error processing payment: {ex.Message}");
            }
        }
        [HttpGet]
        public IActionResult Cancel()
        {
            return View();
        }
    }
}
