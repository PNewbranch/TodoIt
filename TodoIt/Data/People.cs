using System;
using System.Collections.Generic;
using System.Text;
using TodoIt.Model;
using TodoIt.Data;

namespace TodoIt.Data
{

    public class People 
    {

        public static Person[] arrayOfPersons = new Person[0]; 

        public static int Size()            
        {
            return arrayOfPersons.Length;
        }

        public static Person[] FindAll()
        {
            return arrayOfPersons;
        }

        public static Person FindById(int findPersonId)
        {
            foreach (var Person in arrayOfPersons)
            {
                if (Person.PersonalId == findPersonId)
                    return Person;
            }
            return null;
        }

        public static Person CreateANewPerson(string firstName, string lastName)        //skaper en ny person, lägg till personen i personarrayen, RETURN personen
        {
            int personId = PersonSequencer.CreateNextPersonId();                        //hämta nytt id
            Person person = new Person(personId, firstName, lastName);                  //skapa person, använd nya id:
            Person[] arrayOfPersonsCopy = new Person[arrayOfPersons.Length + 1];        //skapa en array som är en "box" större
            Array.Copy(arrayOfPersons, arrayOfPersonsCopy, arrayOfPersons.Length);      //kopiera över gamla arrayen (finns flera overloads)
                       //källa, destination, antal element att kopira 
                       
            arrayOfPersonsCopy[arrayOfPersonsCopy.Length - 1] = person;                 //lägg till nyligen skapade personen - sista platsen skall vara tom
            arrayOfPersons = arrayOfPersonsCopy;                                        //här SKRIVER VI ÖVER - ej kopierar
            return person; //return arrayOfPersons[arrayOfPersons.Length - 1]; //ger samma som den till vänster
        }

        public static void Clear() //void = ingen RETURN
        {
            Array.Clear(arrayOfPersons, 0, arrayOfPersons.Length);
        }

    }
}
