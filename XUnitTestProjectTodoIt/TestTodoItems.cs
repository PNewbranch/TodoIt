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
            TodoItems.CreateANewTodoItem("Damma");
            TodoItems.CreateANewTodoItem("Diska");
            TodoItems.CreateANewTodoItem("Laga mat");
            sizeAfter = TodoItems.Size();

            //Asset
            Assert.True(sizeAfter >= sizeBefore + 3);
        }

        [Fact]
        public void TestFindAll()
        {
            //Arrange
            int size = 0;
            TodoItems.CreateANewTodoItem("Byt till vinterdäck");
            TodoItems.CreateANewTodoItem("Damma");

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
            TodoItems.CreateANewTodoItem("Stryka");

            Todo testTodo = TodoItems.CreateANewTodoItem("Handla"); //få tag på ett id
            testId = testTodo.TodoId;

            TodoItems.CreateANewTodoItem("Klippa gräs");
            TodoItems.CreateANewTodoItem("Fäll träd");

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
            Todo newTodo = TodoItems.CreateANewTodoItem("Baka kaka");
            arrayLengthAfter = TodoItems.Size();

            //Asset
            Assert.True(newTodo != null && arrayLengthAfter == arrayLengthBefore + 1); 
        }

        [Fact]
        public void TestClear() //notera TÖMMER alla boxar, tar ej bort dem
        {
            //Arrange
            TodoItems.CreateANewTodoItem("Skura golvet");
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

    }
}
