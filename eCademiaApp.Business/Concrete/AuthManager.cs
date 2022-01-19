using Core.Entities.Concrete;
using Core.Utilities.Results;
using eCademiaApp.Business.Abstract;
using eCademiaApp.Business.BusinessAspects.Autofac;
using eCademiaApp.Business.Constants;
using eCademiaApp.Core.Utilities.Security.Hashing;
using eCademiaApp.Core.Utilities.Security.JWT;
using eCademiaApp.Entities.Concrete;
using eCademiaApp.Entities.DTOs;

namespace eCademiaApp.Business.Concrete
{   
    public class AuthManager : IAuthService
    {
        // Injectable services
        private readonly ICustomerService _customerService;
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly IUserService _userService;
        private readonly IInstructorService _instructorService;

        // Injecting our services to establish a loosely coupled connection
        public AuthManager(IUserService userService, ITokenHelper tokenHelper,
            IUserOperationClaimService userOperationClaimService, ICustomerService customerService,
            IInstructorService instructorService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _userOperationClaimService = userOperationClaimService;
            _customerService = customerService;
            _instructorService = instructorService;
        }

        /// <summary>This method saves user information to DB.</summary>
        /// <param name="userForRegisterDto">joined registration table</param>
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var newUser = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(newUser);
            var user = _userService.GetByMail(newUser.Email).Data;
            _userOperationClaimService.AddUserClaim(user);
            var newCustomer = new Customer { UserId = user.Id, CompanyName = $"{user.FirstName} {user.LastName}", Status = false };
            _customerService.Add(newCustomer);
            var newInstructor = new Instructor { UserId = user.Id, CompanyName = $"{user.FirstName} {user.LastName}",  Status = false };
            _instructorService.Add(newInstructor);

            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        /// <summary>This method lets user to sign in.</summary>
        /// <param name="userForLoginDto">joined login table</param>
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheckResult = _userService.GetByMail(userForLoginDto.Email);
            if (!userToCheckResult.Success) return new ErrorDataResult<User>(userToCheckResult.Message);

            var userToCheck = userToCheckResult.Data;
            if (userToCheck == null) return new ErrorDataResult<User>(Messages.UserNotFound);

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash,
                userToCheck.PasswordSalt)) return new ErrorDataResult<User>(Messages.PasswordError);

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        /// <summary>This method checks if user already exists.</summary>
        /// <param name="email">user email</param>
        public IResult UserExists(string email)
        {
            var userResult = _userService.GetByMail(email);
            if (!userResult.Success) return new ErrorResult(userResult.Message);
            if (userResult.Data != null) return new ErrorResult(Messages.UserAlreadyExists);

            return new SuccessResult();
        }

        /// <summary>This method creates an access and refresh token for a user.</summary>
        /// <param name="user">user object/table</param>
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claimsResult = _userService.GetClaims(user);
            if (!claimsResult.Success) return new ErrorDataResult<AccessToken>(claimsResult.Message);
            var accessToken = _tokenHelper.CreateToken(user, claimsResult.Data);

            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        /// <summary>This method checks does user have required roles or not.</summary>
        /// <param name="userMail">user email</param>
        /// <param name="requiredRoles">list of roles</param>
        [SecuredOperation("user")]
        public IResult IsAuthenticated(string userMail, List<string> requiredRoles)
        {
            if (requiredRoles != null)
            {
                var user = _userService.GetByMail(userMail).Data;
                var userClaims = _userService.GetClaims(user).Data;
                var doesUserHaveRequiredRoles =
                    requiredRoles.All(role => userClaims.Select(userClaim => userClaim.Name).Contains(role));
                if (!doesUserHaveRequiredRoles) return new ErrorResult(Messages.AuthorizationDenied);
            }

            return new SuccessResult();
        }
    }
}
