using NuncaCaiMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace NuncaCaiMobile.ViewModels
{
    public class RankingViewModel : BaseViewModel
    {
        public RankingViewModel(INavigation navigation) : base(navigation)
        {
            var list = new List<Player>(App.PlayerService.GetAll());
            
            Players = new ObservableCollection<Player>(list.OrderByDescending(x => x.Point));
        }

        private ObservableCollection<Player> _players;

        public ObservableCollection<Player> Players
        {
            get { return _players; }
            set => SetProperty(ref _players, value);
        }

    }
}
