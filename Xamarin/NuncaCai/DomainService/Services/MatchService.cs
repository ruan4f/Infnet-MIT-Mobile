using DomainModel.Entities;
using DomainModel.Interfaces.Repositories;
using DomainModel.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainService.Services
{
    public class MatchService : IMatchService
    {
        private IMatchRepository _repository;

        public MatchService(IMatchRepository repository)
        {
            _repository = repository;
        }

        public async Task AddSync(Match match)
        {
            await _repository.AddSync(match);
        }

        public IEnumerable<Match> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<Match> GetByIdSync(Guid id)
        {
            return await _repository.GetByIdSync(id);
        }

        public async Task UpdateSync(Match match)
        {
            await _repository.UpdateSync(match);
        }
    }
}
