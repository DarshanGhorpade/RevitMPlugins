using System;
using System.Collections.Generic;

namespace OOPsDemo
{
    public enum ElementType
    {
        Wall,
        Floor,
        Roof
    }

    public class Element
    {
        public ElementType Type { get; set; }
    }

    public class Document
    {
        public void ModelElements(List<Element> elements)
        {
            foreach (var element in elements)
            {
                if(element.Type == ElementType.Wall)
                    Console.WriteLine("Modeling a wall");
                else if(element.Type == ElementType.Floor)
                    Console.WriteLine("Modeling a floor");
                else if(element.Type == ElementType.Roof)
                    Console.WriteLine("Modeling a roof");
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
                new Element { Type = ElementType.Wall },
                new Element { Type = ElementType.Floor },
                new Element { Type = ElementType.Roof }
            };
            document.ModelElements(elements);
            Console.ReadLine();
        }
    }
}
