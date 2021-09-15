using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;

namespace Z_L
   
{
    class Program
    {
        static void Main(string[] args)
        {

            RechnenAdd();
            Console.WriteLine("nochmal ? ");
            string weiter = Console.ReadLine();
            while(weiter == "ja")
            {
                RechnenAdd();
                Console.WriteLine("nochmal ?");
                weiter = Console.ReadLine();
            }

            if (weiter == "nein")
            {
                Console.WriteLine("Danke, drücken Sie eine Taste um zu Beenden");
            }
            

            Ende();
        }
        static void Ende()
        {
            Console.ReadLine();
        }
        static int Random1(int maxValue)
        {
            Random zufallsZahl = new Random();
            int zahl;
            int minValue = 1;

            zahl = (int)zufallsZahl.Next(minValue, maxValue);
            return zahl;
        }
        static int Random2(int maxValue1)
        {
            Random random = new Random();
            
            int r = random.Next(maxValue1);
            return r;
        }
        static string Eingabe()
        {
            Console.WriteLine("Gebe die Zahl ein, welche errechnet werden soll");
            string eingabe = Console.ReadLine();       
            return eingabe;

        }
        public static void RechnenAdd()
        {

            string eingabe = Eingabe();
            Console.WriteLine("wieviele Ergebnisse wollen Sie?");
            
            int maxErg = int.Parse(Console.ReadLine());
            Console.WriteLine("Berechnung läuft");

            int num1;
            int.TryParse(eingabe, out num1);



           // int[] SummeErg = new int[maxErg];


            int anzahlInter=0;
            var vergleich = new List<int>();
            


            while (anzahlInter != maxErg)
            {
                
                int Zahl1 = Random1(130);
                Thread.Sleep(8);
                int Zahl2 = Random2(100);
                int ergebniss = Zahl1 + Zahl2;
                
                Console.WriteLine(Zahl1);
                Console.WriteLine("+");
                Console.WriteLine(Zahl2);
                Console.WriteLine("==");          
                Console.WriteLine(ergebniss);   
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("");

                if (num1 == ergebniss)
                {

                    vergleich.Add(Zahl1);
                    vergleich.Add(Zahl2);
                    

                    for (int i = 0; i < maxErg; i++)
                    {
                        i = ergebniss;
                        Console.WriteLine("Summe aus {0} und {1} ergibt die gewünschte Zahl", Zahl1, Zahl2);
                    }
                    
                    anzahlInter++;
                }

            }
            IEnumerable<int> disable = vergleich.Distinct();

            Console.WriteLine("Folgende zahlen ergeben die gesuchte zahl");
            foreach (var zahlen in disable)
            {
                
                
                Console.WriteLine(zahlen);
                Console.WriteLine("------");
                
            }
        }
        
        
    } 

}
