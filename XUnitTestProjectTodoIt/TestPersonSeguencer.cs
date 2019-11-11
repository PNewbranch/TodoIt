using System;
//using System.Collections.Generic;
//using System.Text;
using TodoIt.Model;
using Xunit;

namespace XUnitTestProjectTodoIt
{
    public class TestPersonSeguencer
    {

        [Fact]
        public void IncreasePersonSequencer()
        {
            //Arrange
            int personId = 0;

            //Act
            personId++;

            //Assert
            Assert.Equal(1, personId);

        }

        [Fact]
        public void ResetPersonSequencer()
        {
            //Arrange
            int personId = 2;

            //Act
            personId=0;

            //Assert
            Assert.Equal(0, personId);

        }

    }
}
