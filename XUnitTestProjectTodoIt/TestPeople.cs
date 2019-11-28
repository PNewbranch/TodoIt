using TodoIt.Data;
using TodoIt.Model;
using Xunit;

namespace XUnitTestProjectTodoIt
{
    public class TestPeople
    {
        public People arrayOfPersonsV1 = new People(); //Skapa en ett OBJEKT så att man INTE går mot KLASSEN (förbered för DB-koppling) 

        [Fact]
        public void TestSize()
        {
            //Arrange
            int sizeBefore = arrayOfPersonsV1.Size();
            arrayOfPersonsV1.CreateANewPerson("Adan", "Adams");
            arrayOfPersonsV1.CreateANewPerson("Carina", "Ceder");
            arrayOfPersonsV1.CreateANewPerson("Duncan", "Duva");

            //Act
            
            //Asset
            Assert.True(arrayOfPersonsV1.Size() >= sizeBefore + 3);
        }

        [Fact]
        public void TestFindAll()
        {
            //Arrange
            int size = 0;
            arrayOfPersonsV1.CreateANewPerson("David", "Duk");
            arrayOfPersonsV1.CreateANewPerson("Emma", "Hemma");
            size = arrayOfPersonsV1.Size();  //hämta längden från original      

            //Act
            Person[] testPersonArray = arrayOfPersonsV1.FindAll();    //skapa en lokal kopia

            //Asset
            Assert.True(size == testPersonArray.Length);    //jämför dem
        }

        [Fact]
        public void TestFindById()
        {
            //Arrange
            arrayOfPersonsV1.CreateANewPerson("Fia", "Flitig");
            Person testPerson = arrayOfPersonsV1.CreateANewPerson("Emma", "Hemma");   //få tag på ett id
            int testId = testPerson.PersonalId;
            arrayOfPersonsV1.CreateANewPerson("Gus", "Grus");
            arrayOfPersonsV1.CreateANewPerson("Fredrik", "Frys");

            //Act

            //Asset
            Assert.Equal(testPerson, arrayOfPersonsV1.FindById(testId));  //hämta version från original mha id och jämför med lokal
        }

        [Fact]
        public void TestCreateANewPerson()
        {
            //Arrange
            int arrayLengthBefore = arrayOfPersonsV1.Size();

            //Act
            Person newPerson = arrayOfPersonsV1.CreateANewPerson("Rosita", "Roos"); //skapa central som kopieras(return) lokalt
            int arrayLengthAfter = arrayOfPersonsV1.Size();

            //Asset
            Assert.True(newPerson != null && arrayLengthAfter == arrayLengthBefore + 1); //om lokal har värde om 
        }

        [Fact]
        public void TestClear() //notera TÖMMER alla boxar, tar ej bort dem
        {
            //Arrange
            arrayOfPersonsV1.CreateANewPerson("Harald", "Hurtig");
            bool stillValuesInArray = false;

            //Act
            arrayOfPersonsV1.Clear();
            Person[] copyOfArray = arrayOfPersonsV1.FindAll(); //skapar en array som tilldelas den hämtade arrayen - behöve INTE NEW
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

        [Fact]
        public void TestRemovePerson() //notera TÖMMER alla boxar, tar ej bort dem
        {
            //Arrange
            arrayOfPersonsV1.CreateANewPerson("Moa", "Mu");
            Person testPerson = arrayOfPersonsV1.CreateANewPerson("Noa", "No");   //få tag på ett id
            int testId = testPerson.PersonalId;
            arrayOfPersonsV1.CreateANewPerson("Orvar", "Or");

            //Act 
            arrayOfPersonsV1.RemovePerson(testId);

            //Asset
            Assert.Null(arrayOfPersonsV1.FindById(testId));
        }

    }
}
