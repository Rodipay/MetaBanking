using MetaBanking.ViewModel;
using MetaBanking.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MetaBanking.ViewModel
{
    public class PreLoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }

        public PreLoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        private async void OnRegisterClicked(object obj)
        {
            await Shell.Current.Navigation.PushAsync(new RegisterPage());
        }
    }
}
