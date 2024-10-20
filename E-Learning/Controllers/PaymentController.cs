using Enities.ViweModel.Payment;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace E_Learning.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IServicesManger _servicesManger;

        public PaymentController(IServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePayment(CreatePaymentVM createPaymentVM)
        {
            try
            {
                var result= await _servicesManger.paymentServices.CreatePayment(createPaymentVM);
                if(result.isSuccess) 
                return Ok();
                return BadRequest(result.message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }
    }
}
