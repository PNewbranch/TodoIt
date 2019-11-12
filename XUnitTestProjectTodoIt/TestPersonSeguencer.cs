using System;
using Xunit;
using TodoIt.Model;
using TodoIt.Data;


namespace XUnitTestProjectTodoIt
{
    public class TestPersonSeguencer
    {

        [Fact]
        public void IncreasePersonSequencer()
        {
            //Arrange
            int personId1 = 0;
            int personId2 = 0;

            //Act
            personId1 = PersonSequencer.CreateNextPersonId(); //testa OBJEKTET PersonSequenser!!!
            personId2 = PersonSequencer.CreateNextPersonId();

            //Assert
            Assert.True(personId1 < personId2); //där kan förekomma parallella testprocessers om påverkar räknaren MEN vi vet att dessa två skapas i samma procress varav 1 ska bli < 2
        }

        [Fact]
        public void ResetPersonSequencer()
        {
            //Arrange
            int personId3 = PersonSequencer.CreateNextPersonId(); //initialt - skapa id1 som får värdet 0
            int personId4 = PersonSequencer.CreateNextPersonId(); //och id2 med värde 1

            //Act
            PersonSequencer.ResetPersonId(); //räknaren nollställs
            int personId5 = PersonSequencer.CreateNextPersonId(); //id3 blir då 0

            //Assert
            Assert.True(personId5 < personId4); //id3 skall nu vara mindre än id 2
        }

    }
}
