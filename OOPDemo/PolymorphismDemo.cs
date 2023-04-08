using System;
using System.Collections.Generic;
using System.Net.Configuration;

namespace OOPsDemo
{
    public abstract class Element
    {
        // derived class can override this method and provide its own implementation
        public string Name { get; set; }
        public int Id { get; set; }
        public void Place()
        {
            Console.WriteLine("Placing an element");
        }
        public abstract void Model();
    }

    public class Wall : Element
    {
        public override void Model()
        {
            Console.WriteLine("Modeling a wall");
        }
    }

    public class Floor : Element
    {
        public override void Model()
        {
            Console.WriteLine("Modeling a floor");
        }
    }

    public class Roof : Element
    {
        public override void Model()
        {
            Console.WriteLine("Modeling a roof");
        }
    }

    public class Table : Element
    {
        public override void Model()
        {
            Console.WriteLine("Modeling a table");
        }
    }

    public class Document
    {
        public void ModelElements(List<Element> elements)
        {
            foreach (var element in elements)
            {
                element.Model();
            }
        }
    }

    internal class PolymorphismDemo
    {
        public static void Main(string[] args)
        {
            var document = new Document();
            var elements = new List<Element>
            {
                new Wall(),
                new Floor(),
                new Roof(),
                new Table()
            };
            document.ModelElements(elements);
            Console.ReadLine();
        }
    }
}