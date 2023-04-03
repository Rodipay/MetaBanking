using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaBanking.Sources.Model
{
    [Table("accounts")]
    public class Account
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
