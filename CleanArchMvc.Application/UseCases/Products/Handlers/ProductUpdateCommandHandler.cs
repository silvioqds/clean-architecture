using AutoMapper;
using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.UseCases.Products.Commands;
using MediatR;

namespace CleanArchMvc.Application.UseCases.Products.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, ProductDTO>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductUpdateCommandHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            ProductDTO product = await _productService.GetByIdAsync(request.Id, cancellationToken);

            if (product != null)
            {
                product = _mapper.Map<ProductDTO>(request);
                await _productService.UpdateAsync(product, cancellationToken);
            }

            return product;
        }
    }
}
