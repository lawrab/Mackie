using SnailRacing.Mackie.Domain;

namespace SnailRacing.Mackie.Infrastructure
{
    internal class TeamRepository : ITeamRepository
    {
        public TeamDbContext _context { get; set; }

        public TeamRepository(TeamDbContext context) => _context = context;
    }
}
