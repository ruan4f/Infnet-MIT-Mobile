using System;
using System.Collections.Generic;
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

        public void Add(Match match)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Match> GetAll()
        {
            throw new NotImplementedException();
        }

        public Match GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Match match)
        {
            throw new NotImplementedException();
        }
    }
}
