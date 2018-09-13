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
	public partial class AddPlayerPage : ContentPage
	{
		public AddPlayerPage ()
		{
			InitializeComponent ();
            BindingContext = new AddPlayerViewModel(Navigation);
		}
	}
}