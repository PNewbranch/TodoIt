using System;
using System.Collections.Generic;
using System.Text;

namespace TodoIt.Model
{
    public class Todo
    {
        private int todoId;
        private string description;
        private bool done;
        private Person assignee;

        //public int TodoId
        //{
        //    get //skall kunna hämta ett id 
        //    {
        //        return todoId;   //return är alltid string, måste därför göra om integern
        //    }
        //    private set //användare skall aldring kunna sätta värdet (görs senare i uppgiften - automatgenereras)
        //    {
        //    }
        //}

        public Todo(int todoId, string description) //två inparameterar vid anrop
        {
            this.todoId = todoId;     //denna rad anvender inte fältets propertymetod
            //TodoId = todoId;            //här använder vi fältets propertymetod
            this.description = description;
        }

    }
}
