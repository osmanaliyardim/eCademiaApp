using Microsoft.IdentityModel.Tokens;

namespace eCademiaApp.Core.Utilities.Security.Encryption
{
    // To check user creditentials with securityKey
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
