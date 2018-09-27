using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Entities;
using DomainModel.Interfaces.Services;
using Newtonsoft.Json;
using NuncaCai.Application.Interfaces;
using NuncaCai.Application.Models;

namespace NuncaCai.Application.Services
{
    public class MatchAppService : IMatchAppService
    {
        private readonly IMatchService _matchService;

        public MatchAppService(IMatchService matchService)
        {
            _matchService = matchService;
        }

        public async Task AddSync(Guid id, Guid player1Id, Guid player2Id, Guid winnerId, DateTime date)
        {
            await _matchService.AddSync(id, player1Id, player2Id, winnerId, date);
        }

        public async Task AddSync(Match match)
        {
            await _matchService.AddSync(match);
        }

        public IEnumerable<Match> GetAll()
        {
            return _matchService.GetAll();
        }

        public IEnumerable<Match> GetSimpleAll()
        {
            return _matchService.GetSimpleAll();
        }

        public async Task<Match> GetByIdSync(Guid id)
        {
            return await _matchService.GetByIdSync(id);
        }

        public async Task UpdateSync(Match match)
        {
            await _matchService.UpdateSync(match);
        }

        public void RemoveAll()
        {
            _matchService.RemoveAll();
        }
    }
}
