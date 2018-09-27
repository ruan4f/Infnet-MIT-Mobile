﻿using DomainModel.Entities;
using DomainModel.Interfaces.Services;
using NuncaCai.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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
        
        public async Task AddPointSync(Guid id)
        {
            await _playerService.AddPointSync(id);
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

        public async Task<bool> ExecuteBackup() //Backup to RemoteRepository
        {
            HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:55127/api/");
            client.BaseAddress = new Uri("https://amazingnoteswebapi.azurewebsites.net/api/");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var request = await client.DeleteAsync("players");
            if (!request.IsSuccessStatusCode)
                return false;
            //foreach (var item in Items)
            //{
            //    string serializedItem = Newtonsoft.Json.JsonConvert.SerializeObject(item);
            //    request = await client.PostAsync("items", new StringContent(serializedItem, Encoding.UTF8, "application/json"));
            //    if (!request.IsSuccessStatusCode)
            //        return false;
            //}
            return true;
        }
    }
}
