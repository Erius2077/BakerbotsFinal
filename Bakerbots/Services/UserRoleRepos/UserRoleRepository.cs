using Bakerbots.Services.GenericRepos;
using Bakerbots.Data;
using Bakerbots.Models;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Bakerbots.Services.UserRoleRepos;

namespace Bakerbots.Services.UserRoleRepos
{
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}