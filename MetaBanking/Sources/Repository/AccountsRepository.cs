using MetaBanking.Sources.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaBanking.Sources.Repository
{
    public class AccountsRepository
    {

        public SQLiteConnection Database;

        public AccountsRepository(string databasePath)
        {
            Database = new SQLiteConnection(databasePath);
            Database.CreateTable<Account>();
        }

        public ICollection<Account> GetAccounts()
        {
            return Database.Table<Account>().ToList();
        }

        public bool Contains(string login)
        {
            return GetAccounts().Where(a => a.Login.Equals(login)).Any();
        }

        public Account GetAccount(string login)
        {
            return GetAccounts().Where(a => a.Login.Equals(login)).FirstOrDefault();
        }

        public int Delete(int id)
        {
            return Database.Delete<Account>(id);
        }

        public void Save(Account account)
        {
            if (Contains(account.Login))
            {
                Database.Update(account);
            }
            else
            {
                Database.Insert(account);
            }
        }

        public void Clear()
        {
            foreach (Account account in GetAccounts())
            {
                Delete(account.Id);
            }
        }
    }
}
