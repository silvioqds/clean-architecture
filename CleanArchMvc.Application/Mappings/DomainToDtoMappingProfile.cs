using AutoMapper;
using CleanArchMvc.Application.DTO;
using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
