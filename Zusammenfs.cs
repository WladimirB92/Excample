using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Zusammenfs
{
    class Program
    {


        static void Main(string[] args)
         {

             string ErsterWert = "15";
             string ZweiterWert = "12";

             string result = ErsterWert + ZweiterWert;
             int num1 = int.Parse(ErsterWert);
             int num2 = int.Parse(ZweiterWert);
             int resultInt = num1 + num2;

             Console.WriteLine(resultInt);




             Console.WriteLine(Calc());




             Console.ReadKey();
         }

         public static int Calc()
         {
             Console.WriteLine("bitte trage eine zahl ein");
             string Eingabe1 = Console.ReadLine();
             Console.WriteLine("trage eine zweite zahl ein");
             string Eingabe2 = Console.ReadLine();

             Console.WriteLine("das ergebinss deiner zahlen ist");
             int num3 = int.Parse(Eingabe2);
             int num4 = int.Parse(Eingabe1);
             int ResultAufg = num3 + num4;


             return ResultAufg;
         }
        static void Main(string[] args)
        {
            Console.WriteLine("Trage eine Zahl ein");
            string UserInput = Console.ReadLine();

            

            try
            {
                int UserInput1 = int.Parse(UserInput);
            }
            catch (Exception)
            {
                Console.WriteLine("Es ist ein Fehler aufgetreten");
            }
            // bool prüft ob das parsen funktioniert hat und tryparse braucht string , out int als ausgabewert
            bool BenutzerEingabe = int.TryParse(UserInput, out int num2);

            Console.ReadKey();

        static void Main(string[] args)
        {
            
               string Benutzername;
               int Pin;
               int PinLogParse;


               Console.WriteLine("Gebe deinen Benutzernamen ein");
               Benutzername = Console.ReadLine();

               Console.WriteLine("Gebe eine Pin ein");
               string UserPin = Console.ReadLine();
               bool PinParse = int.TryParse(UserPin,out Pin);

               if (Pin >0 )
               {
                   Console.WriteLine("du bist Registriert");
               }
               else
               {
                   Console.WriteLine("Deine Eingabe war Inkorrekt");
               }

               Console.WriteLine("Logge dich jetzt ein");
               Console.WriteLine("Gebe deien Benutzernamen ein");
               string BenutzerLog = Console.ReadLine();
               if (BenutzerLog == Benutzername)
               {
                   Console.WriteLine("Gebe deine Pin ein");
                   string PinLog = Console.ReadLine();

                   if (PinLog == UserPin)
                   {
                       Console.WriteLine("Du bist Eingeloggt");
                   }
                   else
                   {
                       Console.WriteLine("deine Eingabe war inkorrekt");
                   }
               }
               else
               {
                   Console.WriteLine("deine eingabe war inkorrekt");
               }


               Console.ReadKey();





            int[] Arraynum = new int[] { 1, 2, 4, 666, 765 };

            foreach(int num in Arraynum)
            {
                Console.WriteLine(num);
            }
            Console.ReadKey();

            string[] name = { "Günther", "Olaf", "Dieter", "Oliver" };

            Console.WriteLine(name[1]);
            Console.ReadKey();

            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();

            string[] stadt = { "München", "Berlin", "Frankfurt", "Dortmund" };

            Console.WriteLine("Ich bin der {0} und komme aus {1}",name[1],stadt[2]);
            Console.ReadKey();

            string prüfstadt = "Berlin";

            bool stadtPr = stadt[1].Contains(prüfstadt);

            if (stadtPr)
            {
                Console.WriteLine("Ja {0}, kommt aus Berlin",name[2]);
            }
            Console.WriteLine("Aufwiedersehn");
            Console.ReadLine();

            Console.WriteLine("Test");











        }



        
        

    }
}
