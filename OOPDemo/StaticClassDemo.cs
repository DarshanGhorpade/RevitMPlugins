/*
 * some common actions related to your part of work
 */

using System;

namespace OOPsDemo
{
    internal class StaticClassDemo
    {
        static void Main(string[] args)
        {
            var value = Calculator.Add(5.5,4.5);
            Console.WriteLine(value);
            Calculator.value = value + 5;
            Console.WriteLine(value);
            Console.ReadLine();

            SimpleClass class1 = new SimpleClass();
            SimpleClass class2 = new SimpleClass();
        }

    }

    // static class
    public static class Calculator
    {
        // static field
        public static double value;

        // static method
        public static double Add(double value1, double value2)
        {
            return value1 + value2;
        }
    }

    public class SimpleClass
    {
        public static double value;

        // static constructor only called once
        static SimpleClass()
        {
            value = 5;
        }

        // simple constructor called when new instance is created
        public SimpleClass()
        {
            
        }
    }
}