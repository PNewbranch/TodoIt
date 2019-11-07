using System;
using Xunit;
using TodoIt.Model; //om f�rlag ej ges s� har men ej satt st�llt in att textprojektet har dependencies p� det program man testar (i dett fall TodoIt)


namespace XUnitTestProjectTodoIt
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            int personalId = 1;
            string firsName = "Lisa";
            string lastName = "Larsson";

            //Act
            Person testPerson = new Person(personalId, firsName, lastName); //testar att skaoa med h�rdkodade inparameterar

            //Asset
            Assert.NotNull(testPerson); //verifiera att testpersonen skapats
        }
    }
}
