using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace D03WeatherAppUI
{
    internal class WeatherManager
    {
        public int GetTemperature(string city)
        {
            WebClient webClient = new WebClient();

            string address = $"https://www.google.com/search?q=weather+";
         
            string text = webClient.DownloadString(address + city);

            string pattern = "<div class=\"BNeawe iBp4i AP7Wnd\">(-{0,1}\\d{1,2}.{0,1}\\d{0,2}).C<\\/div>";

            Regex rx = new Regex(pattern);
            Match match = rx.Match(text);

            string result = match.Groups[1].Value;
          
            // return int.Parse(result);
            //int a = 4;
            //a.ToString();

            return Convert.ToInt32(result);
        }
    }
}
