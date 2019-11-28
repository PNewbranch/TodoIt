using TodoIt.Data;
using TodoIt.Model;
using Xunit;

namespace XUnitTestProjectTodoIt
{
    public class TestTodoItems
    {
        TodoItems arrayOfItemsV1 = new TodoItems(); //Skapa en ett OBJEKT så att man INTE går mot KLASSEN (förbered för DB-koppling)

        [Fact]
        public void TestSize()
        {
            //Arrange
            int sizeBefore = arrayOfItemsV1.Size();
            arrayOfItemsV1.CreateANewTodoItem("Damma", false, null);
            arrayOfItemsV1.CreateANewTodoItem("Diska", false, null);
            arrayOfItemsV1.CreateANewTodoItem("Laga mat", false, null);
            int sizeAfter = arrayOfItemsV1.Size();

            //Act

            //Asset
            Assert.True(sizeAfter >= sizeBefore + 3);
        }

        [Fact]
        public void TestFindAll()
        {
            //Arrange
            arrayOfItemsV1.CreateANewTodoItem("Byt till vinterdäck", false, null);
            arrayOfItemsV1.CreateANewTodoItem("Damma", true, null);

            //Act
            int size = arrayOfItemsV1.Size();
            Todo[] testTodoItemsArray = arrayOfItemsV1.FindAll();

            //Asset
            Assert.True(size == testTodoItemsArray.Length);
        }

        [Fact]
        public void TestFindById()
        {
            //Arrange
            arrayOfItemsV1.CreateANewTodoItem("Stryka", false, null);
            Todo testTodo = arrayOfItemsV1.CreateANewTodoItem("Handla", false, null);
            int testId = testTodo.TodoId; //få tag på ett id
            arrayOfItemsV1.CreateANewTodoItem("Klippa gräs", false, null);
            arrayOfItemsV1.CreateANewTodoItem("Fäll träd", false, null);

            //Act

            //Asset
            Assert.Equal(testTodo, arrayOfItemsV1.FindById(testId));
        }

        [Fact]
        public void TestCreateANewTodo()
        {
            //Arrange 
            int arrayLengthBefore = arrayOfItemsV1.Size();
            Todo newTodo = arrayOfItemsV1.CreateANewTodoItem("Baka kaka", false, null);
            int arrayLengthAfter = arrayOfItemsV1.Size();

            //Act

            //Asset
            Assert.True(newTodo != null && arrayLengthAfter == arrayLengthBefore + 1);
        }

        [Fact]
        public void TestClear() //notera TÖMMER alla boxar, tar ej bort dem
        {
            //Arrange
            arrayOfItemsV1.CreateANewTodoItem("Skura golvet", false, null);
            bool stillValuesInArray = false;

            //Act
            arrayOfItemsV1.Clear();
            Todo[] copyOfArray = arrayOfItemsV1.FindAll();
            foreach (var Todo in copyOfArray)
            {
                if (Todo != null)
                {
                    stillValuesInArray = true;
                    break;
                }
            }

            //Asset
            Assert.True(stillValuesInArray == false);
        }

        [Fact]
        public void TestFindByDoneStatusTrue()
        {
            //Arrange
            Person testPerson1 = new Person("Lena", "af Lång");
            arrayOfItemsV1.CreateANewTodoItem("HAR klippt håret", true, testPerson1);
            arrayOfItemsV1.CreateANewTodoItem("SKA klippa grannens hår", false, null);
            Person testPerson2 = new Person("Karin", "af Kort");
            arrayOfItemsV1.CreateANewTodoItem("HAR kapat kostnader", true, testPerson2);
            arrayOfItemsV1.CreateANewTodoItem("SKA kapa grannens fru", false, testPerson2);

            //Act
            Todo[] doneTodo = arrayOfItemsV1.FindByStatus(true);

            //Asset
            Assert.True(doneTodo[0].done == true); 
        }

