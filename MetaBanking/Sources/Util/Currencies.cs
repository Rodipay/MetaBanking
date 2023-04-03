using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace MetaBanking.Sources.Util
{
    public class Currencies
    {
        public static string GetCurrency(string currency, string date)
        {
            WebClient client = new WebClient();
            string str = client.DownloadString("https://www.nbrb.by/services/xmlexrates.aspx?ondate=" + date);
            XDocument doc = XDocument.Parse(str);
            IEnumerable<XElement> elements = doc.Element("DailyExRates").Elements("Currency");
            return elements.Where(x => x.Element("CharCode").Value == currency).Select(x => x.Element("Rate").Value).FirstOrDefault();
        }
        //public static string GetCurrency(string currency)
        //{
        //    WebClient client = new WebClient();
        //    string str = client.DownloadString("https://select.by/kurs/");
        //    Match match = Regex.Match(str, "<div class=\"name\">(" + currency + ")</div>.*?<div class=\"sum\">(.*?)</div>");
        //    if (match.Success)
        //    {
        //        return decimal.Parse(match.Groups[2].Value.Replace(',', '.'), CultureInfo.InvariantCulture).ToString();
        //    }
        //    else
        //    {
        //        throw new Exception("Unable to find currency " + currency);
        //    }
        //}
    }
}
