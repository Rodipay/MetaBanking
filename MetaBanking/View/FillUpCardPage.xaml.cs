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
    public partial class FillUpCardPage : ContentPage
    {

        public Account Account { get; set; }
        public Card Card { get; set; }

        public FillUpCardPage(Account account, Card card)
        {
            this.Account = account;
            this.Card = card;
            InitializeComponent();
        }

        private async void OnFillUpClicked(object sender, EventArgs e)
        {
            if (AmountEntry.Text == null)
            {
                await DisplayAlert("Ошибка", "Укажите сумму, на которую хотите пополнить свою либо чужую карту", "Хорошо");
                return;
            }
            bool isNumber = double.TryParse(AmountEntry.Text, out double amount);
            if (!isNumber)
            {
                await DisplayAlert("Ошибка", "Сумма, которую Вы хотите перечислить, должна быть числом с плавающей точкой", "Хорошо");
                return;
            }

            string number = "<отсутствует>";
            if (CardNumberEntry.Text == null)
            {
                number = Card.Number;
                Card.Balance += amount;
                App.CardsDatabase.Save(Card);
            }
            else
            {
                number = CardNumberEntry.Text;
                if (number.Length > 16)
                {
                    await DisplayAlert("Ошибка", "Номер карты должен содержать в себе 16 символов", "Хорошо");
                    return;
                }
                Card card = App.CardsDatabase.GetCard(number);
                if (card == null)
                {
                    await DisplayAlert("Ошибка", $"Карты {number} не было найдено в базе данных", "Хорошо");
                    return;
                }
                card.Balance += amount;
                App.CardsDatabase.Save(card);
            }
            await DisplayAlert(Title, $"Баланс карты {number} был пополнен на {amount} BYN", "Хорошо");
        }
    }
}