using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakerbots.Models;
using Microsoft.EntityFrameworkCore;



namespace Bakerbots.Data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Bakerbots.Models.Category> Category { get; set; } = default!;
        public DbSet<Bakerbots.Models.Order> Order { get; set; } = default!;
        public DbSet<Bakerbots.Models.Order_Status> Order_Status { get; set; } = default!;
        public DbSet<Bakerbots.Models.Product> Product { get; set; } = default!;
        public DbSet<Bakerbots.Models.User> User { get; set; } = default!;
        public DbSet<Bakerbots.Models.UserRole> UserRole { get; set; } = default!;
        

    }
}