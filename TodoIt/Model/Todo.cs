using System;
using System.Collections.Generic;
using System.Text;

namespace TodoIt.Model
{
    public class Todo
    {
        public readonly int todoId; //**här behöver vi ingen Property (klassen Person har annan lösning för att hantera "readonly", en Property utan set
        private string description;
        private bool done;
        private Person assignee;


        public Todo(int todoId, string description) //två inparameterar vid anrop
        {
            this.todoId = todoId;           //**denna rad använder inte fältets propertymetod
            this.description = description;
        }

    }
}
