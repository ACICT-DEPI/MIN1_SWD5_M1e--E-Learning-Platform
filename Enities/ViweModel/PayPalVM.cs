using System.Text.Json.Serialization;


namespace Enities.ViweModel
{
    public class TokenResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        // Add more properties if needed based on the response from PayPal
    }
}
