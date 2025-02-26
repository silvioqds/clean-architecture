using CleanArchMvc.Application.DTO;
using MediatR;


namespace CleanArchMvc.Application.UseCases.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<ProductDTO>>
    {
    }
}
