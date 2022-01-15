using Core.Entities.Concrete;
using Core.Utilities.Results;
using eCademiaApp.Business.Abstract;
using eCademiaApp.Business.BusinessAspects.Autofac;
using eCademiaApp.Business.Constants;
using eCademiaApp.Core.Utilities.Security.Hashing;
using eCademiaApp.DataAccess.Abstract;
using eCademiaApp.Entities.DTOs;

namespace eCademiaApp.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly ICustomerDal _customerDal;
        private readonly IUserDal _userDal;

        public UserManager(ICustomerDal customerDal, IUserDal userDal)
        {
            _customerDal = customerDal;
            _userDal = userDal;
        }

        [SecuredOperation("user.view,admin")]
        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<UserDetailDto> GetUserDetailByMail(string userMail)
        {
            return new SuccessDataResult<UserDetailDto>(_userDal.GetUserDetail(userMail));
        }

        [SecuredOperation("user.view,admin")]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);

            return new SuccessResult(Messages.UserAdded);
        }

        [SecuredOperation("user.update,admin")]
        public IResult Update(User user)
        {
            _userDal.Update(user);

            return new SuccessResult(Messages.UserUpdated);
        }

        [SecuredOperation("user")]
        public IResult UpdateUserDetails(UserDetailForUpdateDto userDetailForUpdate)
        {
            var user = GetById(userDetailForUpdate.Id).Data;

            if (!HashingHelper.VerifyPasswordHash(userDetailForUpdate.CurrentPassword, user.PasswordHash,
                user.PasswordSalt)) return new ErrorResult(Messages.PasswordError);

            user.FirstName = userDetailForUpdate.FirstName;
            user.LastName = userDetailForUpdate.LastName;
            if (!string.IsNullOrEmpty(userDetailForUpdate.NewPassword))
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(userDetailForUpdate.NewPassword, out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _userDal.Update(user);

            var customer = _customerDal.Get(c => c.Id == userDetailForUpdate.CustomerId);
            customer.CompanyName = userDetailForUpdate.CompanyName;
            _customerDal.Update(customer);

            return new SuccessResult(Messages.UserDetailsUpdated);
        }

        [SecuredOperation("user.delete,admin")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }
    }
}
