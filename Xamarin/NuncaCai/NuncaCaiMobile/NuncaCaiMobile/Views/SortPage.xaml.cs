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
	public partial class SortPage : ContentPage
	{
		public SortPage ()
		{
			InitializeComponent ();
            BindingContext = new SortViewModel(Navigation);
		}
	}
}