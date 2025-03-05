using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.UseCases.Products.Queries;
using MediatR;


namespace CleanArchMvc.Application.UseCases.Products.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDTO>
    {
        private readonly IProductService _productService;
        public GetProductByIdQueryHandler(IProductService productService)
        {
            _productService = productService;
        }


        public async Task<ProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            ProductDTO product = await _productService.GetByIdAsync(request.Id, cancellationToken);

            if (product is null)
            {
                throw new ApplicationException("Entity not found");
            }

            return product;
        }
    }
}
