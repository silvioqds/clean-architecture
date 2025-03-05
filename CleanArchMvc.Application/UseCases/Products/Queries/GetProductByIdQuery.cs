using CleanArchMvc.Application.DTO;
using MediatR;

namespace CleanArchMvc.Application.UseCases.Products.Queries
{
    public class GetProductByIdQuery : IRequest<ProductDTO>
    {
        public int Id { get; set; }
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
