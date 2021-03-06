using Core.Entities.Concrete;
using Core.Utilities.Results;
using eCademiaApp.Core.Utilities.Security.JWT;
using eCademiaApp.Entities.DTOs;

namespace eCademiaApp.Business.Abstract
{
    // Auth methods as a service to use them from different places with loosely coupling structure
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
        IResult IsAuthenticated(string userMail, List<string> requiredRoles);
    }
}