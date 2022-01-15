using Core.Entities.Concrete;
using Core.Utilities.Results;
using eCademiaApp.Entities.DTOs;

namespace eCademiaApp.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetById(int id);

        IDataResult<List<User>> GetAll();

        IResult Add(User user);

        IResult Update(User user);

        IResult UpdateUserDetails(UserDetailForUpdateDto userDetailForUpdate);

        IResult Delete(User user);

        IDataResult<List<OperationClaim>> GetClaims(User user);

        IDataResult<User> GetByMail(string userMail);

        IDataResult<UserDetailDto> GetUserDetailByMail(string userMail);
    }
}
