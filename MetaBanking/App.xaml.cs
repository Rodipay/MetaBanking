using MetaBanking.Sources.Repository;
using MetaBanking.View;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MetaBanking
{
    public partial class App : Application
    {

        public const string ACCOUNTS_DATABASE_NAME = "accounts.db";
        public const string CARDS_DATABASE_NAME = "cards.db";


        private static AccountsRepository _accountsDatabase;
        public static AccountsRepository AccountsDatabase
        {
            get
            {
                if (_accountsDatabase == null)
                {
                    _accountsDatabase = new AccountsRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ACCOUNTS_DATABASE_NAME));
                }
                return _accountsDatabase;
            }
        }

        private static CardsRepository _cardsDatabase;
        public static CardsRepository CardsDatabase
        {
            get
            {
                if (_cardsDatabase == null)
                {
                    _cardsDatabase = new CardsRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), CARDS_DATABASE_NAME));
                }
                return _cardsDatabase;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart() { }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}
