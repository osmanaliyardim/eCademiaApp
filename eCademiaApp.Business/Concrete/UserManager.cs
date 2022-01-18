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
        // Injectable services
        private readonly ICustomerDal _customerDal;
        private readonly IUserDal _userDal;
        private readonly IInstructorDal _instructorDal;

        // Injecting our services to establish a loosely coupled connection
        public UserManager(ICustomerDal customerDal, IUserDal userDal, IInstructorDal instructorDal)
        {
            _customerDal = customerDal;
            _userDal = userDal;
            _instructorDal = instructorDal;
        }

        /// <summary>This method returns a specific user by id.</summary>
        /// <param name="id">user id</param>
        [SecuredOperation("user.view,admin")]
        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id));
        }

        /// <summary>This method returns all of users claims.</summary>
        /// <param name="user">user object</param>
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        /// <summary>This method returns a specific user by email.</summary>
        /// <param name="email">user email</param>
        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        /// <summary>This method returns a specific user detail by email.</summary>
        /// <param name="userMail">user email</param>
        public IDataResult<UserDetailDto> GetUserDetailByMail(string userMail)
        {
            return new SuccessDataResult<UserDetailDto>(_userDal.GetUserDetail(userMail));
        }

        /// <summary>This method returns all users.</summary>
        [SecuredOperation("user.view,admin")]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        /// <summary>This method saves a user to DB.</summary>
        /// <param name="user">user object</param>
        public IResult Add(User user)
        {
            _userDal.Add(user);

            return new SuccessResult(Messages.UserAdded);
        }

        /// <summary>This method updates a specific user from DB.</summary>
        /// <param name="user">user object</param>
        [SecuredOperation("user.update,admin")]
        public IResult Update(User user)
        {
            _userDal.Update(user);

            return new SuccessResult(Messages.UserUpdated);
        }

        /// <summary>This method updates a specific user from DB.</summary>
        /// <param name="userDetailForUpdate">user details for update joined table</param>
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

            var instructor = _instructorDal.Get(i => i.Id == userDetailForUpdate.InstructorId);
            instructor.CompanyName = userDetailForUpdate.CompanyName;
            _instructorDal.Update(instructor);

            return new SuccessResult(Messages.UserDetailsUpdated);
        }

        /// <summary>This method removes a specific user from DB.</summary>
        /// <param name="user">user object</param>
        [SecuredOperation("user.delete,admin")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }
    }
}
