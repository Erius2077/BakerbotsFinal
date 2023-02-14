using Bakerbots.Models;
using Bakerbots.Services.GenericRepos;
using Bakerbots.Data;
using Microsoft.EntityFrameworkCore;
using Bakerbots.Services.UserRepos;

namespace Bakerbots.Services.UserRepo
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {

        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override async Task<IEnumerable<User>> GetAllAsync()
        {
            var user = _context.User.Include(u => u.UserRole);
            return await user.ToListAsync();
        }

        public override async Task<User> GetByIdAsync(int id)
        {

            return await _dbSet.Include(u => u.UserRole).FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}