using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPDemo
{
    public class Order
    {

    }

    public class Person
    {
        //fields
        public string FirstName;
        public string LastName;

        // readonly: we can initialize at time of declaration or in constructor but not from any methods
        public readonly List<Order> Orders = new List<Order>();
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
            Orders = new List<Order>();
        }

        public Person() 
            :this("DefaultFirstName", "DefaultLastName")
        {
        }

        public void AddOrders(Order order)
        {
            Orders.Add(order);
        }

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
