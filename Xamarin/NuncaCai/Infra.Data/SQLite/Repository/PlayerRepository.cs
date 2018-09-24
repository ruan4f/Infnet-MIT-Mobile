using DomainModel.Entities;
using DomainModel.Interfaces.Repositories;
using Infra.Data.SQLite.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task UpdateSync(Player player)
        {
            var entry = _context.Entry(player);
            entry.State = EntityState.Modified;

            _context.Players.Attach(player);
            await _context.SaveChangesAsync();
        }
    }
}
