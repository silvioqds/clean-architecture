using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.UseCases.Products.Queries;
using MediatR;

namespace CleanArchMvc.Application.UseCases.Products.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductDTO>>
    {
        private readonly IProductService _productService;
        public GetProductsQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IEnumerable<ProductDTO>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productService.GetProductsAsync(cancellationToken);
        }
    }
}
