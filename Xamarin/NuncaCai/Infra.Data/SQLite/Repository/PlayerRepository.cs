using DomainModel.Entities;
using DomainModel.Interfaces.Repositories;
using Infra.Data.SQLite.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Data.SQLite.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly EntitySQLiteContext _context;

        public PlayerRepository(EntitySQLiteContext context)
        {
            _context = context;
        }

        public async Task AddSync(Player player)
        {
            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Player> GetAll()
        {
            return _context.Players;
        }

        public async Task<Player> GetByIdSync(Guid id)
        {
            return await _context.Players.FindAsync(id);
        }

        public void RemoveAll()
        {
            foreach (var item in _context.Players)
                _context.Players.Remove(item);

            _context.SaveChanges();
        }

        public async Task UpdateSync(Player player)
        {
            _context.Players.First(s => s.PlayerId == player.PlayerId);
            _context.Update(player);

            await _context.SaveChangesAsync();
        }
    }
}
