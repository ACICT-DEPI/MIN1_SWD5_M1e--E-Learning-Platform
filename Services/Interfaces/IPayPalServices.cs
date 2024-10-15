using Enities.ViweModel.Payment;
using PayPalCheckoutSdk.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPayPalServices
    {
        public Task<Order> CreateOrder(int ammount);
        public Task<Order> CaptureOrder(string orderId);
        public Task<string> ExchangeAuthorizationCode(string authorizationCode);
         public string GeneratePayPalOAuthLink();
    }
}
