using MetaBanking.Sources.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MetaBanking.View
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnEnterClicked(object sender, EventArgs e)
        {
            if (LoginEntry.Text == null || PasswordEntry.Text == null) return;
            if (!App.AccountsDatabase.Contains(LoginEntry.Text))
            {
                await DisplayAlert("Ошибка", "Пользователя с таким логином не было найдено", "Хорошо");
                return;
            }
            Account account = App.AccountsDatabase.GetAccount(LoginEntry.Text);
            if (!account.Password.Equals(PasswordEntry.Text))
            {
                await DisplayAlert("Ошибка", "Неверный пароль", "Хорошо");
                return;
            }
            if (App.CardsDatabase.GetAccountCards(account.Login).Count == 0)
            {
                await Shell.Current.Navigation.PushAsync(new AddCardPage(account.Login));
                return;
            }
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}?login={LoginEntry.Text}");
        }
    }
}