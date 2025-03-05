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

        Task<IEnumerable<ProductDTO>> GetProductsAsync(CancellationToken cancellationToken);
        Task<ProductDTO> GetByIdAsync(int? id, CancellationToken cancellationToken);

        Task<ProductDTO> GetProductCategoryAsync(int? id, CancellationToken cancellationToken);
        Task<ProductDTO> AddAsync(ProductDTO dto, CancellationToken cancellationToken);
        Task<ProductDTO> UpdateAsync(ProductDTO dto, CancellationToken cancellationToken);
        Task DeleteAsync(int? id, CancellationToken cancellationToken);
    }
}

