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


    }
}
