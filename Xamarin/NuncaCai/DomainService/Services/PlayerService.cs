using DomainModel.Entities;
using DomainModel.Interfaces.Repositories;
using DomainModel.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainService.Services
{
    public class PlayerService : IPlayerService
    {
        private IPlayerRepository _repository;

        public PlayerService(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task AddPointSync(Guid id)
        {
            var player = await _repository.GetByIdSync(id);

            player.Point += 1;

            await _repository.UpdateSync(player);            
        }

        public async Task AddSync(Player player)
        {
            await _repository.AddSync(player);
        }

        public IEnumerable<Player> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<Player> GetByIdSync(Guid id)
        {
            return await _repository.GetByIdSync(id);
        }

        public void RemoveAll()
        {
            _repository.RemoveAll();
        }

        public async Task UpdateSync(Player player)
        {
            await _repository.UpdateSync(player);
        }
    }
}
