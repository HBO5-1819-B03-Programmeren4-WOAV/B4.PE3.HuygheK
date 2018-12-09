using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace B4.PE3.HuygheK.ViewModels
{
    public class MainViewModel : FreshBasePageModel
    {
        public ICommand LocationInfoPageCommand { get; private set; }

        public MainViewModel()
        {
            
            LocationInfoPageCommand = new Command(OpenLocationInfoPage);
           
        }
        private async void OpenLocationInfoPage()
        {
            await CoreMethods.PushPageModel<LocationInfoViewModel>(true);
        }
    }
}
