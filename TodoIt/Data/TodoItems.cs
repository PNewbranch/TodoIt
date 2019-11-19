using System;
using System.Collections.Generic;
using System.Text;
using TodoIt.Model;
using TodoIt.Data;


namespace TodoIt.Data
{
    public class TodoItems
    {
        public static Todo[] arrayOfItems = new Todo[0]; 

        public static int Size()  
        {
            return arrayOfItems.Length; 
        }

        public static Todo[] FindAll()
        {
            return arrayOfItems;
        }

        public static Todo FindById(int findTodoId)
        {
            foreach (var Todo in arrayOfItems)
            {
                if (Todo.todoId == findTodoId)
                    return Todo;
            }
            return null;
        }

        public static Todo CreateANewPerson(string firstName, string lastName) //skaper en ny person, lägg till personen i personarrayen, RETURN personen
        {
            int todoId = TodoSequencer.CreateNextTodoId();                        //hämta nytt id
            Todo todoItem = new Todo(todoId, firstName, lastName);                  //skapa person, använd nya id:
            Person[] arrayOfTodoitemsCopy = new Todo[arrayOfTodoItems.Length + 1];        //skapa en array som är en "box" större
            Array.Copy(arrayOfPersons, arrayOfPersonsCopy, arrayOfPersons.Length);      //kopiera över gamla arrayen (finns flera overloads)
                                                                                        //källa, destination, antal element att kopira 

            arrayOfPersonsCopy[arrayOfPersonsCopy.Length - 1] = person;                 //lägg till nyligen skapade personen - sista platsen skall vara tom
            arrayOfPersons = arrayOfPersonsCopy;                                        //här SKRIVER VI ÖVER - ej kopierar
            return todo; //return arrayOfPersons[arrayOfPersons.Length - 1]; //ger samma som nedan
        }

        //public static Person CreateANewPerson(string firstName, string lastName)        //skaper en ny person, lägg till personen i personarrayen, RETURN personen
        //{
        //    int personId = PersonSequencer.CreateNextPersonId();                        //hämta nytt id
        //    Person person = new Person(personId, firstName, lastName);                  //skapa person, använd nya id:
        //    Person[] arrayOfPersonsCopy = new Person[arrayOfPersons.Length + 1];        //skapa en array som är en "box" större
        //    Array.Copy(arrayOfPersons, arrayOfPersonsCopy, arrayOfPersons.Length);      //kopiera över gamla arrayen (finns flera overloads)
        //                                                                                //källa, destination, antal element att kopira 

        //    arrayOfPersonsCopy[arrayOfPersonsCopy.Length - 1] = person;                 //lägg till nyligen skapade personen - sista platsen skall vara tom
        //    arrayOfPersons = arrayOfPersonsCopy;                                        //här SKRIVER VI ÖVER - ej kopierar
        //    return person; //return arrayOfPersons[arrayOfPersons.Length - 1]; //ger samma som den till vänster
        //}

        public static void Clear()
        {
            Array.Clear(arrayOfItems, 0, arrayOfItems.Length);
        }

    }
}
