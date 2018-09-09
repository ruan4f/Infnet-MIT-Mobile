using System;
using System.Collections.Generic;
using System.Text;

namespace NuncaCaiMobile.ViewModels
{
    public class PlayersViewModel : BaseViewModel
    {




        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                SetProperty(ref _name, value);
            }
        }



    }
}
