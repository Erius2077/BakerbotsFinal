using Bakerbots.Data;
using Bakerbots.Services;
using Bakerbots.Services.CategoryRepos;
using Bakerbots.Services.OrderRepos;
using Bakerbots.Services.ProductRepos;
using Bakerbots.Services.UserRoleRepos;
using Bakerbots.Services.UserRepos;
//using Bakerbots.Services.UserRepos;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Bakerbots.Services.Order_StatusRepos;

namespace Bakerbots.Configuration
{
    public interface IUnitOfWork
    {
        IUserRoleRepository UserRoleRepository { get; }
        IOrder_StatusRepository Order_StatusRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IUserRepository UserRepository { get; }
        IProductRepository ProductRepository { get; }
        IOrderRepository OrderRepository { get; }
        void Commit();
        void Dispose();
    }
}
