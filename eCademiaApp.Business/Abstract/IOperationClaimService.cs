using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace eCademiaApp.Business.Abstract
{
    // OperationClaim methods as a service to use them from different places with loosely coupling structure
    public interface IOperationClaimService
    {
        IDataResult<OperationClaim> GetById(int id);

        IDataResult<OperationClaim> GetByName(string name);

        IDataResult<List<OperationClaim>> GetAll();

        IResult Add(OperationClaim operationClaim);

        IResult Update(OperationClaim operationClaim);

        IResult Delete(OperationClaim operationClaim);
    }
}
