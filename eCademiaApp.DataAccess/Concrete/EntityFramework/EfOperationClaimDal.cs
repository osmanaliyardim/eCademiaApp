using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using eCademiaApp.DataAccess.Abstract;

namespace eCademiaApp.DataAccess.Concrete.EntityFramework
{
    // Repository pattern implementation for OperationClaims with EntityFramework
    public class EfOperationClaimDal : EfEntityRepositoryBase<OperationClaim, eCademiaAppContext>, IOperationClaimDal
    {
    }
}
