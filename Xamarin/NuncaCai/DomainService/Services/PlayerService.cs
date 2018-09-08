using DomainModel.Entities;
using DomainModel.Interfaces.Repositories;
using DomainModel.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace DomainService.Services
{
    public class PlayerService : IPlayerService
    {
        private IPlayerRepository _repository;

        public PlayerService(IPlayerRepository repository)
        {
            _repository = repository;
        }


        public void Add(Player player)
        {
            _repository.Add(player);
        }

        public IEnumerable<Player> GetAll()
        {
            return _repository.GetAll();
        }

        public Player GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public void Update(Player player)
        {
            _repository.Update(player);
        }
    }
}
