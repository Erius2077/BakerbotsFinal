using Bakerbots.Data;
using Bakerbots.Models;
using Bakerbots.Services.GenericRepos;
using Bakerbots.Services.ProductRepos;
using Microsoft.EntityFrameworkCore;

namespace Bakerbots.Services.ProductRepos
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            var product = _context.Product.Include(p => p.Category);
            return await product.ToListAsync();
        }
        public override async Task<Product> GetByIdAsync(int id)
        {
            return await _dbSet.Include(p => p.Category).FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
