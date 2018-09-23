using NuncaCaiMobile.Models;
using NuncaCaiMobile.Interfaces;
using NuncaCaiMobile.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace NuncaCaiMobile.Services
{
    public class PlayerService : BaseService, IPlayerService
    {
        private IPlayerRepository _playerRepository;

        public PlayerService() : base()
        {
            _playerRepository = new PlayerRepository();
        }

        public async Task AddSync(Player player)
        {
            var url = $"{urlApi}/players";
            var uri = new Uri(url);

            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(player), Encoding.UTF8, "application/json");
                var result = await client.PostAsync(url, content);

                if (result.IsSuccessStatusCode)
                {
                    var jsonString = result.Content.ReadAsStringAsync();
                    jsonString.Wait();

                    _playerRepository.Add(player);

                    //resultado = JsonConvert.DeserializeObject<DadosRetornoSincronizacao>(jsonString.Result);
                }
                else
                {
                    //resultado = new DadosRetornoSincronizacao
                    //{
                    //    Mensagem = result.StatusCode.ToString(),
                    //    Sucesso = false
                    //};
                }
            }
            catch (Exception excecao)
            {
                //resultado = new DadosRetornoSincronizacao
                //{
                //    Mensagem = excecao.Message,
                //    Sucesso = false
                //};
            }
        }


        public void Update(Player player)
        {
            _playerRepository.Update(player);
        }

        public IEnumerable<Player> GetAll()
        {
            return _playerRepository.GetAll();
        }
    }
}
