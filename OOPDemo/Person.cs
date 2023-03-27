using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo
{
    public class Person
    {
        //fields
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //ctor: shortcut for constructor
        // constructor: to do some actions at the time of instantiation of the class
        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = LastName;
        }

        public void Introduce()
        {
            Console.WriteLine(FirstName + " " + LastName);
        }
    }
}
