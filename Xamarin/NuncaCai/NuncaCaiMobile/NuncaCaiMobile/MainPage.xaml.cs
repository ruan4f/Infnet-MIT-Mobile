﻿using NuncaCaiMobile.Views;
using System;
using Xamarin.Essentials;
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
            Navigation.PushAsync(new PlayersPage());
        }

        private void Btn_Sort_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SortPage());
        }

        private void Btn_MatchHistory_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MatchHistoryPage());
        }

        private void Btn_Ranking_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RankingPage());
        }

        private async void Backup_Activated(object sender, EventArgs e)
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                bool result = await App.BackupService.ExecuteBackup();
                if (!result)
                {
                    await DisplayAlert("Backup", "Error ao tentar realizar o backup. Verifica sua conexão com internet e tente novamente!", "Ok");
                    return;
                }
                await DisplayAlert("Backup", "Backup Feito!", "Ok");
            }
            else
            {
                await DisplayAlert("Backup", "Error ao tentar realizar o backup. Verifica sua conexão com internet e tente novamente!", "Ok");
            }
        }

        private async void RestoreBackup_Activated(object sender, EventArgs e)
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                bool result = await App.BackupService.RestoreBackup();
                if (!result)
                {
                    await DisplayAlert("Backup", "Error ao tentar restaurar o backup. Verifica sua conexão com internet e tente novamente!", "Ok");
                    return;
                }
                await DisplayAlert("Backup", "Backup Restaurado!", "Ok");
            }
            else
            {
                await DisplayAlert("Backup", "Error ao tentar restaurar o backup. Verifica sua conexão com internet e tente novamente!", "Ok");
            }            
        }
    }
}
