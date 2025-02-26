using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.UseCases.Products.Commands
{
    public class ProductRemoveCommand : IRequest
    {
        public int Id { get; set; }

        public ProductRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
