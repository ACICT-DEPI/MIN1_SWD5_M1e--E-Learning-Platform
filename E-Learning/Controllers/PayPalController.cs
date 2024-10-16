using Enities.ViweModel.Payment;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace E_Learning.Controllers
{
    public class PayPalController : Controller
    {
        private readonly IServicesManger _servicesManger;

        public PayPalController(IServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        public async Task<IActionResult> CreateCheckout(int amount)
        {
            try
            {
                var order = await _servicesManger.payPalServices.CreateOrder(amount);
                var approvalLink = order.Links.First(link => link.Rel == "approve").Href;
                return Redirect(approvalLink);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> Success(string token)
        {
            try
            {
                var order = await _servicesManger.payPalServices.CaptureOrder(token);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IActionResult Cancel()
        {
            return BadRequest("Payment was cancelled");
        }

        public IActionResult Onboard()
        {
            var oAuthUrl = _servicesManger.payPalServices.GeneratePayPalOAuthLink();
            return Redirect(oAuthUrl);
        }

        public async Task<IActionResult> OnboardCallback(string code)
        {
            var token = await _servicesManger.payPalServices.ExchangeAuthorizationCode(code);
            // Store merchant's PayPal ID in your database.
            return Ok(token);
        }
    }
}
