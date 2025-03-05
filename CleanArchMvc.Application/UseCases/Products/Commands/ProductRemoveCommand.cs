using CleanArchMvc.Application.DTO;
using MediatR;

namespace CleanArchMvc.Application.UseCases.Products.Commands
{
    public class ProductRemoveCommand : IRequest<ProductDTO>
    {
        public int Id { get; set; }

        public ProductRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
