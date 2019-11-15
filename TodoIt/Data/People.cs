using System;
using System.Collections.Generic;
using System.Text;
using TodoIt.Model;
using TodoIt.Data;

namespace TodoIt.Data
{

    public class People ///OBS glöm inte public!!  //DETTA ÄR DATA(alltså objekt) - DÄR MAN ANVÄNDER MODEL(KLASSER)
    {

        private static Person[] arrayOfPersons = new Person[0]; //array med personer

        public static int Size() //arrayen finns tillgänglig i klassen - alltså ingen input nödvändig, output integer                             
        {
            return arrayOfPersons.Length; //svarar med integer innehållande arrayens längd
        }

        public static Person[] FindAll() //har access till klassen, output hela arrayen
        {
            return arrayOfPersons; //svarar med ALLA personer i arrayen
        }

        public static Person FindById(int findPersonId) //input ett id, output det specifika objektet
        {
            //Eftersom jag befinner mig i en ARRAY av OBJECT så måste jag gå igenom ALLA och kika efter om resp objekts specifika fält har det aktuella värdet
            //(går att lösa genom avancerad programmering - men där är jag inte nu

            // int searchResult = Array.IndexOf(Person[] arrayOfPersons, Person. findPersonId);

            if (Array.IndexOf(arrayOfPersons, findPersonId) > -1) {
                return arrayOfPersons[findPersonId]; //om träff, skicka objektet
                Array.IndexOf()
            }
            else
            {
                return null;
            }
        }

        public static Person CreateANewPerson(string firstName, string lastName) //skaper en ny person, lägg till personen i personarrayen, retunerar personen
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

        public static void Clear() //static för att bli synlig
        {
            Person[] personArray = new Person[0]; //skapar en ny array med 0 objekt = tom
        }


    }
}
