using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        public async Task<Category> CreateAsync(Category category, CancellationToken cancellationToken)
        {
            _context.Add(category);
            await _context.SaveChangesAsync(cancellationToken);
            return category;
        }

        public async Task<Category?> GetByIdAsync(int? id, CancellationToken cancellationToken)
        {
            return await _context.Categories.FindAsync(id, cancellationToken) ?? null;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync(CancellationToken cancellationToken)
        {
            return await _context.Categories.ToListAsync(cancellationToken);
        }

        public async Task<Category> DeleteAsync(Category category, CancellationToken cancellationToken)
        {
            _context.Remove(category);
            await _context.SaveChangesAsync(cancellationToken);
            return category;
        }

        public async Task<Category> UpdateAsync(Category category, CancellationToken cancellationToken)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync(cancellationToken);
            return category;

        }
    }
}
