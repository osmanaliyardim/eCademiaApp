using eCademiaApp.Entities.DTOs;
using FluentValidation;

namespace eCademiaApp.Business.ValidationRules.FluentValidation
{
    public class UserForLoginValidator : AbstractValidator<UserForLoginDto>
    {
        // Validation rules for users
        public UserForLoginValidator()
        {
            RuleFor(u => u.Email).EmailAddress().WithMessage("Invalid email address.");
            RuleFor(u => u.Email).NotNull().WithMessage("Email address can not be null.");
            RuleFor(u => u.Password).NotNull().WithMessage("Password can not be null.");
        }
    }
}
