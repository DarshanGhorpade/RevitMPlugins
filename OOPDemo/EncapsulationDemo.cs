using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsDemo
{
    internal class EncapsulationDemo
    {
        static void Main(string[] args)
        {
            var point1 = new Point(5, 5);
            var point2 = new Point(10, 10);
            Console.WriteLine(point1.GetDistanceTo(point2));

            Player player = new Player();
            player.SetHealth(110);
            Console.WriteLine(player.GetHealth());

            Console.ReadLine();
        }
    }

    public class Point
    {
        public double X;
        public double Y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double GetDistanceTo(Point otherPoint)
        {
            double dx = this.X - otherPoint.X;
            double dy = this.Y - otherPoint.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }

    public class Player
    {
        private double _health;

        public void SetHealth(double health) { 
            if(_health < 0)
            {
                _health = 0;
            }
            else if(health > 100) { 
                _health = 100;
            }
            else
            {
                _health = health;
            }
        }

        public double GetHealth()
        {
            return _health;
        } 
    }
}
