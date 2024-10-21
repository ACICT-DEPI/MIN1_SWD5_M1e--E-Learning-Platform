using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Stripe;

namespace E_Learning.Controllers
{
    public class StripeController : Controller
    {
        private readonly IServicesManger _servicesManger;

        public StripeController(IServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        
        public async Task<IActionResult> GenerateStripeUrl()
        {
            try
            {
               var stripeurl= await _servicesManger.stripeServices.GenerateStripeOAuthLink();
                return Redirect(stripeurl);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> OAuthStripe([FromQuery]string code)
        {
            if (!string.IsNullOrWhiteSpace(code))
            {
                var stripeUserId= await _servicesManger.stripeServices.ExchangeAuthorizationCodeForToken(code);
            }
            return Ok(code);
        }
        public async Task<IActionResult> CreateStripeAccount()
        {
            try
            {
                // Step 1: Create a connected account on Stripe
                var account = await _servicesManger.stripeServices.CreateConnectedAccount("hasnm2287@gmail.com");

                // Step 2: Generate an account onboarding link
                var accountLink = await _servicesManger.stripeServices.CreateAccountLink(account.Id);

                // Step 3: Redirect the user to Stripe to complete onboarding
                return Redirect(accountLink);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public async Task<IActionResult> Refresh()
        {

            return Ok("you should refresh acccount");
        }
        public async Task<IActionResult> Success()
        {
            return Ok("the process success");
        }
    }
}
