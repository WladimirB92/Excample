using System;
using System.Collections.Generic;
using System.Text;

namespace AufgabeVererbung
{
    class boss:Emplyoee
    {
        public string CompanyCar { get; set; }

        public boss(string CompanyCar,string Name,string FirstName,int Salary)
        {
            this.CompanyCar = CompanyCar;
            this.Name = Name;
            this.Firstname = FirstName;
            this.Sallary = Salary;
        }
        public void Lead()
        {
            Console.WriteLine("ich bin chef{0} {1}",Name,Firstname);
        }

    }
}
