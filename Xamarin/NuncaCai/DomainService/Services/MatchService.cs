﻿using DomainModel.Entities;
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

        public async Task AddSync(Guid id, Guid player1Id, Guid player2Id, Guid winnerId, DateTime date)
        {
            await _repository.AddSync(id, player1Id, player2Id, winnerId, date);
        }

        public async Task AddSync(Match match)
        {
            await _repository.AddSync(match);
        }

        public IEnumerable<Match> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Match> GetSimpleAll()
        {
            return _repository.GetSimpleAll();
        }

        public async Task<Match> GetByIdSync(Guid id)
        {
            return await _repository.GetByIdSync(id);
        }

        public void RemoveAll()
        {
            _repository.RemoveAll();
        }

        public async Task UpdateSync(Match match)
        {
            await _repository.UpdateSync(match);
        }
    }
}
