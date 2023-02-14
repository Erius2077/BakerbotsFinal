using Bakerbots.Models;
using Bakerbots.Services.GenericRepos;
using Bakerbots.Data;
using static Bakerbots.Services.CategoryRepos.CategoryRepository;

namespace Bakerbots.Services.CategoryRepos
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
            public CategoryRepository(ApplicationDbContext context) : base(context)
            {
            }
        
    }
}
