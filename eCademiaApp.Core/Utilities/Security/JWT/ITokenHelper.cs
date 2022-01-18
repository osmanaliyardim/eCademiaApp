using Core.Entities.Concrete;

namespace eCademiaApp.Core.Utilities.Security.JWT
{
    // Signiture for token creation
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
