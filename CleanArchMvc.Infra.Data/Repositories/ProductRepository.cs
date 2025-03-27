using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken)
        {
            _context.Add(product);
            await _context.SaveChangesAsync(cancellationToken);
            return product;
        }

        public async Task<Product> GetByIdAsync(int? id, CancellationToken cancellationToken)
        {
            return await _context.Products.FindAsync(id, cancellationToken);

        }

        public async Task<Product> GetProductCategoryAsync(int? id, CancellationToken cancellationToken)
        {
            return await _context.Products.Include(x => x.Category).SingleOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(CancellationToken cancellationToken)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }

        public async Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken)
        {          
            var existingProduct = _context.Products.Local.FirstOrDefault(p => p.Id == product.Id);

            if (existingProduct != null)                   
                _context.Entry(existingProduct).State = EntityState.Detached;
                       
            _context.Entry(product).State = EntityState.Modified;
            
            await _context.SaveChangesAsync(cancellationToken);
            return product;
        }

        public async Task<Product> DeleteAsync(Product product, CancellationToken cancellationToken)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
            return product;
        }
    }
}
