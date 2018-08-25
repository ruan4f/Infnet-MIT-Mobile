using SimpleNote.Data;
using SimpleNote.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace SimpleNote
{
	public partial class App : Application
	{
        static NoteItemDatabase database;

        public App ()
		{
			InitializeComponent();

            Resources = new ResourceDictionary();
            Resources.Add("primaryBlue", Color.FromHex("6200EE"));
            Resources.Add("primaryDarkBlue", Color.FromHex("3700B3"));

            var nav = new NavigationPage(new NoteListPage());
            nav.BarBackgroundColor = (Color)App.Current.Resources["primaryBlue"];
            nav.BarTextColor = Color.White;            

            MainPage = nav;
        }

        public static NoteItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new NoteItemDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "NoteDB.db3"));
                }
                return database;
            }
        }

        public int ResumeAtNoteId { get; set; }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
