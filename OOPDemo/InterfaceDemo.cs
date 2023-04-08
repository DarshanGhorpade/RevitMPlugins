using System;
using System.Collections.Generic;

namespace OOPsDemo
{
    public class Circle : IShape
    {
        public bool IsVisible { get; set; }
        public void Draw()
        {
            Console.WriteLine("Drawing a circle");
        }
    }

    public class Rectangle : IShape
    {
        public bool IsVisible { get; set; }
        public void Draw()
        {
            Console.WriteLine("Drawing a rectangle");
        }
    }

    public class Canvas
    {
        public void DrawShapes(List<IShape> shapes)
        {
            foreach (var shape in shapes)
            {
                shape.Draw();
            }
        }
    }

    internal class InterfaceDemo
    {
        static void Main(string[] args)
        {
            var canvas = new Canvas();
            var shapes = new List<IShape>
            {
                new Circle(),
                new Rectangle()
            };
            canvas.DrawShapes(shapes);
            Console.ReadLine();
        }
    }
}
