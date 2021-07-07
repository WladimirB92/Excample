using System;

namespace AufgabeVererbung
{
    class Program
    {
        static void Main(string[] args)
        {
            Emplyoee Henry = new Emplyoee("Henry","ulli",12000);
            Henry.Work();
            Henry.Pause();

            boss wowa = new boss("BMW"," Benni","wilfred",100000);
            wowa.Lead();
            wowa.Work();

            Trainee_Employee robert = new Trainee_Employee(30, 12, "Müller", "Robert", 500);
            robert.Learn();
            robert.Work();

            leiharbeiter Denis = new leiharbeiter(12000, 39, "pima", "Denis");
            Denis.leiharbeiter1();

            leiharbeiter Olaf = new leiharbeiter(5000, 20, "power", "Detlef");
            Olaf.leiharbeiter1();

            boss Wowa = new boss("benz", " Wilfred", "Heftig", 1000000);
            Wowa.Lead();
            Wowa.Pause();

            
            


            Console.ReadKey();
        }
    }
}
