using eCademiaApp.Entities.DTOs;
using FluentValidation;

namespace eCademiaApp.Business.ValidationRules.FluentValidation
{
    public class UserForRegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        // Validation rules for users
        public UserForRegisterValidator()
        {
            RuleFor(u => u.Email).EmailAddress().WithMessage("Invalid email address.")
                .NotNull().WithMessage("Email address can not be empty.");
            RuleFor(u => u.Password).NotNull().WithMessage("Password can not be empty.")
                .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
                .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                .Matches(@"[\!\$\%\&\?\+\@\*\.]+").WithMessage("Your password must contain at least one special character (!? *.).");
            RuleFor(u => u.Repassword).NotNull().WithMessage("Repassword can not be empty.")
                .Equal(u => u.Password).WithMessage("Passwords do not match.");
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("Firstname can not be empty")
               .Must(u => u.Any(char.IsLetter)).WithMessage("Firstname can only have alphabets");
            RuleFor(u => u.LastName).NotEmpty().WithMessage("Lastname can not be empty")
               .Must(u => u.Any(char.IsLetter)).WithMessage("Lastname can only have alphabets");
        }
    }
}
