using NuncaCaiMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NuncaCaiMobile.ViewModels
{
    public class AddPlayerViewModel : BaseViewModel
    {
        public AddPlayerViewModel(INavigation navigation) : base(navigation)
        {
            AddCommand = new Command(async () => await AddPlayer());
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set => SetProperty(ref _name, value);
        }


        public ICommand AddCommand { get; set; }

        private async Task AddPlayer()
        {
            await App.PlayerService.AddSync(new Player(Name));
            await Navigation.PopAsync();
        }
    }
}
