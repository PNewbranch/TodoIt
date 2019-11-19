using System;
using Xunit;
using TodoIt.Model;

namespace XUnitTestProjectTodoIt
{
    public class TestPerson
    {

        [Fact]
        public void TestCreatePersonOK() //test constructor
        {
            //Arrange
            Person testPerson = new Person(1, "Agda", "Analgam"); 

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
                testPerson = new Person(2, "", "Berg");
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
                testPerson = new Person(3, "Cesar", "");
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
