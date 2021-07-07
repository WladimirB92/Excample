using System;
using System.Collections.Generic;
using System.Text;

namespace AufgabeVererbung
{
    class leiharbeiter:Emplyoee
    {
        public int gehalt { get; set; }
        public int stundenLA { get; set; }
        public string GastFirma { get; set; }

        public void leiharbeiter1()
        {
            Console.WriteLine("Leiharbeiter {0} ist bei firma {1} angestellt, stunden wochen sind {2} und das gehalt {3}",Name,GastFirma,stundenLA,gehalt);
        }

        public leiharbeiter(int gehalt,int stundenLA,string GastFirma, string name )
        {
            this.gehalt = gehalt;
            this.stundenLA = stundenLA;
            this.GastFirma = GastFirma;
            this.Name = name;
            
        }
    }
}
