namespace TodoIt.Data
{
    public class TodoSequencer
    {
        private static int todoId;

        public static int CreateNextTodoId()
        {
            return ++todoId;
        }

        public static void ResetTodoId()
        {
            todoId = 0;
        }

    }
}
