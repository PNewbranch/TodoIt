using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TodoIt.Data;
using TodoIt.Model;
using System.Threading;

namespace XUnitTestProjectTodoIt
{
    public class TestTodoItems
    {

        [Fact]
        public void TestSize()
        {
            //Arrange
            int sizeBefore = 0;
            int sizeAfter = 0;

            //Act
            sizeBefore = TodoItems.Size();
            TodoItems.CreateANewTodoItem("Damma", false, null);
            TodoItems.CreateANewTodoItem("Diska", false, null);
            TodoItems.CreateANewTodoItem("Laga mat", false, null);
            sizeAfter = TodoItems.Size();

            //Asset
            Assert.True(sizeAfter >= sizeBefore + 3);
        }

        [Fact]
        public void TestFindAll()
        {
            //Arrange
            int size = 0;
            TodoItems.CreateANewTodoItem("Byt till vinterdäck", false, null);
            TodoItems.CreateANewTodoItem("Damma", true, null);

            //Act
            size = TodoItems.Size();                           
            Todo[] testTodoItemsArray = TodoItems.FindAll(); 

            //Asset
            Assert.True(size == testTodoItemsArray.Length);    
        }

        [Fact]
        public void TestFindById()
        {
            //Arrange
            int testId = 0;
            TodoItems.CreateANewTodoItem("Stryka", false, null);

            Todo testTodo = TodoItems.CreateANewTodoItem("Handla", false, null); //få tag på ett id
            testId = testTodo.TodoId;

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
            int arrayLengthAfter = 0;

            //Act
            Todo newTodo = TodoItems.CreateANewTodoItem("Baka kaka", false, null);
            arrayLengthAfter = TodoItems.Size();

            //Asset
            Assert.True(newTodo != null && arrayLengthAfter == arrayLengthBefore + 1); 
        }

        //[Fact]
        //public void TestClear() //notera TÖMMER alla boxar, tar ej bort dem
        //{
        //    //Arrange
        //    TodoItems.CreateANewTodoItem("Skura golvet", false, null);
        //    bool stillValuesInArray = false;

        //    //Act
        //    TodoItems.Clear();
        //    Todo[] copyOfArray = TodoItems.FindAll(); 
        //    foreach (var Todo in copyOfArray) 
        //    {
        //        if (Todo != null)
        //        {
        //            stillValuesInArray = true;
        //            break;
        //        }
        //    }

        //    //Asset
        //    Assert.True(stillValuesInArray == false);
        //}

        [Fact]
        public void TestFindByDoneStatus() 
        {
            //Arrange
            int personId1 = PersonSequencer.CreateNextPersonId();
            Person TestPerson1 = new Person(personId1, "Villiam", "Vilde");
            int todoId1 = TodoSequencer.CreateNextTodoId();
            TodoItems.CreateANewTodoItem("HAR Rivit uhuset", true, TestPerson1);

            int personId2 = PersonSequencer.CreateNextPersonId();
            Person TestPerson2 = new Person(personId2, "Wilma", "Weedervärdig");
            int todoId2 = TodoSequencer.CreateNextTodoId();
            TodoItems.CreateANewTodoItem("HAR Rivit garaget", true, null);

            Todo[] doneTodo = TodoItems.FindByDoneStatus();

            //Asset
            Assert.True(doneTodo.Length > 1);
        }


    }
}
