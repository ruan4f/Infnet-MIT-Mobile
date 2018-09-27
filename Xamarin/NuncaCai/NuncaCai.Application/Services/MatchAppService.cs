using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DomainModel.Entities;
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

        public async Task AddSync(Guid id, Guid player1Id, Guid player2Id, Guid winnerId)
        {
            await _matchService.AddSync(id, player1Id, player2Id, winnerId);
        }

        public async Task AddSync(Match match)
        {
            await _matchService.AddSync(match);
        }

        public IEnumerable<Match> GetAll()
        {
            return _matchService.GetAll();
        }

        public async Task<Match> GetByIdSync(Guid id)
        {
            return await _matchService.GetByIdSync(id);
        }

        public async Task UpdateSync(Match match)
        {
            await _matchService.UpdateSync(match);
        }

        public void RemoveAll()
        {
            _matchService.RemoveAll();
        }


        public async Task<bool> ExecuteBackup() //Backup to RemoteRepository
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55127/api/");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var request = await client.DeleteAsync("matches");
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

        public async Task<bool> RestoreBackup() //Restore from RemoteRepository
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55127/api/");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var requestResult = await client.GetAsync("matches");

            if (!requestResult.IsSuccessStatusCode)
                return false; //Could not restore the backup

            //string serializedItems = await requestResult.Content.ReadAsStringAsync();
            //IEnumerable<Item> restoredItems = JsonConvert
            //    .DeserializeObject<IEnumerable<Item>>(serializedItems)
            //    .OrderBy(i => i.PublishDateTime);

            //RemoveAllItems();
            //foreach (var item in restoredItems)
            //{
            //    AddItem(item);
            //}

            return true;
        }
    }
}
