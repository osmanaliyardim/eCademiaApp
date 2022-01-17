using Core.DataAccess.EntityFramework;
using eCademiaApp.DataAccess.Abstract;
using eCademiaApp.Entities.Concrete;

namespace eCademiaApp.DataAccess.Concrete.EntityFramework
{
    // Repository pattern implementation for Customers with EntityFramework
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, eCademiaAppContext>, ICustomerDal
    {
    }
}
