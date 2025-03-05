using CleanArchMvc.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync(CancellationToken cancellationToken);
        Task<CategoryDTO> GetByIdAsync(int? id, CancellationToken cancellationToken);
        Task AddAsync(CategoryDTO dto, CancellationToken cancellationToken);
        Task UpdateAsync(CategoryDTO dto, CancellationToken cancellationToken);
        Task DeleteAsync(int? id, CancellationToken cancellationToken);
    }
}
