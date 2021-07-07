using System;
using System.Collections.Generic;
using System.Text;

namespace AufgabeVererbung
{
    class Trainee_Employee : Emplyoee
    {

        public int WorkHours { get; set; }
        public int SchoolHours { get; set; }

        public Trainee_Employee(int workingHours,int schoolhours, string name,string Firstname,int sallary)
        {
            this.WorkHours = workingHours;
            this.SchoolHours = schoolhours;
            this.Name = name;
            this.Firstname = Firstname;
            this.Sallary = sallary;
        }
        public void Learn()
        {
            Console.WriteLine("ich lerne {0} stunden in der Woche",SchoolHours);
        }


        public void Work()
        {
            Console.WriteLine("ich arbeite {0} stunden in der Woche",WorkHours);
        }
    }
}
