using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace NuncaCaiMobile.ViewModels
{
    public class PlayersViewModel : BaseViewModel
    {

        public PlayersViewModel()
        {
            AddCommand = new Command(AddPlayer);

            Players = new ObservableCollection<Player>(App.PlayerService.GetAll());
        }    

        private ObservableCollection<Player> _players;

        public ObservableCollection<Player> Players
        {
            get { return _players; }
            set => SetProperty(ref _players, value);
        }

        public ICommand AddCommand { get; set; }

        private void AddPlayer()
        {
            
        }

    }
}
