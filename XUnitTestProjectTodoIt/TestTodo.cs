using System;
using Xunit;
using TodoIt.Model;
//using System.Collections.Generic;
//using System.Text;

namespace XUnitTestProjectTodoIt
{
    public class TestTodo
    {

        [Fact]
        public void CreateTodoOK() //
        {
            //Arrange
            int todoId = 1;
            string description = "textmassa";
            bool done = false;                                            //dessa behövs inte här                                
            Person assignee = new Person(1, "Kalle", "Kula");

            ////Act
            Todo testTodo = new Todo(todoId, description, done, assignee); //Construktorn har bara två av fälten som inparametrar

            //Asset
            Assert.NotNull(testTodo); //verifiera att testpersonen skapat
        }


    }
}
