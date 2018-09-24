using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModel.Entities;
using DomainModel.Interfaces.Services;
using NuncaCai.Application.Interfaces;

namespace NuncaCai.Application.Services
{
    public class MatchAppService : IMatchAppService
    {
        private readonly IMatchService _matchService;
        private readonly IPlayerService _playerService;

        public MatchAppService(IMatchService matchService, IPlayerService playerService)
        {
            _matchService = matchService;
            _playerService = playerService;
        }

        public async Task AddSync(Guid id, Guid player1Id, Guid player2Id, Guid winnerId)
        {
            await _matchService.AddSync(id, player1Id, player2Id, winnerId);
        }

        public IEnumerable<Match> GetAll()
        {
            return _matchService.GetAll();
        }

        public async Task<Match> GetByIdSync(Guid id)
        {
            return await _matchService.GetByIdSync(id);
        }                
    }
}
