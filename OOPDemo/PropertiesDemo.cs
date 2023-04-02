using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsDemo
{
    internal class PropertiesDemo
    {
        static void Main(string[] args)
        {
            Human human = new Human();
            human.Age = 15;
            var age = human.Age;
            Console.WriteLine(age);
            human.Health = -200;
            var health = human.Health;
            Console.WriteLine(health);
            Console.ReadLine();
        }
    }

    public class Human
    {
        public int Age { get; set; }

        private int _health;
        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                if (value < 0)
                    _health = 0;
                else if(value > 100)
                    _health = 100;
                else
                    _health = value;
            }
        }
    }
}
