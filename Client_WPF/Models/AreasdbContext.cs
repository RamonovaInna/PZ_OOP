using Microsoft.EntityFrameworkCore;
using Web_Service.Models;

namespace Client_WPF.Models
{
    public partial class AreasdbContext : DbContext
    {
        public AreasdbContext()
        {
        }

        public AreasdbContext(DbContextOptions<AreasdbContext> options) : base(options)
        {
        }

        public virtual DbSet<AreaInfo> Areas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var current_dir = new System.IO.DirectoryInfo(System.IO.Directory.GetCurrentDirectory());
                var application_dir = current_dir.Parent.Parent.Parent.Parent.FullName;
                string db_path = "Data Source=" + application_dir + "\\Web Service" + "\\WalkingAreas.db";

                optionsBuilder.UseSqlite(db_path);
            }
        }

    }
}