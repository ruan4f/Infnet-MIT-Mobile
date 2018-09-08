using DomainModel.Entities;
using DomainModel.Interfaces.Repositories;
using DomainModel.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace DomainService.Services
{
    public class MatchService : IMatchService
    {
        private IMatchRepository _repository;

        public MatchService(IMatchRepository repository)
        {
            _repository = repository;
        }

        public void Add(Match match)
        {
            _repository.Add(match);
        }

        public IEnumerable<Match> GetAll()
        {
            return _repository.GetAll();
        }

        public Match GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public void Update(Match match)
        {
            _repository.Update(match);
        }
    }
}
