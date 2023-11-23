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

        // Add the DbSet properties here
        public DbSet<monetary_donations> monetary_donations { get; set; }

        public DbSet<goods_donations> goods_donations { get; set; }

        public DbSet<disaster> disaster { get; set; }

        public DbSet<Allocation_Money> Allocation_Money { get; set; }
        
        public DbSet<Allocation_Goods> Allocation_Goods { get; set;}

        public DbSet<capture_purchase> capture_purchase { get; set; }

    }
}