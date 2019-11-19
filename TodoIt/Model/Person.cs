using System;
using System.Collections.Generic;
using System.Text;

//kontrollera att testprogrammet har DEPENDENCIES satt till det det testar (i detta fall "TodoIt" bockas för Add Dependencies)

namespace TodoIt.Model
{
    public class Person  //om inget access modifier finns är denna per automatik PRIVATE)
    {
        private readonly int personalId; 
        private string firstName;
        private string lastName;

        public int PersonalId 
        {
            get 
            {
                return personalId;
            }
            //Saknar SET
        }

        public string FirstName 
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
            this.personalId = personalId;   //saknar metod för propertys därför använder vi "this"
            FirstName = firstName;          //STOR förstabokstav = använder PROPERTYS-metoden 
            LastName = lastName;
        }


    }
}
