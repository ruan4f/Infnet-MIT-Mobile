using DomainModel.Entities;
using DomainModel.Interfaces.Services;
using Newtonsoft.Json;
using NuncaCai.Application.Interfaces;
using NuncaCai.Application.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NuncaCai.Application.Services
{
    public class BackupAppService : IBackupAppService
    {
        private readonly IMatchService _matchService;
        private readonly IPlayerService _playerService;

        public BackupAppService(IMatchService matchService, IPlayerService playerService)
        {
            _matchService = matchService;
            _playerService = playerService;
        }

        public async Task<bool> ExecuteBackup() //Backup to RemoteRepository
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:21094/api/");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var requestMatches = await client.DeleteAsync("matches");
            if (!requestMatches.IsSuccessStatusCode)
                return false;
            var requestPlayers = await client.DeleteAsync("players");
            if (!requestPlayers.IsSuccessStatusCode)
                return false;

            var players = _playerService.GetAll();

            foreach (var item in players)
            {
                string serializedItem = JsonConvert.SerializeObject(item);
                requestPlayers = await client.PostAsync("players", new StringContent(serializedItem, Encoding.UTF8, "application/json"));
                if (!requestPlayers.IsSuccessStatusCode)
                    return false;
            }

            var matches = _matchService.GetAll();

            foreach (var item in matches)
            {
                var model = new MatchModel
                {
                    Id = item.MatchId,
                    Player1Id = item.MatchPlayed.Player1Id,
                    Player2Id = item.MatchPlayed.Player2Id,
                    WinnerId = item.MatchPlayed.WinnerId,
                    MatchDate = item.MatchDate
                };

                string serializedItem = JsonConvert.SerializeObject(model);
                requestMatches = await client.PostAsync("matches", new StringContent(serializedItem, Encoding.UTF8, "application/json"));
                if (!requestMatches.IsSuccessStatusCode)
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

            var requestPlayers = await client.GetAsync("players");

            if (!requestPlayers.IsSuccessStatusCode)
                return false; //Could not restore the backup

            string serializedPlayers = await requestPlayers.Content.ReadAsStringAsync();
            IEnumerable<Player> restoredPlayers = JsonConvert
                .DeserializeObject<IEnumerable<Player>>(serializedPlayers);


            var requestMatches = await client.GetAsync("matches");

            if (!requestMatches.IsSuccessStatusCode)
                return false; //Could not restore the backup

            string serializedMatches = await requestMatches.Content.ReadAsStringAsync();
            IEnumerable<MatchModel> restoredMatches = JsonConvert
                .DeserializeObject<IEnumerable<MatchModel>>(serializedMatches);
                        
            _matchService.RemoveAll();
            _playerService.RemoveAll();

            foreach (var item in restoredPlayers)
            {
                await _playerService.AddSync(item);
            }
                        
            foreach (var item in restoredMatches)
            {
                await _matchService.AddSync(item.Id, item.Player1Id, item.Player2Id, item.WinnerId, item.MatchDate);
            }

            return true;
        }
    }
}
