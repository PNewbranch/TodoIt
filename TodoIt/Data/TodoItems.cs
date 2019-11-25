using System;
using TodoIt.Model;
using TodoIt.Data;


namespace TodoIt.Data
{
    public class TodoItems
    {
        public static Todo[] arrayOfTodoItems = new Todo[0];

        public static int Size()
        {
            return arrayOfTodoItems.Length;
        }

        public static Todo[] FindAll()
        {
            return arrayOfTodoItems;
        }

        //DENNA ÄR INTE AKTUELL EFTERSOM EN PERSON KAN HA FLERA TODO-OBJEKT - FINDEN SKALL SÅLEDES RETUNERA EN ARRAY
        //public static Todo FindById(int findTodoId)
        //{
        //    foreach (var Todo in arrayOfTodoItems)
        //    {
        //        if (Todo.TodoId == findTodoId)
        //            return Todo;
        //    }
        //    return null;
        //}

        public static Todo CreateANewTodoItem(string description, bool status, Person asignee)
        {
            Todo todo = new Todo(description, status, asignee);

            Todo[] arrayOfTodoItemsCopy = new Todo[arrayOfTodoItems.Length + 1];           //skapa en array som är en "box" större
            Array.Copy(arrayOfTodoItems, arrayOfTodoItemsCopy, arrayOfTodoItems.Length);   //kopiera över gamla arrayen (finns flera overloads)

            arrayOfTodoItemsCopy[arrayOfTodoItemsCopy.Length - 1] = todo;                   //lägg till nyligen skapade objektet - sista platsen skall vara tom
            arrayOfTodoItems = arrayOfTodoItemsCopy;                                        //här SKRIVER VI ÖVER - ej kopierar
            return todo;                                                                    //return arrayOfTodoItems[arrayOfTodoItems.Length - 1]; //ger samma som koden före
        }


        public static void Clear()
        {
            Array.Clear(arrayOfTodoItems, 0, arrayOfTodoItems.Length);  //resnar arrayens boxar
            TodoSequencer.ResetTodoId();                                //nollställer ID-räknaren 
        }


        //public static Todo[] FindByDoneStatus()
        //{
        //    Todo[] newArray = new Todo[arrayOfTodoItems.Length]; //utgå från en TVÅ lika stora arrayer - arrayen måste skapas UTANFÖR eventuella loopar så att den kan nås

        //    int copyCounter = 0;
        //    for (int i = 0; i < arrayOfTodoItems.Length; i++)
        //    {
        //        if (arrayOfTodoItems[i].done == true)
        //        {
        //            newArray[copyCounter] = arrayOfTodoItems[i]; //flytta över den hittade, börja på 0
        //            copyCounter++; //förbered för nästa överflytt
        //        }

        //    }

        //    Todo[] arrayToReturn = new Todo[copyCounter]; //skapa en anpassad array (lika stor som antal objekt)
        //    Array.Copy(newArray, 0, arrayToReturn, 0, copyCounter); //kopiera de överflyttade till nya anpassade arrayen

        //    return arrayToReturn;
        //}

        public static Todo[] FindByDoneStatus(bool status)
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







        public static Todo[] FindByAssignee(int personId)
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


        public static Todo[] FindByAssignee(Person person)
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


    }
}
