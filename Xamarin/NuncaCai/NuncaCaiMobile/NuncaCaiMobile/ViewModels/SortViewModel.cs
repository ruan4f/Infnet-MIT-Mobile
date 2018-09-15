using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace NuncaCaiMobile.ViewModels
{
    public class SortViewModel : BaseViewModel
    {

        public SortViewModel(INavigation navigation) : base(navigation)
        {
            Matches = new ObservableCollection<Match>(GenerateMatches(App.PlayerService.GetAll()));
        }

        private ObservableCollection<Match> _matches;

        public ObservableCollection<Match> Matches
        {
            get { return _matches; }
            set => SetProperty(ref _matches, value);
        }

        public ICommand Winner1Command { get; set; }
        public ICommand Winner2Command { get; set; }

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

                newMatches.Add(new Match(first, second));
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

    }
}
