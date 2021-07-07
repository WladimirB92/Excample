using System;
using System.Collections.Generic;
using System.Text;

namespace AufgabeVererbung
{
    class FirmenAuto
    {
        public string Marke { get; set; }
        public int PS { get; set; }
        public string Farbe { get; set; }

        

        public FirmenAuto(string Marke,int PS,string Farbe)
        {
            this.Marke = Marke;
            this.PS = PS;
            this.Farbe = Farbe;
        }
        public FirmenAuto()
        {
            Marke = "BMW";
            PS = 150;
            Farbe = "Weiß";
        }


        public FirmenAuto(string Marke,int PS,string Farbe)
        {
            Console.WriteLine("Das Firmen Auto ist von der Marke {0} hat ungefähr {1} PS, die Farbe ist {2} ", Marke, PS, Farbe);
        }
    }
}
