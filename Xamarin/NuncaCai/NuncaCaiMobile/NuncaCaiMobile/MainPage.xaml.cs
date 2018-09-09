using NuncaCaiMobile.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NuncaCaiMobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Btn_Players_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PlayersView());
        }

        private void Btn_Sort_Clicked(object sender, EventArgs e)
        {

        }

        private void Btn_MatchHistory_Clicked(object sender, EventArgs e)
        {

        }

        private void Btn_Ranking_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RankingView());
        }
    }
}
