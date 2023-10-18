using Disaster_Allievation_Foundation_.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Allievation_Foundation_.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<monetary_donations> monetary_donations { get; set; }

        public DbSet<goods_donations> goods_donations { get; set; }

        public DbSet<disaster> disaster { get; set; }

        public DbSet<inventory> inventory { get; set; }
    }
}