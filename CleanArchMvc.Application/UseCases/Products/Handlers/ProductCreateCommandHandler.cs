using AutoMapper;
using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.UseCases.Products.Commands;
using MediatR;

namespace CleanArchMvc.Application.UseCases.Products.Handlers
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, ProductDTO>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductCreateCommandHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            ProductDTO product = _mapper.Map<ProductDTO>(request);
            return await _productService.AddAsync(product, cancellationToken);
        }
    }
}
