using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPDemo
{
    public class Person
    {
        //fields
        public string FirstName;
        public string LastName;
        //ctor: shortcut for constructor
        // constructor: to do some actions at the time of instantiation of the class


        public Person(string firstName)
        {
            this.FirstName = firstName;
        }

        public Person(string firstName, string lastName)
            :this(firstName)
        {
            this.LastName = lastName;
        }

        public Person() 
            :this("DefaultFirstName", "DefaultLastName")
        { }

        public void Introduce()
        {
            Console.WriteLine(FirstName);
        }

        public string GetFullName()
        {
            var fullName = $"{FirstName}_{LastName}";   // string interpolation
            return fullName ;
        }

        public string GetFullName(string separator)
        {
            var fullName = $"{FirstName}{separator}{LastName}";   // string interpolation
            return fullName;
        }

        public double Calculate(params double[] values)
        {
            var sum = values.Sum();
            return sum;
        }
    }
}
