using System;

namespace OOPsDemo
{
    public class Human
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public Human(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public void Sleep()
        {
            Console.WriteLine("I am Sleeping.");
        }

        public virtual void Walk()
        {
            Console.WriteLine("I am Walking.");
        }
    }

    public class Pilot : Human
    {
        public Rank Rank { get; set; }
        public double Salary { get; set; }

        public void DetermineSafestRoute()
        {
            Console.WriteLine("Determining the safest route....");
        }

        public override void Walk()
        {
            Console.WriteLine("Pilot is Walking");
        }

        public Pilot(string firstName, string lastName, int age, Rank rank, double salary)
            : base(firstName, lastName, age)
        {
            Rank = rank;
            Salary = salary;
        }
    }

    public class Architect : Human
    {
        public Architect(string firstName, string lastName, int age)
            : base(firstName, lastName, age)
        {
        }

        public void Design()
        {
            Console.WriteLine("Designing...");
        }
    }

    public enum Rank
    {
        Trainee,
        FlightOfficer
    }

    internal class DownCast_UpCastDemo
    {
        static void Main(string[] args)
        {
            var pilot = new Pilot("John", "Wick", 24, Rank.FlightOfficer, 2000);
            var human = pilot;
            human.FirstName = "John";
            Console.WriteLine(pilot.FirstName);
            Console.ReadLine();
        }
    }
}