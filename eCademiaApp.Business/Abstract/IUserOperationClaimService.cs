using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace eCademiaApp.Business.Abstract
{
    // UserOperationClaim methods as a service to use them from different places with loosely coupling structure
    public interface IUserOperationClaimService
    {
        IDataResult<UserOperationClaim> GetById(int id);

        IDataResult<List<UserOperationClaim>> GetAll();

        IResult AddUserClaim(User user);

        IResult Add(UserOperationClaim userOperationClaim);

        IResult Update(UserOperationClaim userOperationClaim);

        IResult Delete(UserOperationClaim userOperationClaim);
    }
}
