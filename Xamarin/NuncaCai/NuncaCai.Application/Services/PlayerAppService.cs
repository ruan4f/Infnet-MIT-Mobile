using DomainModel.Interfaces.Services;
using NuncaCai.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NuncaCai.Application.Services
{
    public class PlayerAppService : IPlayerAppService
    {
        private readonly IPlayerService _playerService;


        public PlayerAppService(IPlayerService playerService)
        {
            _playerService = playerService;
        }



    }
}
