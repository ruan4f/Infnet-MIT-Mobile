using DomainModel.Entities;
using DomainModel.Interfaces.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.Repository
{
    public class MatchRepository:IMatchRepository 
    {
        private readonly EntityContext _context;

        public MatchRepository(EntityContext context)
        {
            _context = context;
        }

        public void Add(Match match)
        {
            _context.Add(match);
            _context.SaveChanges();
        }

        public IEnumerable<Match> GetAll()
        {
            return _context.Matches;
        }

        public Match GetById(Guid id)
        {
            return _context.Matches.Find(id);
        }

        public void Update(Match match)
        {
            var entry = _context.Entry(match);
            entry.State = EntityState.Modified;

            _context.Matches.Attach(match);
            _context.SaveChanges();
        }
    }
}
