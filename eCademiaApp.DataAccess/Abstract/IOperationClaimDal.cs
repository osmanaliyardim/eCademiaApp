using Core.DataAccess;
using Core.Entities.Concrete;

namespace eCademiaApp.DataAccess.Abstract
{
    // Repository pattern implementation for operationclaims
    public interface IOperationClaimDal : IEntityRepository<OperationClaim>
    {
    }
}
