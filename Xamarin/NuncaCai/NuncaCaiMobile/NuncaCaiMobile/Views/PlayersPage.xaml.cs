using NuncaCaiMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NuncaCaiMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlayersPage : ContentPage
	{
		public PlayersPage ()
		{
			InitializeComponent ();
            BindingContext = new PlayersViewModel(Navigation);
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var viewModel = new PlayersViewModel(Navigation);

            ListView_Players.ItemsSource = viewModel.Players;

            BindingContext = viewModel;
        }
    }
}