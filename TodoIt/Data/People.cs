using System;
using TodoIt.Model;

namespace TodoIt.Data
{

    public class People
    {
        private static Person[] arrayOfPersons = new Person[0]; //skall senare kunna bytas ut av en Databas, så BARA denna får vara static

        public int Size() //för att man skall slippa "STATIC" så måste man skapa ett OBJEKT i Implementering och TESTER 
        {
            return arrayOfPersons.Length;
        }

        public Person[] FindAll() 
        {
            return arrayOfPersons;
        }

        public Person FindById(int findPersonId)
        {
            foreach (var person in arrayOfPersons)
            {
                if (person.PersonalId == findPersonId)
                    return person;
            }
            return null;
        }

        public Person CreateANewPerson(string firstName, string lastName) 
        {
            Person person = new Person(firstName, lastName);                            //skapa person, använd nya id:
            Person[] arrayOfPersonsCopy = new Person[arrayOfPersons.Length + 1];        //skapa en array som är en "box" större
            Array.Copy(arrayOfPersons, arrayOfPersonsCopy, arrayOfPersons.Length);      //kopiera över gamla arrayen (finns flera overloads)
            arrayOfPersonsCopy[arrayOfPersonsCopy.Length - 1] = person;                 //lägg till nyligen skapade personen - sista platsen skall vara tom
            arrayOfPersons = arrayOfPersonsCopy;  //varför måste jag inte förstora originalarrayen (SKRIVER VI ÖVER - ej kopierar)
            return person;
        }

        public void Clear() 
        {
            Array.Clear(arrayOfPersons, 0, arrayOfPersons.Length);
            PersonSequencer.ResetPersonId();
        }

        public void RemovePerson(int personId)
        {
            int counter = 0;
            bool exists = false;
            Person[] newArray = new Person[arrayOfPersons.Length - 1];

            foreach (Person person in arrayOfPersons) //Finns annat sätt eller måste jag alltid "öppna" varje objekt?
            {
                if (person.PersonalId == personId)
                {
                    exists = true;
                    break;
                }
                else
                    counter++;
            }

            if (exists) {
                Array.Copy(People.arrayOfPersons, 0, newArray, 0, counter); //kopiera det före
                Array.Copy(People.arrayOfPersons, counter+1, newArray, counter, People.arrayOfPersons.Length-counter-1); //kopiera det efter
                arrayOfPersons = newArray; //Skriver över
            }
        }

    }
}
