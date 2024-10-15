using Enities.ViweModel;
using Enities.ViweModel.Payment;
using Services.Interfaces;
using Stripe.Checkout;
using Stripe;
using Microsoft.AspNetCore.Http;
using Enities.Models;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Entites.Models;

namespace Services.Impelmentations
{
    public class StripeServices : IStripeServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        private readonly StripeSetting _stripeSetting;

        public StripeServices(IHttpContextAccessor httpContextAccessor, IOptions<StripeSetting>  stripeSetting,
            UserManager<User> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _stripeSetting = stripeSetting.Value;
        }
        public async Task<Account> CreateConnectedAccount(string email="hasnm2287@gmail.com")
        {
            StripeConfiguration.ApiKey = _stripeSetting.SecretKey;

            var accountOptions = new AccountCreateOptions
            {
                Type = "standard",  // This will create a standard account
                Email = "user@example.com",  // Replace with the user's email
                Country = "US"  // Country where the user is based
            };

            var service = new AccountService();
            var account = await service.CreateAsync(accountOptions);
            return account; // Returns the newly created account with the account ID
        }
        public async Task<string> CreateAccountLink(string accountId)
        {
            var options = new AccountLinkCreateOptions
            {
                Account = accountId,
                RefreshUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}/Stripe/refresh",
                ReturnUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}/Stripe/success",
                Type = "account_onboarding",  // This step initiates the onboarding process
            };

            var service = new AccountLinkService();
            var accountLink = await service.CreateAsync(options);

            return accountLink.Url; // This URL will be used to redirect the user
        }

        public async Task<Session> CreateCheckout(CreateCheckoutVM createCheckout)
        {
            StripeConfiguration.ApiKey = _stripeSetting.SecretKey;
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData=new SessionLineItemPriceDataOptions
                        {
                            Currency="USD",
                            ProductData=new SessionLineItemPriceDataProductDataOptions
                            {
                                Name=createCheckout.Title,
                                Description=createCheckout.Description,

                            },
                            UnitAmount=(createCheckout.Price*100),
                        },
                        Quantity=1,
                    },

                },
                Mode = "payment",
                SuccessUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}/Checkout/success",
                CancelUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}/Checkout/cancel",
                //PaymentIntentData = new SessionPaymentIntentDataOptions
                //{
                //    ApplicationFeeAmount = (long)((createCheckout.Price * 100) * 0.05),
                //    TransferData = new SessionPaymentIntentDataTransferDataOptions
                //    {
                //        Destination = "ac_R1vekr15At5HfrvdaL2xKWxrhUrHm1F5",
                //        Amount = (long)((createCheckout.Price * 100) - (long)((createCheckout.Price * 100) * 0.05))
                //    }
                //}
            };
            var service = new SessionService();
            var session =await  service.CreateAsync(options);
           return  session;
        }

        public  Task<string> GenerateStripeOAuthLink()
        {
            var clientId = _stripeSetting.ClientId;
            var redirectUri = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}/Stripe/OAuthStripe";

            // Manually construct the Stripe OAuth URL
            var url = $"https://connect.stripe.com/oauth/authorize?response_type=code&client_id={clientId}&scope=read_write&redirect_uri={redirectUri}";

            return Task.FromResult(url);
        }
        public async Task<string> ExchangeAuthorizationCodeForToken(string authorizationCode)
        {
            try
            {
                // Set up the OAuthTokenCreateOptions with authorization code and secret key
                var options = new OAuthTokenCreateOptions
                {
                    GrantType = "authorization_code",
                    Code = authorizationCode,
                    ClientSecret = _stripeSetting.SecretKey  // Use your configured secret key
                };

                // Initialize StripeClient with the API key and correct base URL for OAuth
                var stripeClient = new StripeClient(StripeConfiguration.ApiKey, connectBase: "https://connect.stripe.com");

                // Pass stripeClient to the OAuthTokenService to use the Connect base URL
                var service = new OAuthTokenService(stripeClient);

                // Make the request to exchange the authorization code for an access token
                var token = await service.CreateAsync(options);

                // Return the Stripe User ID from the token object
                return token.StripeUserId;
            }
            catch (StripeException ex)
            {
                // Log Stripe error information and throw the exception for further handling
                Console.WriteLine($"Stripe Error: {ex.Message}");
                Console.WriteLine($"Error Code: {ex.StripeError?.Code}");
                throw;
            }
        }


    }
}
