using Core.DataAccess;
using eCademiaApp.Entities.Concrete;

namespace eCademiaApp.DataAccess.Abstract
{
    // Repository pattern implementation for customers
    public interface ICustomerDal : IEntityRepository<Customer>
    {
    }
}
