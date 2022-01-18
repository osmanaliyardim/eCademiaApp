namespace eCademiaApp.Core.Utilities.Security.JWT
{
    // AccessToken entity
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
