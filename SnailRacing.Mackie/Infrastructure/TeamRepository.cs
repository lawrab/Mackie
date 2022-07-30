﻿using SnailRacing.Mackie.Domain;

namespace SnailRacing.Mackie.Infrastructure
{
    internal class TeamRepository : ITeamRepository
    {
        public TeamDbContext _context { get; set; }

        public TeamRepository(TeamDbContext context) => _context = context;

        public void Add(Team team)
        {
            _context.Add(team);
        }

        public Task Commit()
        {
            return _context.SaveChangesAsync();
        }
    }
}
