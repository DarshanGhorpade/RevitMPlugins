using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;

namespace CoreRevitLibrary.Extensions
{
    /// <summary>
    /// This class is used for creating extension methods to a Document class <see cref="Document"/>
    /// </summary>
    public static class DocumentExtensions
    {
        /// <summary>
        /// It returns elements by a given type
        /// </summary>
        /// <typeparam name="TElement">The element type</typeparam>
        /// <param name="document">Document</param>
        /// <param name="validate">A delegate for validation</param>
        /// <returns>Elements</returns>
        // Using Generics
        public static List<TElement> GetElementsByTypes<TElement>(this Document document, Func<TElement, bool> validate = null)
        where TElement : Element
        {
            // checking validate null or not
            /*
                if (validate == null)
                {
                    validate = (e => true);
                }
            */
            validate = validate ?? (e => true);
            var elements = new FilteredElementCollector(document)
                .OfClass(typeof(TElement))
                .Cast<TElement>()
                .Where(e=>validate(e))
                .ToList();

            return elements;
        }
    }
}

// Generic in C# add class and methods to work with different dataTypes

// Delegate is a type that represents references to methods with a particular parameter list
// and return type. When you instantiate a delegate, you can associate its instance
// with any method with a compatible signature and return type.
// You can invoke (or call) the method through the delegate instance.