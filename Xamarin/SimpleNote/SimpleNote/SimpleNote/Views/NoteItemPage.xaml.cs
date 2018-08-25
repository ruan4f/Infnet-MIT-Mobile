using SimpleNote.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleNote.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NoteItemPage : ContentPage
	{
		public NoteItemPage ()
		{
			InitializeComponent ();
		}

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var todoItem = (NoteItem)BindingContext;
            await App.Database.SaveItemAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var todoItem = (NoteItem)BindingContext;
            await App.Database.DeleteItemAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
       
    }
}