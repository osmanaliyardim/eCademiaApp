using Core.Utilities.Results;
using eCademiaApp.Business.Abstract;
using eCademiaApp.Business.BusinessAspects.Autofac;
using eCademiaApp.Business.Constants;
using eCademiaApp.DataAccess.Abstract;
using eCademiaApp.Entities.Concrete;

namespace eCademiaApp.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        // Injectable services
        private readonly ICustomerDal _customerDal;

        // Injecting our services to establish a loosely coupled connection
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        /// <summary>This method returns a specific customer by id.</summary>
        /// <param name="id">customer id</param>
        [SecuredOperation("customer.view,admin")]
        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == id));
        }

        /// <summary>This method returns all customers.</summary>
        [SecuredOperation("customer.view,admin")]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        /// <summary>This method saves a customer to DB.</summary>
        /// <param name="customer">customer object</param>
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);

            return new SuccessResult(Messages.CustomerAdded);
        }

        /// <summary>This method updates a specific customer from DB.</summary>
        /// <param name="customer">customer object</param>
        [SecuredOperation("customer.update,admin")]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);

            return new SuccessResult(Messages.CustomerUpdated);
        }

        /// <summary>This method removes a specific customer from DB.</summary>
        /// <param name="customer">customer object</param>
        [SecuredOperation("customer.delete,admin")]
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);

            return new SuccessResult(Messages.CustomerDeleted);
        }
    }
}
