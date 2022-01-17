using Core.Entities.Concrete;
using Core.Utilities.Results;
using eCademiaApp.Business.Abstract;
using eCademiaApp.Business.BusinessAspects.Autofac;
using eCademiaApp.Business.Constants;
using eCademiaApp.DataAccess.Abstract;

namespace eCademiaApp.Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        // Injectable services
        private readonly IOperationClaimService _operationClaimService;
        private readonly IUserOperationClaimDal _userOperationClaimDal;

        // Injecting our services to establish a loosely coupled connection
        public UserOperationClaimManager(IOperationClaimService operationClaimService,
            IUserOperationClaimDal userOperationClaimDal
        )
        {
            _operationClaimService = operationClaimService;
            _userOperationClaimDal = userOperationClaimDal;
        }

        /// <summary>This method returns a specific userOperationClaim by id.</summary>
        /// <param name="UserOperationClaim">userOperationClaim id</param>
        [SecuredOperation("admin")]
        public IDataResult<UserOperationClaim> GetById(int id)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(u => u.Id == id));
        }

        /// <summary>This method returns all userOperationClaim.</summary>
        [SecuredOperation("admin")]
        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll());
        }

        /// <summary>This method saves a userOperationClaim to a user.</summary>
        /// <param name="User">user object</param>
        public IResult AddUserClaim(User user)
        {
            var operationClaim = _operationClaimService.GetByName("user").Data;
            var userOperationClaim = new UserOperationClaim { OperationClaimId = operationClaim.Id, UserId = user.Id };
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimAdded);
        }

        /// <summary>This method saves a userOperationClaim to DB.</summary>
        /// <param name="UserOperationClaim">userOperationClaim object</param>
        [SecuredOperation("admin")]
        public IResult Add(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimAdded);
        }

        /// <summary>This method updates a specific userOperationClaim from DB.</summary>
        /// <param name="UserOperationClaim">userOperationClaim object</param>
        [SecuredOperation("admin")]
        public IResult Update(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Update(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimUpdated);
        }

        /// <summary>This method removes a specific userOperationClaim from DB.</summary>
        /// <param name="UserOperationClaim">userOperationClaim object</param>
        [SecuredOperation("admin")]
        public IResult Delete(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Delete(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimDeleted);
        }
    }
}
