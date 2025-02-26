using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category Object With Valid State")]
        public void CreateCategory_WithValidParameters_ResultValidObject()
        {
            Action action = () => new Category(1, "Perif�ricos");
            action.Should().NotThrow<DomainExceptionValidation>(); // N�o gere uma exce��o, se n�o gerar � valido
        }

        [Fact(DisplayName = "Create Category Negative ID Value With DomainExceptionInvalidId")]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Hardware");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id Value");
        }

        [Fact(DisplayName = "Create Category Name is Null With DomainExceptionRequiredName")]
        public void CreateCategory_WithNameIsNull_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<DomainExceptionValidation>();
        }
    }
}