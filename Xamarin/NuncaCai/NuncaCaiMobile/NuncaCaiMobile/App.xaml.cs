using DomainService.Services;
using Infra.Data.SQLite.Context;
using Infra.Data.SQLite.Repository;
using NuncaCai.Application.Interfaces;
using NuncaCai.Application.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NuncaCaiMobile
{
    public partial class App : Application
    {
        public static IPlayerAppService PlayerService { get; set; }
        public static IMatchAppService MatchService { get; set; }
        public static IBackupAppService BackupService { get; set; }

        public App()
        {
            InitializeComponent();

            var runtimePlatform = Device.RuntimePlatform;
            var playerService = new PlayerService(new PlayerRepository(new EntitySQLiteContext(runtimePlatform)));
            var matchService = new MatchService(new MatchRepository(new EntitySQLiteContext(runtimePlatform)));

            PlayerService = new PlayerAppService(playerService);
            MatchService = new MatchAppService(matchService);
            BackupService = new BackupAppService(matchService, playerService);

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
