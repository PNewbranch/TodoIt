using System;
using System.Collections.Generic;
using System.Text;

namespace TodoIt.Model
{
    public class Todo
    {
        private readonly int todoId; //**här behöver vi ingen Property (klassen Person har annan lösning för att hantera "readonly", en Property utan set
        private string description;
        private bool done;
        private Person assignee;

        public int TodoId
        {
            get
            {
                return todoId;
            }
            //Saknar SET
        }

        public Todo(int todoId, string description) //två inparameterar vid anrop
        {
            this.todoId = todoId;               //finns i propertys-metoder
            this.description = description;     //finns i propertys-metoder
            this.done = false;
            this.assignee = null;
        }

    }
}