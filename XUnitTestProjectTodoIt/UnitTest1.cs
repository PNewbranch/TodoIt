using System;
using Xunit;
using TodoIt.Model; //om förlag ej ges så har men ej satt ställt in att textprojektet har dependencies på det program man testar (i dett fall TodoIt)


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
            Person testPerson = new Person(personalId, firsName, lastName); //testar att skaoa med hårdkodade inparameterar

            //Asset
            Assert.NotNull(testPerson); //verifiera att testpersonen skapats
        }
    }
}
