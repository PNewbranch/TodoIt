using System;
using Xunit;
using TodoIt.Model;

namespace XUnitTestProjectTodoIt
{
    public class TestPerson
    {

        [Fact]
        public void CreatePersonOK() //Person testPerson = new Person(personalId, firsName, lastName); //testar att skaoa med h�rdkodade inparameterar
        {
            //Arrange
            int personalId = 1;
            string firsName = "Lisa";
            string lastName = "Larsson";

            //Act
            Person testPerson = new Person(personalId, firsName, lastName); //using TodoIt.Model �verst inneb�r att vi skulle kunna ta bort det p� denna rad

            //Asset
            Assert.NotNull(testPerson); //verifiera att testpersonen skapats

        }



        //[Fact]
        //public void PersonalIdfGetOK() //Vi vet redan att detta funker genom test ovan

        //[Fact]
        //public void PersonalIdfSetNotAllowedOK() //Detta g�r inte att testa d� man SKALL f� kompileringsfel (private)



        [Fact]
        public void CreatePersonFirstNameNotOK()
        {
            //Arrange
            int personalId = 1;
            string firsName = ""; //genererat fel, m�ste alltid tilldelas
            string lastName = "Larsson";
            //Tillkommande variabler f�r att kunna testa
            Person testPerson = null;                       //Vi skapar ett tomt null-objekt - sedan k�r vi en "new Person" p� den - beh�ver vi verkligen detta steg?
            string excpectedMsg = "F�rnamn m�ste anges.";   //F�rv�ntat felmeddelande min class skall ge  
            string errorMsg = "";                           //Variabel f�r att f�nga upp felmeddelande fr�n min klass

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
            Assert.Null(testPerson);                        //V�lj relevanta Assert-kontroller
            Assert.Equal(excpectedMsg, errorMsg);
        }

        [Fact]
        public void CreatePersonLastNameNotOK()
        {
            //Arrange
            int personalId = 1;
            string firsName = "Lisa"; 
            string lastName = ""; //genererat fel, m�ste alltid tilldelas
            //Tillkommande variabler f�r att kunna testa
            Person testPerson = null;                         //Vi skapar ett tomt objekt h�r f�r att sedan s�kerst�lla att vi INTE skapt n�got ??Varf�r
            string excpectedMsg = "Efternamn m�ste anges.";   //F�rv�ntat felmeddelande min class skall ge  
            string errorMsg = "";                             //Variabel f�r att f�nga upp felmeddelande fr�n min klass

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
            Assert.Null(testPerson);                        //V�lj relevanta Assert-kontroller
            Assert.Equal(excpectedMsg, errorMsg);
        }

    }
}
