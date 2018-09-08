using DomainModel.Entities;
using DomainModel.Interfaces.Services;
using NuncaCai.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NuncaCai.Application.Services
{
    public class PlayerAppService : IPlayerAppService
    {
        private readonly IPlayerService _playerService;


        public PlayerAppService(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public async Task AddSync(Player player)
        {
            await _playerService.AddSync(player);
        }

        public IEnumerable<Player> GetAll()
        {
            return _playerService.GetAll();
        }

        public async Task<Player> GetByIdSync(Guid id)
        {
            return await _playerService.GetByIdSync(id);
        }

        public async Task UpdateSync(Player player)
        {
            await _playerService.UpdateSync(player);
        }
    }
}
