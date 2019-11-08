using System;
using TodoIt.Model;
using System.Threading;

namespace TodoIt
{
    class Program
    {
        static void Main(string[] args)
        {
            //Använder CONSTRUCTORN för att skapa ett objekt - därmed slår mina propetys till (propertys testar i unitest)
            Person aPerson = new Person(1, "Lisa", "Larsson");
            Console.Write($"{aPerson.FirstName}, {aPerson.LastName}");

            //Testa hämta värde personID
            //int dummy;
            //dummy = Convert.ToInt32(aPerson.personalId); //KOMP.FEL: personalId kan inte nås pga protection-level privat
            //dummy = Convert.ToInt32(aPerson.PersonalId); //använder constructorn (stor bokstav) 
            //Console.WriteLine("\nId: " + dummy);

            //Testa tilldela värde personID
            //funkar via constructorn ovan, behöver ej testa
            //aPerson.PersonalId = 8; //Här sker tilldelning utanför constructorn - ger komp.fel då fältet är read only (fins ej heller någon property som trumfar read.only

            System.Threading.Thread.Sleep(1000);

        }
    }
}
