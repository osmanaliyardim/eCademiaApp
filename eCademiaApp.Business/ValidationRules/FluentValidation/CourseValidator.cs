using eCademiaApp.Entities.Concrete;
using FluentValidation;

namespace eCademiaApp.Business.ValidationRules.FluentValidation
{
    // FluentValidation checks for back-end attribute validation
    public class CourseValidator : AbstractValidator<Course>
    {
        // Validation rules for courses
        public CourseValidator()
        {
            RuleFor(c => c.Name).MinimumLength(10).MaximumLength(50).WithMessage("Course name must contain between 10-50 characters.");
            RuleFor(c => c.Name).NotNull().WithMessage("Course name can not be empty.");
            RuleFor(c => c.Price).NotNull().WithMessage("Price can not be empty.");
            RuleFor(c => c.Price).GreaterThan(0).WithMessage("Price can not set as under 0.");
            RuleFor(c => c.Description).NotNull().WithMessage("Description can not be empty.");
            RuleFor(c => c.Description).MinimumLength(20).WithMessage("Description must contain atleast 20 characters.");
            RuleFor(c => c.Point).GreaterThanOrEqualTo(0).LessThanOrEqualTo(5).WithMessage("Points must be between 0-5");
        }
    }
}
