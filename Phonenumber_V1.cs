using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Phonenumber_v1
{
    class Program
    {
        static void Main(string[] args)
        {
            ///The numbers: 0211/6355550, 0049 (0)211 - 635555 0, +49 0211 - 6 3 5 5 5 5 0, 001 202 326 7300

            string num1 = "0211/6355550";
            string num2 = "0049 (0)211 - 635555 0";
            string num3 = "+49 0211 - 6 3 5 5 5 5 0";
            string num4 = "001 202 326 7300";

            // Länder auflisten
            string countr = "Deutschland";
            string countr1 = "USA";
            // Vorwahl nach Land sortieren
            bool pref1 = countr.Contains("Deutschland");
            bool pref2 = countr1.Contains("USA");

            // Sonderzeichen aus dem String filtern
            string checknum1 = ClString(num1);
            string checknum2 = ClString(num2);
            string checknum3 = ClString(num3);
            string checknum4 = ClString(num4);
            // Meldung falls das Land nicht in der Liste oder Tippfehler
            string countrt = "Land nicht verfügbar";
            string countrt1 = "Land nicht verfügbar";

            
            // Vorwahl für jeweiliges Land einsetzen
            if (pref1)
            {
                countrt = "+49";
            }
            if (pref2)
            {
                countrt1 = "+1";
            }

            // String in passendes Format für evtl. weitere verarbeitung
            long parseSt1 = long.Parse(checknum1);
            long parseSt2 = long.Parse(checknum2);
            long parseSt3 = long.Parse(checknum3);
            long parseSt4 = long.Parse(checknum4);

            // wiedergabe der Vorwahl und Nummer
            Console.WriteLine(countrt + parseSt1);
            Console.WriteLine(countrt + parseSt2);
            Console.WriteLine(countrt + parseSt3);
            Console.WriteLine(countrt1 + parseSt4);


            
            Console.ReadKey();

        }
       
        public static String ClString(string text)
        {
            return Regex.Replace(text, @"[49 ()-/]",string.Empty);
        }
        

    }
}
