using System;
using System.Collections.Generic;
using System.Text;

namespace TodoIt.Model
{
    public class Todo
    {
        private readonly int todoId; //**här behöver vi ingen Property (klassen Person har annan lösning för att hantera "readonly", en Property utan set
        private string description;
        public bool done;
        private Person assignee;

        public int TodoId
        {
            get
            {
                return todoId;
            }
            //Saknar SET
        }

        public Todo(int todoId, string description, bool status, Person assignee) 
        {
            this.todoId = todoId;  
            this.description = description; 
            this.done = status;
            this.assignee = assignee;
        }

    }
}