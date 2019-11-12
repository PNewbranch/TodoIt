using System;
using Xunit;
using TodoIt.Model;
using TodoIt.Data;
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
            int todoId1 = 0;
            int todoId2 = 0;

            //Act
            todoId1 = TodoSequencer.CreateNextTodoId();  
            todoId2 = TodoSequencer.CreateNextTodoId();

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
            Assert.True(todoId5 < todoId4);
        }

    }
}
