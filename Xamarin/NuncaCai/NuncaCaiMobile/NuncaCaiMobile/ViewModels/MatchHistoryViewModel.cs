using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NuncaCaiMobile.ViewModels
{
    public class MatchHistoryViewModel : BaseViewModel
    {

        private ObservableCollection<Match> _matches;

        public ObservableCollection<Match> Matches
        {
            get { return _matches; }
            set => SetProperty(ref _matches, value);
        }




    }
}
