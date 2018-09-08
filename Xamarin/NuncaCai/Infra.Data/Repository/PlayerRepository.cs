using DomainModel.Entities;
using DomainModel.Interfaces.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Infra.Data.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly EntityContext _context;
        
        public PlayerRepository(EntityContext context)
        {
            _context = context;
        }

        public void Add(Player player)
        {
            _context.Add(player);
            _context.SaveChanges();
        }

        public IEnumerable<Player> GetAll()
        {
            return _context.Players;
        }

        public Player GetById(Guid id)
        {
            return _context.Players.Find(id);
        }

        public void Update(Player player)
        {
            var entry = _context.Entry(player);
            entry.State = EntityState.Modified;

            _context.Players.Attach(player);        
            _context.SaveChanges();
        }
    }
}
