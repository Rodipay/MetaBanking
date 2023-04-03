using MetaBanking.Sources.Util;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaBanking.Sources.Model
{
    [Table("cards")]
    public class Card
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Owner { get; set; }
        [MaxLength(16)]
        public string Number { get; set; }
        public double Balance { get; set; } = 0.0;
        public string ExpiryDate { get; set; } = DateTime.Now.AddYears(5).ToString("dd.MM.yyyy");
        public int Code { get; set; } = new Random().Next(100, 999);
    }
}
