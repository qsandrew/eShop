using eShop.Models.Enterprise.Reference;
using Microsoft.EntityFrameworkCore;

namespace eShop.Models
{
    public class IasContext : DbContext
    {
        public IasContext(DbContextOptions<IasContext> options)
       : base(options)
        { }
        public DbSet<Position> Positions { get; set; }
    }
}