using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;

namespace CoreRevitLibrary.Extensions
{
    public static class DocumentExtensions
    {
        // Using Generics
        public static List<TElement> GetElementsByTypes<TElement>(this Document document)
        where TElement : Element
        {
            var elements = new FilteredElementCollector(document)
                .OfClass(typeof(TElement))
                .Cast<TElement>()
                .ToList();
            return elements;
        }
    }
}

// Generic in C# add class and methods to work with different dataTypes