        [Fact]
        public void TestFindByDoneStatusFalse()
        {
            //Arrange
            Person testPerson1 = new Person("Villiam", "Vilde");
            arrayOfItemsV1.CreateANewTodoItem("HAR rivit uhuset", true, testPerson1);
            arrayOfItemsV1.CreateANewTodoItem("SKA rivit garaget", false, null);
            Person testPerson2 = new Person("Wilma", "Weedervärdig");
            arrayOfItemsV1.CreateANewTodoItem("HAR rivit grannes lekstuga", true, testPerson2);
            arrayOfItemsV1.CreateANewTodoItem("SKA riva potatis", false, testPerson2);

            //Act
            Todo[] doneTodo = arrayOfItemsV1.FindByStatus(false);

            //Asset
            Assert.True(doneTodo[0].done == false); 
        }

        [Fact]
        public void TestFindByAssigneePersonID()
        {
            //Arrange
            Person TestPerson = new Person("Ärling", "Ärman");
            arrayOfItemsV1.CreateANewTodoItem("Ärling HAR satt upp lampor", true, TestPerson);
            arrayOfItemsV1.CreateANewTodoItem("Ärling SKA ta ner lampor", false, TestPerson);

            //Act
            //Todo[] assigneeTodo = TodoItems.FindByAssignee(TestPerson);
            Todo[] assigneeTodo = arrayOfItemsV1.FindByAssignee(TestPerson.PersonalId);

            //Asset
            Assert.True(TestPerson == assigneeTodo[0].assignee && assigneeTodo.Length > 1); //vi skall ha minst två todo
        }

        [Fact]
        public void TestFindByAssigneePerson()
        {
            //Arrange
            Person TestPerson = new Person("Östen", "Ölman");
            arrayOfItemsV1.CreateANewTodoItem("Östen HAR satt upp lampor", true, TestPerson);
            arrayOfItemsV1.CreateANewTodoItem("Östen SKA ta ner lampor", false, TestPerson);

            //Act
            Todo[] assigneeTodo = arrayOfItemsV1.FindByAssignee(TestPerson);

            //Asset
            Assert.True(TestPerson == assigneeTodo[0].assignee && assigneeTodo.Length > 1); //vi skall ha minst två todo
        }

        [Fact]
        public void TestFindUnassignedTodoItems()
        {
            //Arrange
            Person TestPerson1 = new Person("Maaarit", "Mögh");
            arrayOfItemsV1.CreateANewTodoItem("Maarit har inte gjort sitt jobb än", false, TestPerson1);
            arrayOfItemsV1.CreateANewTodoItem("INGEN har fått jobbet att öppna vinflaskan än", false, null);    //detta ger minst 1 träff
            arrayOfItemsV1.CreateANewTodoItem("INGEN har fått jobbet att öppna mjölken än", false, null);       //detta ger minst 2 träff
            Person TestPerson2 = new Person("Iris", "Irrig");
            arrayOfItemsV1.CreateANewTodoItem("Iris HAR satt upp tavlor", true, TestPerson2);

            //Act
            Todo[] assigneeTodo = arrayOfItemsV1.FindUnassignedTodoItems();

            //Asset
            Assert.True(null == assigneeTodo[0].assignee && assigneeTodo.Length > 1); //vi skall ha minst två todo
        }

        [Fact]
        public void TestRemoveTodo() //notera TÖMMER alla boxar, tar ej bort dem
        {
            //Arrange
            Person testPerson = new Person("Vera", "Velig");
            arrayOfItemsV1.CreateANewTodoItem("Vera HAR diskat", true, testPerson);
            arrayOfItemsV1.CreateANewTodoItem("Vera SKA damma", false, testPerson);
            Todo testTodo = arrayOfItemsV1.CreateANewTodoItem("Vera HAR virkat", true, testPerson);
            int testId = testTodo.TodoId; //remove this
            arrayOfItemsV1.CreateANewTodoItem("Vera Har dammsugit", false, testPerson);

            //Act 
            arrayOfItemsV1.RemoveTodo(testId);

            //Asset
            Assert.Null(arrayOfItemsV1.FindById(testId));
        }

    }
}
