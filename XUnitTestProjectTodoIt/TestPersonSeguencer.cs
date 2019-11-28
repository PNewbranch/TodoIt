using TodoIt.Data;
using Xunit;

namespace XUnitTestProjectTodoIt
{
    public class TestPersonSeguencer
    {
        [Fact]
        public void IncreasePersonSequencer()
        {
            //Arrange
            int personId1 = PersonSequencer.CreateNextPersonId();
            int personId2 = PersonSequencer.CreateNextPersonId();

            //Act

            //Assert
            Assert.True(personId1 < personId2);
        }

        [Fact]
        public void ResetPersonSequencer()
        {
            //Arrange
            int personId3 = PersonSequencer.CreateNextPersonId();
            int personId4 = PersonSequencer.CreateNextPersonId();

            //Act
            PersonSequencer.ResetPersonId(); //räknaren nollställs
            int personId5 = PersonSequencer.CreateNextPersonId();

            //Assert
            Assert.True(personId5 == 1);
        }

    }
}
