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

        public MatchAppService(IMatchService matchService)
        {
            _matchService = matchService;
        }

        public async Task AddSync(Match match)
        {
            await _matchService.AddSync(match);
        }

        public IEnumerable<Match> GetAll()
        {
            return _matchService.GetAll();
        }

        public async Task<Match> GetByIdSync(Guid id)
        {
            return await _matchService.GetByIdSync(id);
        }

        public async Task UpdateSync(Match match)
        {
            await _matchService.UpdateSync(match);
        }
    }
}
