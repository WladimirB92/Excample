using System;
using System.Collections.Generic;
using System.Text;

namespace AufgabeVererbung
{
    class Emplyoee
    {
        public string Name { get; set; }
        public string Firstname { get; set; }
        public int Sallary { get; set; }


        public Emplyoee(string Name, string Firstname, int Sallary)
        {
            this.Name = Name;
            this.Firstname = Firstname;
            this.Sallary = Sallary;
        }

        public Emplyoee()
        {
            Name = "Mulkler";
            Firstname = "wilfred";
            Sallary = 5000;

        }
        public void Work()
        {
            Console.WriteLine("ich arbeite");
        }

        public void Pause()
        {
            Console.WriteLine("ich mache Pause");
        }
    }
}
