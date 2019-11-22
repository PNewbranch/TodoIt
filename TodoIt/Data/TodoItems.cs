using System;
using System.Collections.Generic;
using System.Text;
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

        public static Todo FindById(int findTodoId)
        {
            foreach (var Todo in arrayOfTodoItems)
            {
                if (Todo.TodoId == findTodoId)
                    return Todo;
            }
            return null;
        }

        public static Todo CreateANewTodoItem(string description)
        {
            int todoId = TodoSequencer.CreateNextTodoId(); 
            Todo todo = new Todo(todoId, description); 

            Todo[] arrayOfTodoItemsCopy = new Todo[arrayOfTodoItems.Length + 1];           //skapa en array som är en "box" större
            Array.Copy(arrayOfTodoItems, arrayOfTodoItemsCopy, arrayOfTodoItems.Length);   //kopiera över gamla arrayen (finns flera overloads)
                                                                                           //källa, destination, antal element att kopira 

            arrayOfTodoItemsCopy[arrayOfTodoItemsCopy.Length - 1] = todo;                   //lägg till nyligen skapade objektet - sista platsen skall vara tom
            arrayOfTodoItems = arrayOfTodoItemsCopy;                                        //här SKRIVER VI ÖVER - ej kopierar
            return todo; //return arrayOfTodoItems[arrayOfTodoItems.Length - 1]; //ger samma som koden före
        }


        public static void Clear()
        {
            Array.Clear(arrayOfTodoItems, 0, arrayOfTodoItems.Length);  //resnar arrayens boxar
            TodoSequencer.ResetTodoId();                                //nollställer ID-räknaren 
        }


        public static Todo[] FindByDoneStatus(bool done)
        {

            Todo[] arrayOfDone = new Todo[0];
            int copyCounter = 0;

            for (int i = 0; i < arrayOfTodoItems.Length; i++)
            {
                if (arrayOfTodoItems[i].done == true) {
                    copyCounter++;
                    arrayOfDone[copyCounter] = new Todo[arrayOfTodoItems[i];

                    Array.Copy(arrayOfTodoItems[i], arrayOfDone, 0, copyCounter);
                }

            }

            return arrayOfDone;
        }







}
}
