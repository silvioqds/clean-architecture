using CleanArchMvc.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductService
    {

        Task<IEnumerable<ProductDTO>> GetCategories();
        Task<ProductDTO> GetById(int? id);

        Task<ProductDTO> GetProductCategory(int? id);
        Task Add(ProductDTO dto);
        Task Update(ProductDTO dto);
        Task Delete(int? id);
    }
}

