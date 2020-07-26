using eShop.Models.CowInfo;
using eShop.Models.EntInfo;
using eShop.Models.EntInfo.Reference;
using Microsoft.EntityFrameworkCore;

namespace eShop.Models
{
    public class IasContext : DbContext
    {
        public IasContext(DbContextOptions<IasContext> options)
       : base(options)
        { }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Enterprise> Enterprises {get;set;}
        public DbSet<Farm> Farms {get;set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>()
                .HasIndex(e => e.IIN)
                .IsUnique();
            builder.Entity<Employee>()
                .HasIndex(e => e.Login)
                .IsUnique();

            builder.Entity<Enterprise>()
                .HasIndex(e => e.XIN)
                .IsUnique();
                
        }
    }

}