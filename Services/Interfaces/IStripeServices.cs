using Enities.ViweModel;
using Enities.ViweModel.Payment;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public  interface IStripeServices
    {
        public Task<Session> CreateCheckout(CreateCheckoutVM createCheckout);
        public Task<string> GenerateStripeOAuthLink();
        public Task<string> ExchangeAuthorizationCodeForToken(string code);
        public Task<Account> CreateConnectedAccount(string email);
        public Task<string> CreateAccountLink(string id);        
    }
}
