using Core.DataAccess;
using Core.Entities.Concrete;
using eCademiaApp.Entities.DTOs;

namespace eCademiaApp.DataAccess.Abstract
{
    // Repository pattern implementation for users
    public interface IUserDal : IEntityRepository<User>
    {
        // Adding extra method to get user claims
        List<OperationClaim> GetClaims(User user);

        // Adding extra method to get user details
        UserDetailDto GetUserDetail(string userMail);
    }
}
