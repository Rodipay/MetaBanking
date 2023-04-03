using MetaBanking.Sources.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.Internals;

namespace MetaBanking.Sources.Repository
{
    public class CardsRepository
    {

        public SQLiteConnection Database;

        public CardsRepository(string databasePath)
        {
            Database = new SQLiteConnection(databasePath);
            Database.CreateTable<Card>();
        }

        public ICollection<Card> GetCards()
        {
            return Database.Table<Card>().ToList();
        }

        public ICollection<Card> GetAccountCards(string login)
        {
            List<Card> cards = new List<Card>();
            foreach (Card card in GetCards())
            {
                if (card.Owner.Equals(login))
                {
                    cards.Add(card);
                }
            }
            return cards;
        }

        public bool Contains(string number)
        {
            return GetCards().Where(c => c.Number.Equals(number)).Any();
        }

        public Card GetCard(string number)
        {
            return GetCards().Where(c => c.Number.Equals(number)).FirstOrDefault();
        }

        public int Delete(int id)
        {
            return Database.Delete<Card>(id);
        }

        public void Save(Card card)
        {
            if (Contains(card.Number))
            {
                Database.Update(card);
            }
            else
            {
                Database.Insert(card);
            }
        }

        public void Clear()
        {
            foreach (Card card in GetCards())
            {
                Delete(card.Id);
            }
        }
    }
}
