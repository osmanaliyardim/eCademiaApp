using Core.Entities.Concrete;
using FluentValidation;

namespace eCademiaApp.Business.ValidationRules.FluentValidation
{
    // FluentValidation checks for back-end attribute validation
    public class UserValidator : AbstractValidator<User>
    {
        // Validation rules for users
        public UserValidator()
        {
            RuleFor(u => u.Email).EmailAddress().WithMessage("Invalid email address.");
            RuleFor(u => u.Email).NotNull().WithMessage("Email address can not be null.");
            RuleFor(u => u.FirstName).NotNull().WithMessage("Firstname can not be null.");
            RuleFor(u => u.FirstName).MinimumLength(2).MaximumLength(50).WithMessage("Firstname must have 2-50 characters.");
            RuleFor(u => u.LastName).NotNull().WithMessage("Firstname can not be null.");
            RuleFor(u => u.LastName).MinimumLength(2).MaximumLength(50).WithMessage("Firstname must have 2-50 characters.");
        }
    }
}
