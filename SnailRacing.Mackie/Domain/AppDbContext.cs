using Microsoft.EntityFrameworkCore;

namespace SnailRacing.Mackie.Domain
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Configuration>? Configuration { get; set; }
        public DbSet<Team>? Teams { get; set; }
        public DbSet<TeamMember>? TeamMembers { get; set; }

        ////    // The following configures EF to create a Sqlite database file in the
        ////    // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={GetDbPath()}");
        
        private static string GetDbPath()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            return Path.Join(path, "Mackie", "mackie.db");
        }
    }
}
