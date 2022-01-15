using Core.DataAccess;
using Core.Entities.Concrete;
using eCademiaApp.Entities.DTOs;

namespace eCademiaApp.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);

        UserDetailDto GetUserDetail(string userMail);
    }
}
