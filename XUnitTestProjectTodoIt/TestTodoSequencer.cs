using TodoIt.Data;
using Xunit;
//using System.Collections.Generic;
//using System.Text;

namespace XUnitTestProjectTodoIt
{
    public class TestTodoSequencer
    {

        [Fact]
        public void IncreaseTodoSequencer() //vi testar klassen TodoSequencer, att räkna upp
        {
            //Arrange
            int todoId1 = TodoSequencer.CreateNextTodoId();
            int todoId2 = TodoSequencer.CreateNextTodoId();

            //Act

            //Assert
            Assert.True(todoId1 < todoId2);
        }

        [Fact]
        public void ResetTodoSequencer() //vi testar klassen TodoSequencer, att nollställa
        {
            //Arrange
            int todoId3 = TodoSequencer.CreateNextTodoId();
            int todoId4 = TodoSequencer.CreateNextTodoId();

            //Act
            TodoSequencer.ResetTodoId(); //denna nollställer bara, inget returvärde (void)
            int todoId5 = TodoSequencer.CreateNextTodoId();

            //Assert
            Assert.True(todoId5 == 1);
        }

    }
}
