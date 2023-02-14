using Bakerbots.Models;
using Bakerbots.Services.GenericRepos;
using Bakerbots.Data;
using Microsoft.EntityFrameworkCore;
//using Bakerbots.Services.O;
using Bakerbots.Services.OrderRepos;

namespace Bakerbots.Services.OrderRepos
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Order>> GetAllAsync()
        {
            var order = _context.Order.Include(o => o.Status).Include(o => o.User);
            return await order.ToListAsync();
        }
        public override async Task<Order> GetByIdAsync(int id)
        {
            return await _dbSet.Include(o => o.Status).Include(o => o.User).FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
