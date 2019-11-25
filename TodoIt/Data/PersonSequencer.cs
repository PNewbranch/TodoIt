namespace TodoIt.Data
{
    public class PersonSequencer
    {
        private static int personId;

        public static int CreateNextPersonId()
        {
            return ++personId; //första loopen: ++före ger 1 ++efter ger 0
        }

        public static void ResetPersonId()
        {
            personId = 0;
        }

    }
}
