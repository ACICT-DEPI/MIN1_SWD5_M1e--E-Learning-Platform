using Enities.Models;
using Enities.ViweModel;
using Enities.ViweModel.Payment;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using Services.Interfaces;

using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Services.Impelmentations
{
    public class PayPalServices : IPayPalServices
    {
        private readonly IOptions<PayPalSetting> _paypalsetting;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly PayPalEnvironment _payPalEnvironment;
        private readonly PayPalHttpClient _payPalHttpClient;
        public PayPalServices(IOptions<PayPalSetting> paypalsetting, IHttpContextAccessor httpContextAccessor)
        {
            _paypalsetting = paypalsetting;
            _httpContextAccessor = httpContextAccessor;
            _payPalEnvironment = (_paypalsetting.Value.Environment == "sandbox") ?
                new SandboxEnvironment(_paypalsetting.Value.ClinId, _paypalsetting.Value.SecretKey)
                : new LiveEnvironment(_paypalsetting.Value.ClinId, _paypalsetting.Value.SecretKey);
            _payPalHttpClient = new PayPalHttpClient(_payPalEnvironment);
            _payPalHttpClient.SetConnectTimeout(TimeSpan.FromSeconds(120));
           
        }
        public async Task<Order> CreateOrder(int ammount)
        {
            var orderRequest = new OrdersCreateRequest();

            // Initializing the request body
            orderRequest.Prefer("return=representation");
            orderRequest.RequestBody(new OrderRequest
            {
                CheckoutPaymentIntent = "CAPTURE",
                PurchaseUnits = new List<PurchaseUnitRequest>
        {
            new PurchaseUnitRequest
            {
                AmountWithBreakdown = new AmountWithBreakdown
                {
                    CurrencyCode = "USD",
                    Value = ammount.ToString("F2")
                }
            }
        },
                ApplicationContext = new ApplicationContext
                {
                    ReturnUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}/Checkout/success",
                    CancelUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}/Checkout/cancel",
                }
            });
           // _payPalHttpClient.SetConnectTimeout = TimeSpan.FromMinutes(2);
            var response = await _payPalHttpClient.Execute(orderRequest);
            var result = response.Result<Order>();
            return result;
        }
        public async Task<Order> CaptureOrder(string orderId)
        {
            var captureRequest = new OrdersCaptureRequest(orderId);
            captureRequest.RequestBody(new OrderActionRequest());
            var response = await _payPalHttpClient.Execute(captureRequest);
            var result = response.Result<Order>();
            return result;
        }
        public string GeneratePayPalOAuthLink()
        {
            string clientId = _paypalsetting.Value.ClinId;
            string redirectUrl = "https://yourdomain.com/Paypal/Onboard";

            // Manually construct the PayPal OAuth URL
            string url = $"https://www.paypal.com/connect?flowEntry=static&client_id={clientId}&scope=email%20openid&redirect_uri={redirectUrl}";

            return url;
        }


        public async Task<string> ExchangeAuthorizationCode(string authorizationCode)
        {
            // Initialize the HttpClient for sending the request
            var httpClient = new HttpClient();

            // Set up the request to the PayPal OAuth2 token endpoint
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.sandbox.paypal.com/v1/oauth2/token");
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_paypalsetting.Value.ClinId}:{_paypalsetting.Value.SecretKey}")));

            // Set the request body with grant_type and authorization code
            var body = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "grant_type", "authorization_code" },
                { "code", authorizationCode }
            });

            request.Content = body;

            // Send the request using HttpClient
            var response = await httpClient.SendAsync(request);
            var responseData = await response.Content.ReadAsStringAsync();

            // Deserialize the response to get the access token
            var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(responseData);

            return tokenResponse.AccessToken; // Return the access token
        }

       
    }
}
