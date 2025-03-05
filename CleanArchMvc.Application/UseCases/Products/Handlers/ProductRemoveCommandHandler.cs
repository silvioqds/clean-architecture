using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.UseCases.Products.Commands;
using MediatR;


namespace CleanArchMvc.Application.UseCases.Products.Handlers
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, ProductDTO>
    {
        private readonly IProductService _productService;
        public ProductRemoveCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ProductDTO> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            ProductDTO product = await _productService.GetByIdAsync(request.Id, cancellationToken);

            if (product == null)
            {
                throw new ApplicationException($"Entity could not be found");
            }

            await _productService.DeleteAsync(request.Id, cancellationToken);

            return product;
        }
    }
}
