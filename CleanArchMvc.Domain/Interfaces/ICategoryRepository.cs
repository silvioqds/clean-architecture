using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync(CancellationToken cancellationToken);
        Task<Category> GetByIdAsync(int? id, CancellationToken cancellationToken);
        Task<Category> CreateAsync(Category category, CancellationToken cancellationToken);
        Task<Category> UpdateAsync(Category category, CancellationToken cancellationToken);
        Task<Category> DeleteAsync(Category category, CancellationToken cancellationToken);
    }
}
