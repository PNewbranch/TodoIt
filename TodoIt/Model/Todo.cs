using TodoIt.Data;

namespace TodoIt.Model
{
    public class Todo
    {
        private readonly int todoId; //**här behöver vi ingen Property (klassen Person har annan lösning för att hantera "readonly", en Property utan set
        private string description;
        public bool done;
        public Person assignee;

        public int TodoId
        {
            get
            {
                return todoId;
            }
            //Saknar SET
        }

        public Todo(string description, bool status, Person assignee)
        {
            this.todoId = TodoSequencer.CreateNextTodoId();
            this.description = description;
            this.done = status;
            this.assignee = assignee;
        }

    }
}