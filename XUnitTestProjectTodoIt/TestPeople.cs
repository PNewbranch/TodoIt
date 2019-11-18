﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TodoIt.Data;
using TodoIt.Model;

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
            People.CreateANewPerson("Adan", "Adams");              //anrop till metod som skaper ny person som läggs in sist i en nyskapad array
            People.CreateANewPerson("Bertil", "Boo");
            People.CreateANewPerson("Carina", "Ceder");
            //Person testguy = CreateANewPerson("kalle", "kobra"); //skapar en LOKAL person här INTE I ARRAYEN
            sizeAfter = People.Size();

            //Asset
            Assert.True(sizeAfter >= sizeBefore + 3);
        }

        [Fact]
        public void TestFindAllPersons()  //NÄR FLERA TESTER MANIPULERAR MED SAMMA OBJEKT(ARRAY) SÅ LÅSER VARJE TEST ARRAYEN UNDER SIN EXEKVERING
        {
            //Arrange
            int size = 0;
            People.CreateANewPerson("David", "Duk");                    //säkerställ att där finns personer i arrayen
            People.CreateANewPerson("Emma", "Hemma");

            //Act
            size = People.Size();
            Person[] testPersonArray = new Person[size];
            testPersonArray = People.FindAll();

            //Asset
            Assert.True(testPersonArray[size-1].FirstName == "Emma");    //kolla att arrayen är hämtad genom att se om Emma finns där 
        }

        [Fact]
        public void TestFindById() 
        {
            //Arrange
            int testId = 0;
            People.CreateANewPerson("Fia", "Flitg");                        //säkerställ att där finns personer i arrayen

            Person testPerson = People.CreateANewPerson("Emma", "Hemma");  //få tag på ett id
            testId = testPerson.PersonalId;

            People.CreateANewPerson("Gus", "Grus");                         //skapa lite mer testmaterial iiii Arrayen
            People.CreateANewPerson("Fredrik", "Frys");
      
            //Act
  
            //Asset
            Assert.Equal(testPerson, People.FindById(testId));                  
        }

        [Fact]
        public void TestClear()
        {
            //Arrange
            People.CreateANewPerson("Harald", "Hurtig");                        //säkerställ att där finns personer i arrayen

            //Act
            People.Clear();
            People.FindById(0);



            //Asset
            Assert.Empty(Person);
        }

    }
}
