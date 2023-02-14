using Bakerbots.Services.GenericRepos;
using Bakerbots.Data;
using Bakerbots.Models;

namespace Bakerbots.Services.Order_StatusRepos
{
    public class Order_StatusRepository : GenericRepository<Order_Status>, IOrder_StatusRepository
    {
        public Order_StatusRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
