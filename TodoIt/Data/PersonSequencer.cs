using System;
using System.Collections.Generic;
using System.Text;

namespace TodoIt.Data
{
    class PersonSequencer
    {
        private static int personId;

        static int nextPersonId()
        {
            return personId--;
        }

        static void reset ()
        {
            personId = 0;
        }

    }
}
