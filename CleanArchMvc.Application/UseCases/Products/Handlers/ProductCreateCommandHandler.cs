using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.UseCases.Products.Commands;
using CleanArchMvc.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.UseCases.Products.Handlers
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, ProductDTO>
    {
        private readonly IProductService _productService;
        public ProductCreateCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ProductDTO> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            ProductDTO product = new ProductDTO()
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Stock = request.Stock,
                Image = request.Image,
                CategoryId = request.CategoryId,
            };

            return await _productService.Add(product);
        }
    }
}
