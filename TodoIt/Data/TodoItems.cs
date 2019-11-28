using System;
using TodoIt.Model;

namespace TodoIt.Data
{
    public class TodoItems
    {
        public static Todo[] arrayOfTodoItems = new Todo[0]; //DB - skall senare kunna bytas ut av en Databas

        public int Size()
        {
            return arrayOfTodoItems.Length;
        }

        public Todo[] FindAll()
        {
            return arrayOfTodoItems;
        }

        public Todo FindById(int findTodoId)
        {
            foreach (var Todo in arrayOfTodoItems)
            {
                if (Todo.TodoId == findTodoId)
                    return Todo;
            }
            return null;
        }

        public Todo CreateANewTodoItem(string description, bool status, Person asignee)
        {
            Todo todo = new Todo(description, status, asignee);

            Todo[] arrayOfTodoItemsCopy = new Todo[arrayOfTodoItems.Length + 1];           //skapa en array som är en "box" större
            Array.Copy(arrayOfTodoItems, arrayOfTodoItemsCopy, arrayOfTodoItems.Length);   //kopiera över gamla arrayen (finns flera overloads)

            arrayOfTodoItemsCopy[arrayOfTodoItemsCopy.Length - 1] = todo;                   //lägg till nyligen skapade objektet - sista platsen skall vara tom
            arrayOfTodoItems = arrayOfTodoItemsCopy;                                        //här SKRIVER VI ÖVER - ej kopierar
            return todo;                                                                    //return arrayOfTodoItems[arrayOfTodoItems.Length - 1]; //ger samma som koden före
        }

        public void Clear()
        {
            Array.Clear(arrayOfTodoItems, 0, arrayOfTodoItems.Length);
            TodoSequencer.ResetTodoId();
        }

        public Todo[] FindByStatus(bool status)
        {
            Todo[] newArray = new Todo[arrayOfTodoItems.Length]; //utgå från en TVÅ lika stora arrayer - arrayen måste skapas UTANFÖR eventuella loopar så att den kan nås

            int copyCounter = 0;
            for (int i = 0; i < arrayOfTodoItems.Length; i++)
            {
                if (arrayOfTodoItems[i].done == status)
                {
                    newArray[copyCounter] = arrayOfTodoItems[i]; //flytta över den hittade, börja på 0
                    copyCounter++; //förbered för nästa överflytt
                }

            }
            Todo[] arrayToReturn = new Todo[copyCounter]; //skapa en anpassad array (lika stor som antal objekt)
            Array.Copy(newArray, 0, arrayToReturn, 0, copyCounter); //kopiera de överflyttade till nya anpassade arrayen
            return arrayToReturn;
        }

        public Todo[] FindByAssignee(int personId)
        {
            Todo[] newArray = new Todo[arrayOfTodoItems.Length]; //utgå från en TVÅ lika stora arrayer - arrayen måste skapas UTANFÖR eventuella loopar så att den kan nås

            int copyCounter = 0;
            for (int i = 0; i < arrayOfTodoItems.Length; i++)
            {
                if (arrayOfTodoItems[i].assignee.PersonalId == personId)
                {
                    newArray[copyCounter] = arrayOfTodoItems[i]; //flytta över den hittade, börja på 0
                    copyCounter++; //förbered för nästa överflytt
                }
            }
            Todo[] arrayToReturn = new Todo[copyCounter]; //skapa en anpassad array (lika stor som antal objekt)
            Array.Copy(newArray, 0, arrayToReturn, 0, copyCounter); //kopiera de överflyttade till nya anpassade arrayen
            return arrayToReturn;
        }

        public Todo[] FindByAssignee(Person person)
        {
            Todo[] newArray = new Todo[arrayOfTodoItems.Length]; //utgå från en TVÅ lika stora arrayer - arrayen måste skapas UTANFÖR eventuella loopar så att den kan nås

            int copyCounter = 0;
            for (int i = 0; i < arrayOfTodoItems.Length; i++)
            {
                if (arrayOfTodoItems[i].assignee == person)
                {
                    newArray[copyCounter] = arrayOfTodoItems[i]; //flytta över den hittade, börja på 0
                    copyCounter++; //förbered för nästa överflytt
                }
            }
            Todo[] arrayToReturn = new Todo[copyCounter]; //skapa en anpassad array (lika stor som antal objekt)
            Array.Copy(newArray, 0, arrayToReturn, 0, copyCounter); //kopiera de överflyttade till nya anpassade arrayen
            return arrayToReturn;
        }





        public Todo[] FindUnassignedTodoItems()
        {
            Todo[] newArray = new Todo[arrayOfTodoItems.Length]; //utgå från en TVÅ lika stora arrayer - arrayen måste skapas UTANFÖR eventuella loopar så att den kan nås

            int copyCounter = 0;
            for (int i = 0; i < arrayOfTodoItems.Length; i++) //kör igenom hela originalarrayen
            {
                if (arrayOfTodoItems[i].assignee == null)
                {
                    newArray[copyCounter] = arrayOfTodoItems[i]; //vid träff flyttas denna över till kopian (börja på pos 0)
                    copyCounter++; //förbered för nästa överflytt
                }
            }

            Todo[] arrayToReturn = new Todo[copyCounter]; //skapa en anpassad array (lika stor som antal objekt)
            Array.Copy(newArray, 0, arrayToReturn, 0, copyCounter); //kopiera de överflyttade till nya anpassade arrayen
            return arrayToReturn;
        }




        public void RemoveTodo(int todoId)
        {
            int counter = 0;
            bool exists = false;
            Todo[] newArray = new Todo[arrayOfTodoItems.Length - 1];

            foreach (Todo todo in arrayOfTodoItems) //Finns annat sätt eller måste jag alltid "öppna" varje objekt?
            {
                if (todo.TodoId == todoId)
                {
                    exists = true;
                    break;
                }
                else
                    counter++;
            }

            if (exists)
            {
                Array.Copy(TodoItems.arrayOfTodoItems, 0, newArray, 0, counter); //kopiera det före (då samma längd)
                Array.Copy(TodoItems.arrayOfTodoItems, counter + 1, newArray, counter, TodoItems.arrayOfTodoItems.Length - counter - 1); //kopiera in ihoptryckt version i ny array som är en box kortare 
                arrayOfTodoItems = newArray; //Skriver över
            }
        }

    }
}
