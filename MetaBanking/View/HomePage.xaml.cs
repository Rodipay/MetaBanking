using MetaBanking.Sources.Model;
using MetaBanking.Sources.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace MetaBanking.View
{
    [QueryProperty(nameof(Login), "login")]
    public partial class HomePage : ContentPage
    {

        public Account Account { get; set; }
        public Card Card { get; set; }

        public string Login
        {
            set
            {
                Account = App.AccountsDatabase.GetAccount(value);
                InitializeComponent();
                Load();
            }
        }

        private void Load()
        {
            LoadCurrentCard();
            //LabelDate.Text = LabelDate.Text.Replace("${date}", Dates.GetCurrentDate("dd.MM.yyyy"));

            string currencyDate = Dates.GetCurrentDate("MM/dd/yyyy");

            LabelUSD.Text = LabelUSD.Text.Replace("${BYN}", Currencies.GetCurrency("USD", currencyDate));
            LabelEUR.Text = LabelEUR.Text.Replace("${BYN}", Currencies.GetCurrency("EUR", currencyDate));
            LabelRUB.Text = LabelRUB.Text.Replace("${BYN}", Currencies.GetCurrency("RUB", currencyDate));
        }

        private void LoadCurrentCard()
        {
            Card = App.CardsDatabase.GetAccountCards(Account.Login).ToList()[0];
            LabelCurrectCardBalance.Text = $"{Card.Balance} BYN";
            LabelCurrectCard.Text = Regex.Replace(Card.Number, @"(.{4})", "$1 ");
            LabelCurrectCardDate.Text = Card.ExpiryDate;
            LabelCurrectCardCode.Text = Card.Code.ToString();
        }

        private async void OnFillUpCardClicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new FillUpCardPage(Account, Card));
        }

        private void OnHistoryCardClicked(object sender, EventArgs e)
        {
            // TODO: history page for card
        }
    }
}