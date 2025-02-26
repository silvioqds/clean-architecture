using AutoMapper;
using CleanArchMvc.Application.DTO;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {

        public DomainToDtoMappingProfile()
        {
            // ReverseMap(): Já Faz o mapeamento reverso, exemplo de CategoryDTO -> Category
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();            
        }

    }
}
