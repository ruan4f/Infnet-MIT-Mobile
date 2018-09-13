using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NuncaCaiMobile.ViewModels
{
    public class PlayersViewModel:BaseViewModel
    {

        private ObservableCollection<Player> _players;

        public ObservableCollection<Player> Players
        {
            get { return _players; }
            set => SetProperty(ref _players, value);
        }


    }
}
