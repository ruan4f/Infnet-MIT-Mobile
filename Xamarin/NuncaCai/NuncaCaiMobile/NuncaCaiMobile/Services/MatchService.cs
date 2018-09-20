using NuncaCaiMobile.Models;
using NuncaCaiMobile.Interfaces;
using NuncaCaiMobile.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NuncaCaiMobile.Services
{
    public class MatchService: IMatchService
    {
        private IMatchRepository _matchRepository;

        public MatchService()
        {
            _matchRepository = new MatchRepository();
        }

        public void Add(Match match)
        {
            _matchRepository.Add(match);
        }

        public void Update(Match match)
        {
            _matchRepository.Update(match);
        }

        public IEnumerable<Match> GetAll()
        {
            return _matchRepository.GetAll();
        }
    }
}
