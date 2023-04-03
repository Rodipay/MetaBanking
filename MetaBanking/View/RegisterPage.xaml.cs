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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void OnEnterClicked(object sender, EventArgs e)
        {
            if (LoginEntry.Text == null || PasswordEntry.Text == null) return;
            if (App.AccountsDatabase.Contains(LoginEntry.Text))
            {
                await DisplayAlert("Ошибка", "Пользователь с таким логином уже существует", "Хорошо");
                return;
            }
            Account account = new Account();
            account.Login = LoginEntry.Text;
            account.Password = PasswordEntry.Text;
            App.AccountsDatabase.Save(account);
            await DisplayAlert(Title, "Аккаунт был успешно зарегистрирован\nВернитесь в главное меню для авторизации", "Хорошо");
        }
    }
}