using CleanArchMvc.Domain.Entities;
using FluentValidation;

namespace CleanArchMvc.Domain.Validation
{
    internal class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(0).WithMessage("Invalid Id Value");
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(3);
        }
    }
}
