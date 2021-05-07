using Microsoft.EntityFrameworkCore;

namespace Web_Service.Models
{
    public class AreasdbMainContext : DbContext
    {
        public AreasdbMainContext()
        {
        }

        public DbSet<AreaInfo> Areas { get; set; }

        public AreasdbMainContext(DbContextOptions<AreasdbMainContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();           
        }

    }
}