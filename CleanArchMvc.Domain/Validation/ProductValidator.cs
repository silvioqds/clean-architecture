using CleanArchMvc.Domain.Entities;
using FluentValidation;

namespace CleanArchMvc.Domain.Validation
{
    internal class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x=> x.Id).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(3);
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Stock).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Image).NotEmpty();
            RuleFor(X => X.Image).MaximumLength(250);
        }
    }
}
