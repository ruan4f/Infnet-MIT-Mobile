using SimpleNote.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleNote.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NoteListPage : ContentPage
	{
		public NoteListPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            ((App)App.Current).ResumeAtNoteId = -1;
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NoteItemPage
            {
                BindingContext = new NoteItem()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new NoteItemPage
                {
                    BindingContext = e.SelectedItem as NoteItem
                });
            }
        }
    }
}