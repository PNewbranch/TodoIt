﻿using TodoIt.Data;
using TodoIt.Model;
using Xunit;

namespace XUnitTestProjectTodoIt
{
    public class TestTodoItems
    {
        [Fact]
        public void TestSize()
        {
            //Arrange
            int sizeBefore = TodoItems.Size();
            TodoItems.CreateANewTodoItem("Damma", false, null);
            TodoItems.CreateANewTodoItem("Diska", false, null);
            TodoItems.CreateANewTodoItem("Laga mat", false, null);
            int sizeAfter = TodoItems.Size();

            //Act

            //Asset
            Assert.True(sizeAfter >= sizeBefore + 3);
        }

        [Fact]
        public void TestFindAll()
        {
            //Arrange
            TodoItems.CreateANewTodoItem("Byt till vinterdäck", false, null);
            TodoItems.CreateANewTodoItem("Damma", true, null);

            //Act
            int size = TodoItems.Size();
            Todo[] testTodoItemsArray = TodoItems.FindAll();

            //Asset
            Assert.True(size == testTodoItemsArray.Length);
        }

        [Fact]
        public void TestFindById()
        {
            //Arrange
            TodoItems.CreateANewTodoItem("Stryka", false, null);
            Todo testTodo = TodoItems.CreateANewTodoItem("Handla", false, null);
            int testId = testTodo.TodoId; //få tag på ett id
            TodoItems.CreateANewTodoItem("Klippa gräs", false, null);
            TodoItems.CreateANewTodoItem("Fäll träd", false, null);

            //Act

            //Asset
            Assert.Equal(testTodo, TodoItems.FindById(testId));
        }

        [Fact]
        public void TestCreateANewTodo()
        {
            //Arrange 
            int arrayLengthBefore = TodoItems.Size();
            Todo newTodo = TodoItems.CreateANewTodoItem("Baka kaka", false, null);
            int arrayLengthAfter = TodoItems.Size();

            //Act

            //Asset
            Assert.True(newTodo != null && arrayLengthAfter == arrayLengthBefore + 1);
        }

        [Fact]
        public void TestClear() //notera TÖMMER alla boxar, tar ej bort dem
        {
            //Arrange
            TodoItems.CreateANewTodoItem("Skura golvet", false, null);
            bool stillValuesInArray = false;

            //Act
            TodoItems.Clear();
            Todo[] copyOfArray = TodoItems.FindAll();
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
            TodoItems.CreateANewTodoItem("HAR klippt håret", true, testPerson1);
            TodoItems.CreateANewTodoItem("SKA klippa grannens hår", false, null);
            Person testPerson2 = new Person("Karin", "af Kort");
            TodoItems.CreateANewTodoItem("HAR kapat kostnader", true, testPerson2);
            TodoItems.CreateANewTodoItem("SKA kapa grannens fru", false, testPerson2);

            //Act
            Todo[] doneTodo = TodoItems.FindByDoneStatus(true);

            //Asset
            Assert.True(doneTodo[0].done == true); 
        }

        [Fact]
        public void TestFindByDoneStatusFalse()
        {
            //Arrange
            Person testPerson1 = new Person("Villiam", "Vilde");
            TodoItems.CreateANewTodoItem("HAR rivit uhuset", true, testPerson1);
            TodoItems.CreateANewTodoItem("SKA rivit garaget", false, null);
            Person testPerson2 = new Person("Wilma", "Weedervärdig");
            TodoItems.CreateANewTodoItem("HAR rivit grannes lekstuga", true, testPerson2);
            TodoItems.CreateANewTodoItem("SKA riva potatis", false, testPerson2);

            //Act
            Todo[] doneTodo = TodoItems.FindByDoneStatus(false);

            //Asset
            Assert.True(doneTodo[0].done == false); 
        }

        [Fact]
        public void TestFindByAssigneePersonID()
        {
            //Arrange
            Person TestPerson = new Person("Ärling", "Ärman");
            TodoItems.CreateANewTodoItem("Ärling HAR satt upp lampor", true, TestPerson);
            TodoItems.CreateANewTodoItem("Ärling SKA ta ner lampor", false, TestPerson);

            //Act
            //Todo[] assigneeTodo = TodoItems.FindByAssignee(TestPerson);
            Todo[] assigneeTodo = TodoItems.FindByAssignee(TestPerson.PersonalId);

            //Asset
            Assert.True(TestPerson == assigneeTodo[0].assignee && assigneeTodo.Length > 1); //vi skall ha minst två todo
        }

        [Fact]
        public void TestFindByAssigneePerson()
        {
            //Arrange
            Person TestPerson = new Person("Östen", "Ölman");
            TodoItems.CreateANewTodoItem("Östen HAR satt upp lampor", true, TestPerson);
            TodoItems.CreateANewTodoItem("Östen SKA ta ner lampor", false, TestPerson);

            //Act
            Todo[] assigneeTodo = TodoItems.FindByAssignee(TestPerson);

            //Asset
            Assert.True(TestPerson == assigneeTodo[0].assignee && assigneeTodo.Length > 1); //vi skall ha minst två todo
        }

        [Fact]
        public void TestRemoveTodo() //notera TÖMMER alla boxar, tar ej bort dem
        {
            //Arrange
            Person testPerson = new Person("Vera", "Velig");
            TodoItems.CreateANewTodoItem("Vera HAR diskat", true, testPerson);
            TodoItems.CreateANewTodoItem("Vera SKA damma", false, testPerson);
            Todo testTodo = TodoItems.CreateANewTodoItem("Vera HAR virkat", true, testPerson);
            int testId = testTodo.TodoId; //remove this
            TodoItems.CreateANewTodoItem("Vera Har dammsugit", false, testPerson);

            //Act 
            TodoItems.RemoveTodo(testId);

            //Asset
            Assert.Null(TodoItems.FindById(testId));
        }

    }
}
