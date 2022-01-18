using Core.Entities.Concrete;
using Core.Utilities.Results;
using eCademiaApp.Business.Abstract;
using eCademiaApp.Business.BusinessAspects.Autofac;
using eCademiaApp.Business.Constants;
using eCademiaApp.DataAccess.Abstract;

namespace eCademiaApp.Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        // Injectable services
        private readonly IOperationClaimDal _operationClaimDal;

        // Injecting our services to establish a loosely coupled connection
        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        /// <summary>This method returns a specific operationClaim by id.</summary>
        /// <param name="id">operationClaim id</param>
        public IDataResult<OperationClaim> GetById(int id)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(o => o.Id == id));
        }

        /// <summary>This method returns a specific operationClaim by name.</summary>
        /// <param name="name">operationClaim name</param>
        public IDataResult<OperationClaim> GetByName(string name)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(o => o.Name == name));
        }

        /// <summary>This method returns all operationClaims.</summary>
        public IDataResult<List<OperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll());
        }

        /// <summary>This method saves a OperationClaim to DB.</summary>
        /// <param name="operationClaim">operationClaim object</param>
        [SecuredOperation("admin")]
        public IResult Add(OperationClaim operationClaim)
        {
            _operationClaimDal.Add(operationClaim);

            return new SuccessResult(Messages.OperationClaimAdded);
        }

        /// <summary>This method updates a specific operationClaim from DB.</summary>
        /// <param name="operationClaim">operationClaim object</param>
        [SecuredOperation("admin")]
        public IResult Update(OperationClaim operationClaim)
        {
            _operationClaimDal.Update(operationClaim);

            return new SuccessResult(Messages.OperationClaimUpdated);
        }

        /// <summary>This method removes a specific operationClaim from DB.</summary>
        /// <param name="operationClaim">operationClaim object</param>
        [SecuredOperation("admin")]
        public IResult Delete(OperationClaim operationClaim)
        {
            _operationClaimDal.Delete(operationClaim);

            return new SuccessResult(Messages.OperationClaimDeleted);
        }
    }
}
