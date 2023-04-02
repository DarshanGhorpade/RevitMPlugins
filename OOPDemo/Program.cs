using System;
using System.Runtime.InteropServices;

namespace OOPDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // new operator: to allocate memory to that object
            Person person1 = new Person() { FirstName = "Darshan", LastName = "Ghorpade" };
            // person1.Introduce();
            //Console.WriteLine(person1.GetFullName("+"));

            var order = new Order();

            person1.AddOrders(order);

            //var testClass = new TestClass();
            //testClass.DoSomething(person1);
            //Console.WriteLine(person1.GetFullName("+"));

            /*
             * ref & out difference
             * ref requires the varible to be created already
             * out doesn't requires the variable to be created already
             */

            //var value = 15;
            //Console.WriteLine(value);
            //testClass.DoSomething(ref value);
            //testClass.DoSomething(out var value);
            //Console.WriteLine(value);

            //var text = "10";
            //var CanBeParsed = double.TryParse(text, out var number);
            //if(CanBeParsed)
            //    Console.WriteLine(number);

            //var valuesToCalculate = new double[] { 1.5, 2.4, 1.1, 5.0};
            //Console.WriteLine(person1.Calculate(valuesToCalculate));
            //Console.WriteLine(person1.Calculate(1, 2, 3, 4));

            //Console.ReadLine();
        }
    }

    public class TestClass {
        //public void DoSomething(Person person)
        //{
        //    person.FirstName = "NewName";
        //}
        //public void DoSomething(ref int value)
        //{
        //    value = 10;
        //}
        public bool DoSomething(out int value)
        {
            value = 0;
            return true;
            //value = 10;
        }
    }
}
