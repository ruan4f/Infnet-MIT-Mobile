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

        public async Task AddSync(Guid id, Guid player1Id, Guid player2Id, Guid winnerId, DateTime date)
        {
            var player1 = await _context.Players.FindAsync(player1Id);
            var player2 = await _context.Players.FindAsync(player2Id);
            var winner = await _context.Players.FindAsync(winnerId);

            var match = new Match(id, player1, player2, winner, date);

            await _context.Matches.AddAsync(match);

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
