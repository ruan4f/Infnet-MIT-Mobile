using DomainModel.Entities;
using DomainModel.Interfaces.Repositories;
using Infra.Data.SQLite.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Data.SQLite.Repository
{
    public class MatchRepository : IMatchRepository
    {
        private readonly EntitySQLiteContext _context;

        public MatchRepository(EntitySQLiteContext context)
        {
            _context = context;
        }

        public async Task AddSync(Match match)
        {
            Match newMatch = new Match(match.MatchId, match.MatchDate);

            var player1 = await _context.Players.FindAsync(match.MatchPlayed.Player1Id);
            var player2 = await _context.Players.FindAsync(match.MatchPlayed.Player2Id);
            var winner = await _context.Players.FindAsync(match.MatchPlayed.WinnerId);

            await _context.Matches.AddAsync(newMatch);

            newMatch.MatchesPlayed.Add(new MatchPlayed(match, player1, player2, winner));

            await _context.SaveChangesAsync();
        }

        public async Task AddSync(Guid id, Guid player1Id, Guid player2Id, Guid winnerId, DateTime date)
        {
            Match newMatch = new Match(id, date);

            var player1 = await _context.Players.FindAsync(player1Id);
            var player2 = await _context.Players.FindAsync(player2Id);
            var winner = await _context.Players.FindAsync(winnerId);

            await _context.Matches.AddAsync(newMatch);

            newMatch.MatchesPlayed.Add(new MatchPlayed(newMatch, player1, player2, winner));

            await _context.SaveChangesAsync();
        }

        public IEnumerable<Match> GetAll()
        {
            return _context.Matches
                            .Include(m => m.MatchesPlayed)
                                .ThenInclude(mp => mp.Player1)
                            .Include(m => m.MatchesPlayed)
                                .ThenInclude(mp => mp.Player2)
                            .Include(m => m.MatchesPlayed)
                                .ThenInclude(mp => mp.Winner);
        }

        public IEnumerable<Match> GetSimpleAll()
        {
            return _context.Matches;
        }

        public async Task<Match> GetByIdSync(Guid id)
        {
            return await _context.Matches.FindAsync(id);
        }

        public void RemoveAll()
        {
            var matches = _context.Matches
                            .Include(m => m.MatchesPlayed)
                                .ThenInclude(mp => mp.Player1)
                            .Include(m => m.MatchesPlayed)
                                .ThenInclude(mp => mp.Player2)
                            .Include(m => m.MatchesPlayed)
                                .ThenInclude(mp => mp.Winner);

            foreach (var item in matches)
            {
                item.MatchesPlayed.Clear();
                _context.Matches.Remove(item);
            }

            _context.SaveChanges();
        }

        public async Task UpdateSync(Match match)
        {
            _context.Matches.First(s => s.MatchId == match.MatchId);
            _context.Update(match);            

            await _context.SaveChangesAsync();
        }
    }
}
