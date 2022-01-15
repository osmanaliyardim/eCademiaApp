using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using eCademiaApp.DataAccess.Abstract;

namespace eCademiaApp.DataAccess.Concrete.EntityFramework
{
    public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, eCademiaAppContext>, IUserOperationClaimDal
    {
    }
}
