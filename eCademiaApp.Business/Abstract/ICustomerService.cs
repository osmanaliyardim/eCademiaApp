using Core.Utilities.Results;
using eCademiaApp.Entities.Concrete;

namespace eCademiaApp.Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<Customer> GetById(int id);

        IDataResult<List<Customer>> GetAll();

        IResult Add(Customer customer);

        IResult Update(Customer customer);

        IResult Delete(Customer customer);
    }
}
