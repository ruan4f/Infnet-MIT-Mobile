using DomainModel.Entities;
using DomainModel.Interfaces.Services;
using Newtonsoft.Json;
using NuncaCai.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        public void RemoveAll()
        {
            _playerService.RemoveAll();
        }

        public async Task<bool> ExecuteBackup() //Backup to RemoteRepository
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:21094/api/");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var request = await client.DeleteAsync("players");
            if (!request.IsSuccessStatusCode)
                return false;

            var players = _playerService.GetAll();

            foreach (var item in players)
            {
                string serializedItem = JsonConvert.SerializeObject(item);
                request = await client.PostAsync("players", new StringContent(serializedItem, Encoding.UTF8, "application/json"));
                if (!request.IsSuccessStatusCode)
                    return false;
            }

            return true;
        }

        public async Task<bool> RestoreBackup() //Restore from RemoteRepository
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:21094/api/");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var requestResult = await client.GetAsync("players");

            if (!requestResult.IsSuccessStatusCode)
                return false; //Could not restore the backup

            string serializedItems = await requestResult.Content.ReadAsStringAsync();
            IEnumerable<Player> restoredItems = JsonConvert
                .DeserializeObject<IEnumerable<Player>>(serializedItems);

            RemoveAll();
            foreach (var item in restoredItems)
            {
                await AddSync(item);
            }

            return true;
        }
    }
}
