using DomainModel.Interfaces.Services;
using DomainService.Services;
using Infra.Data.SQLite.Context;
using Infra.Data.SQLite.Repository;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NuncaCaiMobile
{
    public partial class App : Application
    {
        public static IPlayerService PlayerService { get; set; }
        public static IMatchService MatchService { get; set; }

        public App()
        {
            InitializeComponent();

            var runtimePlatform = Device.RuntimePlatform;

            PlayerService = new PlayerService(new PlayerRepository(new EntitySQLiteContext(runtimePlatform)));
            MatchService = new MatchService(new MatchRepository(new EntitySQLiteContext(runtimePlatform)));

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
