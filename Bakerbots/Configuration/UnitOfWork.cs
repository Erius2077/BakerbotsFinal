
using Bakerbots.Data;
using Bakerbots.Services;
using Bakerbots.Services.CategoryRepos;
using Bakerbots.Services.OrderRepos;
using Bakerbots.Services.ProductRepos;
using Bakerbots.Services.UserRoleRepos;
using Bakerbots.Services.UserRepos;
using Bakerbots.Services.Order_StatusRepos;
using Bakerbots.Services.UserRepo;
//using Microsoft.AspNetCore.DataProtection.Repositories;

namespace Bakerbots.Configuration
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        public IUserRoleRepository UserRoleRepository { get; private set; }
        public IOrder_StatusRepository Order_StatusRepository { get; private set; }
        public ICategoryRepository CategoryRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public IProductRepository ProductRepository { get; private set; }

        public IOrderRepository OrderRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            UserRoleRepository = new UserRoleRepository(context);
            Order_StatusRepository = new Order_StatusRepository(context);
            CategoryRepository = new CategoryRepository(context);
            UserRepository = new UserRepository(context);
            ProductRepository = new ProductRepository(context);
            OrderRepository = new OrderRepository(context);

        }

        public void Commit()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}