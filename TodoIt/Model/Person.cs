using System;
using System.Collections.Generic;
using System.Text;

//kontrollera att testprogrammet har DEPENDENCIES satt till det det testar (i detta fall "TodoIt" bockas för Add Dependencies)

namespace TodoIt.Model
{
    public class Person  //Testprogram hittar ej klassen?? gör klassen publik (om inget access modifier finns är denna per automatik PRIVATE)
    {

        private int personalId; //använder default get/set
        private string firstName;
        private string lastName;

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
        {
            this.personalId = personalId;   //här har vi ingen metod för propertys därför använder vi "this"
            FirstName = firstName;          //kastar vi in värderna från användaren in i property-metoden
            LastName = lastName;
        }

    }
}
