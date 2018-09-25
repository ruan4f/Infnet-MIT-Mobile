using DomainModel.Entities;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace NuncaCaiMobile.ViewModels
{
    public class MatchHistoryViewModel : BaseViewModel
    {
        public MatchHistoryViewModel(INavigation navigation) : base(navigation)
        {
            Matches = new ObservableCollection<Match>(App.MatchService.GetAll());
        }

        private ObservableCollection<Match> _matches;

        public ObservableCollection<Match> Matches
        {
            get { return _matches; }
            set => SetProperty(ref _matches, value);
        }

    }
}
