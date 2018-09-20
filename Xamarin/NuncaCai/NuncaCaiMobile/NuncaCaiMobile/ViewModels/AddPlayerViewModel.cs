using NuncaCaiMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace NuncaCaiMobile.ViewModels
{
    public class AddPlayerViewModel : BaseViewModel
    {
        public AddPlayerViewModel(INavigation navigation):base(navigation)
        {
            AddCommand = new Command(AddPlayer);
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set => SetProperty(ref _name, value);
        }


        public ICommand AddCommand { get; set; }

        private void AddPlayer()
        {
            App.PlayerService.Add(new Player(Name));
            Navigation.PopAsync();
        }
    }
}
