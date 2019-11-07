using System;
using TodoIt.Model;
using System.Threading;

namespace TodoIt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            Person aPerson = new Person(1, "Lisa", "Larsson");
            Console.Write($"{aPerson.FirstName}, {aPerson.LastName}");
            System.Threading.Thread.Sleep(1000);

        }
    }
}
