using CleanArchMvc.Domain.Validation;
using FluentValidation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Base
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Stock = stock;
            this.Image = image;

            ValidateDomain();
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Stock = stock;
            this.Image = image;

            ValidateDomain();
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Stock = stock;
            this.Image = image;
            this.CategoryId = categoryId;
        }

        private void ValidateDomain()
        {
            ProductValidator validator = new ProductValidator();
            var result = validator.Validate(this);
            DomainExceptionValidation.When(!result.IsValid, string.Join(" - ", result.Errors.Select(x => x.ErrorMessage)));
        }       
    }
}
