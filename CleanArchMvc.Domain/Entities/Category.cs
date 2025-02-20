using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Base
    {
        public string Name { get; private set; }
        public ICollection<Product> Products { get; set; }

        public Category(int id, string name)
        {
            this.Id = id;
            this.Name = name;
            ValidateDomain(name, id);
        }

        public Category(string name)
        {
            this.Name = name;
            ValidateDomain(name);
        }


        public void Update(string name)
        {
            Name = name;
        }

        private void ValidateDomain(string name, int id = 0)
        {
            CategoryValidator validator = new CategoryValidator();
            var result = validator.Validate(this);
            DomainExceptionValidation.When(!result.IsValid, string.Join(" - ", result.Errors.Select(x => x.ErrorMessage)));
        }      
    }
}
