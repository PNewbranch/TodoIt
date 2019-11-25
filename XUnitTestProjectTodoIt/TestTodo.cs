using TodoIt.Model;
using Xunit;
//using System.Collections.Generic;
//using System.Text;

namespace XUnitTestProjectTodoIt
{
    public class TestTodo
    {

        [Fact]
        public void CreateTodoOK() //
        {
            //Arrange
            Person assignee = new Person("Sixten", "Blixen");
            Todo testTodo = new Todo("Gräv din grav", false, assignee);

            ////Act

            //Asset
            Assert.NotNull(testTodo); //verifiera att testpersonen skapat
        }


    }
}
