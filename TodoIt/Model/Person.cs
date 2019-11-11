using System;
using System.Collections.Generic;
using System.Text;

//kontrollera att testprogrammet har DEPENDENCIES satt till det det testar (i detta fall "TodoIt" bockas för Add Dependencies)

namespace TodoIt.Model
{
    public class Person  //Testprogram hittar ej klassen?? gör klassen publik (om inget access modifier finns är denna per automatik PRIVATE)
    {

        private int personalId; 
        private string firstName;
        private string lastName;

        public int PersonalId //har ändrat denna från string samt tagit bort konvertering i returnen
        {
            get //skall kunna hämta ett id 
            {
                return personalId;   //return är alltid string, måste därför göra om integern
            }
            //private set //användare skall aldring kunna sätta värdet (görs senare i uppgiften - automatgenereras)
            //{
            //}
        }

        public string FirstName //metod för anpassad get/set
        {
            get
            {
                return firstName;
            }
            set
            {
                if (value == null || value == "")
                {
                    throw new Exception("Förnamn måste anges.");
                }
                else
                {
                    firstName = value;
                }
            }
        }

        public string LastName //medod för anpassad get/set
        {
            get
            {
                return lastName;
            }
            set
            {
                if (value == null || value == "")
                {
                    throw new Exception("Efternamn måste anges.");
                }
                else
                {
                    lastName = value;
                }
            }
        }

        public Person(int personalId, string firstName, string lastName)  //constructor med inparameterar från ANVÄNDAREN
        {                                                                 //3/3 passing = tre tester som alla använder constructor
            this.personalId = personalId;   //här har vi INGEN metod för propertys därför använder vi "this"
            //PersonalId = personalId;      //här använder vi en propertymetod men skall den kunna användas så måste SET ovan aktiveras

            FirstName = firstName;          //STOR förstabokstav = här använder vi våra metoder/PROPERTYS (input är våra värden från pgm:et vi testar 
            LastName = lastName;
        }

        //public Person(string firstName, string lastName)  //constructor med inparameterar från ANVÄNDAREN
        //{                                                                 //3/3 passing = tre tester som alla använder constructor
        //    this.personalId = personalId;   //här har vi INGEN metod för propertys därför använder vi "this"
        //    //PersonalId = personalId;      //här använder vi en propertymetod men skall den kunna användas så måste SET ovan aktiveras

        //    FirstName = firstName;          //STOR förstabokstav = här använder vi våra metoder/PROPERTYS (input är våra värden från pgm:et vi testar 
        //    LastName = lastName;
        //}



    }
}
