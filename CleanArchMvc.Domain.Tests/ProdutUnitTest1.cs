using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Tests
{
    public class ProdutUnitTest1
    {

        [Fact(DisplayName = "Create Product Object With Valid State")]
        public void CreateProduct_WithValidParameters_ResultValidState()
        {
            Action action = () => new Product(1, "Mouse", "Mouse RedDragon", 100, 20, "imagem.png");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product with negative id value and return DomainExceptionValidation")]
        public void CreateProduct_WithNegativeIdValue_ResultDomainExceptionValidation()
        {
            Action action = () => new Product(-1, "Mouse", "Mouse RedDragon", 100, 20, "imagem.png");
            action.Should().Throw<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product with null image and return DomainExceptionValidation")]
        public void CreateProduct_WithNullImage_ResultDomainExceptionValidation()
        {
            Action action = () => new Product(1, "Mouse", "Mouse RedDragon", 100, 20, null);
            action.Should().Throw<DomainExceptionValidation>();
        }

    }
}
