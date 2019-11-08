using System;
using Xunit;
using TodoIt.Model; //om förlag ej ges så har men ej satt ställt in att textprojektet har dependencies på det program man testar (i dett fall TodoIt)


namespace XUnitTestProjectTodoIt
{
    public class UnitTest1
    {

        [Fact]
        public void CreatePersonOK() //Person testPerson = new Person(personalId, firsName, lastName); //testar att skaoa med hårdkodade inparameterar
        {
            //Arrange
            int personalId = 1;
            string firsName = "Lisa";
            string lastName = "Larsson";

            //Act
            Person testPerson = new Person(personalId, firsName, lastName);

            //Asset
            Assert.NotNull(testPerson); //verifiera att testpersonen skapats
        }

        //[Fact]
        //public void PersonalIdfGetOK() //Vi vet redan att detta funker genom test ovan

        //[Fact]
        //public void PersonalIdfSetNotAllowedOK() //Detta går inte att testa då man SKALL få kompileringsfel (private)

        [Fact]
        public void CreatePersonFirstNameNotOK()
        {
            //Arrange
            int personalId = 1;
            string firsName = ""; //genererat fel, måste alltid tilldelas
            string lastName = "Larsson";
            //Tillkommande variabler för att kunna testa
            Person testPerson = null;                       //Vi skapar ett objekt här för att sedan säkerställa att vi INTE skapt något ??Varför
            string excpectedMsg = "Förnamn måste anges.";   //Förväntat felmeddelande min class skall ge  
            string errorMsg = "";                           //Variabel för att fånga upp felmeddelande från min klass

            //Act
            try
            {
                testPerson = new Person(personalId, firsName, lastName);
            }
            catch (Exception exception)
            {
                errorMsg = exception.Message;
            }
            
            //Asset
            Assert.Null(testPerson);                        //Välj relevanta Assert-kontroller
            Assert.Equal(excpectedMsg, errorMsg);
        }

        [Fact]
        public void CreatePersonLastNameNotOK()
        {
            //Arrange
            int personalId = 1;
            string firsName = "Lisa"; //genererat fel, måste alltid tilldelas
            string lastName = "";
            //Tillkommande variabler för att kunna testa
            Person testPerson = null;                       //Vi skapar ett objekt här för att sedan säkerställa att vi INTE skapt något ??Varför
            string excpectedMsg = "Efternamn måste anges.";   //Förväntat felmeddelande min class skall ge  
            string errorMsg = "";                           //Variabel för att fånga upp felmeddelande från min klass

            //Act
            try
            {
                testPerson = new Person(personalId, firsName, lastName);
            }
            catch (Exception exception)
            {
                errorMsg = exception.Message;
            }

            //Asset
            Assert.Null(testPerson);                        //Välj relevanta Assert-kontroller
            Assert.Equal(excpectedMsg, errorMsg);
        }


    }
}
