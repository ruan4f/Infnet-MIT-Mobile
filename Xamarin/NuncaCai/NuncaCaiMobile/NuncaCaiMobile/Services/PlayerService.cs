using DomainModel.Entities;
using NuncaCaiMobile.Interfaces;
using NuncaCaiMobile.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NuncaCaiMobile.Services
{
    public class PlayerService : IPlayerService
    {
        private IPlayerRepository _playerRepository;

        public PlayerService()
        {
            _playerRepository = new PlayerRepository();
        }

        public void Add(Player player)
        {
            _playerRepository.Add(player);
        }

        public IEnumerable<Player> GetAll()
        {
            return _playerRepository.GetAll();
        }
    }
}
