using System;
using System.Windows.Input;
using MetaBanking.ViewModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MetaBanking.ViewModel
{
    public class MoreViewModel : BaseViewModel
    {
        public MoreViewModel()
        {
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}
