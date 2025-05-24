using Microsoft.EntityFrameworkCore;
using ShopTARge23.Core.Domains;

namespace ShopTARge23.Data
{
    public class ShopTARge23Context : DbContext
    {
        public ShopTARge23Context(DbContextOptions<ShopTARge23Context> options)
            : base(options)
        {
        }
        public DbSet<SpaceShip> SpaceShips { get; set; }

    }
}
