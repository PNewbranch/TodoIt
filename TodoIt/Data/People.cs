using System;
using System.Collections.Generic;
using System.Text;
using TodoIt.Model;
using TodoIt.Data;

namespace TodoIt.Data
{

    public class People ///OBS glöm inte public!!  //DETTA ÄR DATA(alltså objekt) - DÄR MAN ANVÄNDER MODEL(KLASSER)
    {

        public static Person[] arrayOfPersons = new Person[0]; //array med personer

        public static int Size() //arrayen finns tillgänglig i klassen - alltså ingen input nödvändig, RETURN integer                             
        {
            return arrayOfPersons.Length; //svarar med integer innehållande arrayens längd
        }

        public static Person[] FindAll() //har access till klassen, RETURN hela arrayen
        {
            return arrayOfPersons; //svarar med ALLA personer i arrayen
        }

        public static Person FindById(int findPersonId) //input ett id, RETURN det specifika objektet
        {
            //Eftersom jag befinner mig i en ARRAY av OBJECT så måste jag gå igenom ALLA och kika efter om resp objekts specifika (går att lösa genom avancerad programmering - men där är jag inte nu)
            foreach (var Person in arrayOfPersons)
            {
                if (Person.PersonalId == findPersonId)
                    return Person; //om träff, skicka objektet
            }
            return null;
        }

        public static Person CreateANewPerson(string firstName, string lastName) //skaper en ny person, lägg till personen i personarrayen, RETURN personen
        {
            int personId = PersonSequencer.CreateNextPersonId();                        //hämta nytt id
            Person person = new Person(personId, firstName, lastName);                  //skapa person, använd nya id:
            Person[] arrayOfPersonsCopy = new Person[arrayOfPersons.Length + 1];        //skapa en array som är en "box" större
            Array.Copy(arrayOfPersons, arrayOfPersonsCopy, arrayOfPersons.Length);  //kopiera över gamla arrayen (finns flera overloads)
                       //källa, destination, antal element att kopira 
                       
            arrayOfPersonsCopy[arrayOfPersonsCopy.Length - 1] = person;                 //lägg till nyligen skapade personen - sista platsen skall vara tom
            arrayOfPersons = arrayOfPersonsCopy;                                        //här SKRIVER VI ÖVER - ej kopierar

            //return arrayOfPersons[arrayOfPersons.Length - 1]; //ger samma som nedan
            return person;  //retunera skapade personen
        }

        public static void Clear() //void = ingen RETURN
        {
            Array.Clear(arrayOfPersons, 0, arrayOfPersons.Length);
        }




    }
}
