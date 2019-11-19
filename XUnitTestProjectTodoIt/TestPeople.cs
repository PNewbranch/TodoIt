using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TodoIt.Data;
using TodoIt.Model;
using System.Threading;

namespace XUnitTestProjectTodoIt
{
    public class TestPeople
    {

        [Fact]
        public void TestSize()
        {
            //Arrange
            int sizeBefore = 0;
            int sizeAfter = 0;

            //Act
            sizeBefore = People.Size();
            People.CreateANewPerson("Adan", "Adams");
            People.CreateANewPerson("Bertil", "Boo");
            People.CreateANewPerson("Carina", "Ceder");
            sizeAfter = People.Size();

            //Asset
            Assert.True(sizeAfter >= sizeBefore + 3);
        }

        [Fact]
        public void TestFindAll() 
        {
            //Arrange
            int size = 0;
            People.CreateANewPerson("David", "Duk");
            People.CreateANewPerson("Emma", "Hemma");

            //Act
            size = People.Size();                           //hämta längden från original
            Person[] testPersonArray = People.FindAll();    //skapa en lokal kopia
            
            //Asset
            Assert.True(size == testPersonArray.Length);    //jämför dem
        }

        [Fact]
        public void TestFindById() 
        {
            //Arrange
            int testId = 0;
            People.CreateANewPerson("Fia", "Flitig");                       //säkerställ att där finns personer i arrayen

            Person testPerson = People.CreateANewPerson("Emma", "Hemma");   //få tag på ett id
            testId = testPerson.PersonalId;

            People.CreateANewPerson("Gus", "Grus");                         //skapa lite mer testmaterial iiii Arrayen
            People.CreateANewPerson("Fredrik", "Frys");
      
            //Act
  
            //Asset
            Assert.Equal(testPerson, People.FindById(testId));  //hämta version från original mha id och jämför med lokal
        }

        [Fact]
        public void TestCreateANewPerson()
        {
            //Arrange
            int arrayLengthBefore = People.Size();
            int arrayLengthAfter = 0;

            //Act
            Person newPerson = People.CreateANewPerson("Rosita", "Roos"); //skapa central som kopieras(return) lokalt
            arrayLengthAfter = People.Size();

            //Asset
            Assert.True(newPerson != null && arrayLengthAfter == arrayLengthBefore + 1); //om lokal har värde om 
        }

        [Fact]
        public void TestClear() //notera TÖMMER alla boxar, tar ej bort dem
        {
            //Arrange
            People.CreateANewPerson("Harald", "Hurtig");                        
            bool stillValuesInArray = false;

            //Act
            People.Clear(); 
            Person[] copyOfArray = People.FindAll(); //skapar en array som tilldelas den hämtade arrayen - behöve INTE NEW
            foreach (var Person in copyOfArray) //det är PERSONER i den kopierade (return) versionen av arrayen
            {
                if (Person != null)
                {
                    stillValuesInArray = true;
                    break;
                }
            }

            //Asset
            Assert.True(stillValuesInArray == false);
        }

    }
}
