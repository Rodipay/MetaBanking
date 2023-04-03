using System;
using System.Collections.Generic;
using System.Text;

namespace MetaBanking.Sources.Util
{
    public class Dates
    { 
        public static string GetCurrentDate(string format)
        {
            return DateTime.Now.ToString(format);
        }
    }
}
