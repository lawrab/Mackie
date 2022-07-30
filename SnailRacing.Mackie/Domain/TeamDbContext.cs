using Microsoft.EntityFrameworkCore;

namespace SnailRacing.Mackie.Domain
{
    internal class TeamDbContext : DbContext
    {
        public DbSet<Team>? Teams { get; set; }
        public DbSet<TeamMember>? TeamMembers { get; set; }

        public TeamDbContext(DbContextOptions<TeamDbContext> options)
            : base(options)
        {
        }

        ////    // The following configures EF to create a Sqlite database file in the
        ////    // special "local" folder for your platform.
        ////    protected override void OnConfiguring(DbContextOptionsBuilder options)
        ////        => options.UseSqlite($"Data Source={DbPath}");
    }
}
