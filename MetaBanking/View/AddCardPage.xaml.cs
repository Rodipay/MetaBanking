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
	public partial class AddCardPage : ContentPage
	{

		private string Owner { get; set; }
		public string Login
		{
			set
			{
				Owner = value;
				InitializeComponent();
			}
		}

		public AddCardPage(String login)
		{
			Login = login;
		}

		private async void OnEnterClicked(object sender, EventArgs e)
		{
			if (CardNumberEntry.Text == null) return;
			if (CardNumberEntry.Text.Length > 16)
			{
				await DisplayAlert("Ошибка", "Номер карты должен содержать в себе 16 символов", "Хорошо");
				return;
			}
			if (App.CardsDatabase.Contains(CardNumberEntry.Text))
			{
				await DisplayAlert("Ошибка", $"Карта {CardNumberEntry.Text} уже существует в базе данных. Придумайте новое уникальное имя", "Хорошо");
				return;
			}
			Card card = new Card();
			card.Owner = Owner;
			card.Number = CardNumberEntry.Text;
			App.CardsDatabase.Save(card);
			await DisplayAlert(Title, $"Карта с номером {card.Number} была успешно добавлена владельцу {card.Owner}\nВернитесь на предыдущую страницу и авторизуйтесь снова", "Хорошо");
		}
	}
}