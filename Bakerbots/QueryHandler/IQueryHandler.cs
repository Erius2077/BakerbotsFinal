using Bakerbots.Models;

namespace Bakerbots.QueryHandler
{
    public interface IQueryHandler<M, C> where M : class where C : class
    {
        Task<IEnumerable<M>> GetAll();
        Task<Product> GetOne(C query);
    }
}
