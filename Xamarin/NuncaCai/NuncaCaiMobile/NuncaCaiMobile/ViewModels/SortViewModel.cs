﻿using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NuncaCaiMobile.ViewModels
{
    public class SortViewModel : BaseViewModel
    {
        public SortViewModel(INavigation navigation) : base(navigation)
        {
            var players = App.PlayerService.GetAll();

            if (VerifyQuantityPlayers(players))
            {
                Matches = new ObservableCollection<Match>(GenerateMatches(players));

                Winner1Command = new Command<Match>(async q => await Winner1(q));
                Winner2Command = new Command<Match>(async q => await Winner2(q));
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error ao sortear duplas", "Para poder sortear as duplas a quantidade de usuários cadastrados deve ser par.", "OK");
            }            
        }

        private ObservableCollection<Match> _matches;

        public ObservableCollection<Match> Matches
        {
            get { return _matches; }
            set => SetProperty(ref _matches, value);
        }

        public ICommand Winner1Command { get; set; }
        public ICommand Winner2Command { get; set; }

        private async Task Winner1(Match match)
        {
            var index = Matches.IndexOf(match);
            var matchPlayed = match.MatchPlayed;

            matchPlayed.Player1.Point += 1;

            var player = matchPlayed.Player1;

            await App.PlayerService.UpdateSync(player);

            matchPlayed.WinnerId = matchPlayed.Player1Id;
            matchPlayed.Winner = matchPlayed.Player1;
            
            await App.MatchService.AddSync(match);

            Matches.RemoveAt(index);

            await Application.Current.MainPage.DisplayAlert("Vencedor", $"{player.Name} foi o(a) vencedor(a) dessa partida", "OK");
        }

        private async Task Winner2(Match match)
        {
            var index = Matches.IndexOf(match);
            var matchPlayed = match.MatchPlayed;

            matchPlayed.Player2.Point += 1;

            var player = matchPlayed.Player2;

            await App.PlayerService.UpdateSync(player);

            matchPlayed.WinnerId = matchPlayed.Player2Id;
            matchPlayed.Winner = matchPlayed.Player2;
            
            await App.MatchService.AddSync(match);

            Matches.RemoveAt(index);

            await Application.Current.MainPage.DisplayAlert("Vencedor", $"{player.Name} foi o(a) vencedor(a) dessa partida", "OK");
        }

        private List<Match> GenerateMatches(IEnumerable<Player> players)
        {
            var newMatches = new List<Match>();
            var listRandomized = Randomize(players);
            var count = 0;

            for (var index = 0; index < listRandomized.Count; index++)
            {
                if (count + 1 > listRandomized.Count) break;

                var first = listRandomized[count];
                count++;
                var second = listRandomized[count];
                count++;

                newMatches.Add(new Match(Guid.NewGuid(), first, second));
            }

            return newMatches;
        }
        
        private List<Player> Randomize(IEnumerable<Player> players)
        {
            var playersRandomized = new List<Player>(players);
            var random = new Random();

            int n = playersRandomized.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                var value = playersRandomized[k];
                playersRandomized[k] = playersRandomized[n];
                playersRandomized[n] = value;
            }

            return playersRandomized;
        }

        private bool VerifyQuantityPlayers(IEnumerable<Player> players)
        {
            return players.Count() % 2 == 0;
        }

    }
}
