using System;
using TodoIt.Model;
using Xunit;

namespace XUnitTestProjectTodoIt
{
    public class TestPerson
    {
        [Fact]
        public void TestCreatePersonOK() //test constructor
        {
            //Arrange
            Person testPerson = new Person("Agda", "Analgam");

            //Act

            //Asset
            Assert.NotNull(testPerson); //verifiera att testpersonen skapats
        }


        [Fact]
        public void TestFirstNameOK()
        {
            //Arrange
            Person testPerson = null; //måste definieras eftersom den inte alltid skapas - används vid slutkontroll
            string excpectedMsg = "Förnamn måste anges.";
            string errorMsg = ""; //Variabel för att fånga upp felmeddelande från min klass

            //Act
            try
            {
                testPerson = new Person("", "Berg");
            }
            catch (Exception exception)
            {
                errorMsg = exception.Message;
            }

            //Asset
            Assert.Null(testPerson);
            Assert.Equal(excpectedMsg, errorMsg);
        }

        [Fact]
        public void TestLastNameNotOK()
        {
            //Arrange
            Person testPerson = null;
            string excpectedMsg = "Efternamn måste anges.";
            string errorMsg = "";

            //Act
            try
            {
                testPerson = new Person("Cesar", "");
            }
            catch (Exception exception)
            {
                errorMsg = exception.Message;
            }

            //Asset
            Assert.Null(testPerson);
            Assert.Equal(excpectedMsg, errorMsg);
        }

    }
}
