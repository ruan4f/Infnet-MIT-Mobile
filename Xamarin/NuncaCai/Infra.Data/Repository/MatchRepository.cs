using DomainModel.Entities;
using DomainModel.Interfaces.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository
{
    public class MatchRepository : IMatchRepository
    {
        private readonly EntityContext _context;

        public MatchRepository(EntityContext context)
        {
            _context = context;
        }

        public async Task AddSync(Match match)
        {
            await _context.AddAsync(match);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Match> GetAll()
        {
            return _context.Matches;
        }

        public async Task<Match> GetByIdSync(Guid id)
        {
            return await _context.Matches.FindAsync(id);
        }

        public async Task UpdateSync(Match match)
        {
            var entry = _context.Entry(match);
            entry.State = EntityState.Modified;

            _context.Matches.Attach(match);
            await _context.SaveChangesAsync();
        }
    }
}
