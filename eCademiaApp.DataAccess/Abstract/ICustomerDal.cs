using Core.DataAccess;
using eCademiaApp.Entities.Concrete;

namespace eCademiaApp.DataAccess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
    }
}
