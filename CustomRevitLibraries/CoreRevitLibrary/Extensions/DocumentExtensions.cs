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

        /// <summary>
        /// Returns the element by a given name
        /// </summary>`
        /// <typeparam name="TElement">The element type</typeparam>
        /// <param name="document">Document</param>
        /// <param name="name">The element name</param>
        /// <returns>The element</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TElement GetElementByName<TElement>(this Document document, string name)
            where TElement : Element
        {
            var element = new FilteredElementCollector(document)
                .OfClass(typeof(TElement))
                .FirstOrDefault(e => e.Name == name);
            if (element == null)
                throw new ArgumentNullException($"The element of given name : {name} is not present in the document");
            return element as TElement;
        }

        /// <summary>
        /// Return the elements by types
        /// </summary>
        /// <typeparam name="TElement1">The first element type</typeparam>
        /// <typeparam name="TElement2">The second element type</typeparam>
        /// <param name="document">Document</param>
        /// <returns>The elements</returns>
        public static List<Element> GetElementsByTypes<TElement1, TElement2>(this Document document)
            where TElement1 : Element
            where TElement2 : Element
        {
            var types = new List<Type>()
            {
                typeof(TElement1),
                typeof(TElement2)
            };
            var multiClassFilter = new ElementMulticlassFilter(types);
            return new FilteredElementCollector(document)
                .WherePasses(multiClassFilter)
                .ToList();
        }

        /// <summary>
        /// Return the elements by types
        /// </summary>
        /// <typeparam name="TElement1">The first element type</typeparam>
        /// <typeparam name="TElement2">The second element type</typeparam>
        /// <typeparam name="TElement3">The third element type</typeparam>
        /// <param name="document">Document</param>
        /// <returns>The elements</returns>
        public static List<Element> GetElementsByTypes<TElement1, TElement2, TElement3>(this Document document)
            where TElement1 : Element
            where TElement2 : Element
            where TElement3 : Element
        {
            var types = new List<Type>()
            {
                typeof(TElement1),
                typeof(TElement2),
                typeof(TElement3)
            };
            var multiClassFilter = new ElementMulticlassFilter(types);
            return new FilteredElementCollector(document)
                .WherePasses(multiClassFilter)
                .ToList();
        }

        /// <summary>
        /// Return the elements by types
        /// </summary>
        /// <typeparam name="TElement1">The first element type</typeparam>
        /// <typeparam name="TElement2">The second element type</typeparam>
        /// <typeparam name="TElement3">The third element type</typeparam>
        /// <typeparam name="TElement4">The fourth element type</typeparam>
        /// <param name="document">Document</param>
        /// <returns>The elements</returns>
        public static List<Element> GetElementsByTypes<TElement1, TElement2, TElement3, TElement4>(this Document document)
            where TElement1 : Element
            where TElement2 : Element
            where TElement3 : Element
            where TElement4 : Element
        {
            var types = new List<Type>()
            {
                typeof(TElement1),
                typeof(TElement2),
                typeof(TElement3),
                typeof(TElement4)
            };
            var multiClassFilter = new ElementMulticlassFilter(types);
            return new FilteredElementCollector(document)
                .WherePasses(multiClassFilter)
                .ToList();
        }

        /// <summary>
        /// It returns elements by types
        /// </summary>
        /// <param name="document">Document</param>
        /// <param name="types">Types</param>
        /// <returns>The elements</returns>
        public static List<Element> GetElementsByTypes(this Document document, params Type[] types)
        {
            if (!types.Any()) throw new ArgumentNullException("There are no types");
            var multiClassFilter = new ElementMulticlassFilter(types);
            return new FilteredElementCollector(document)
                .WherePasses(multiClassFilter)
                .ToList();
        }

        /// <summary>
        /// It returns elements by types
        /// </summary>
        /// <param name="document">Document</param>
        /// <param name="types">Types</param>
        /// <returns>The elements</returns>
        public static List<Element> GetElementsByTypes(this Document document, List<Type> types)
        {
            var multiClassFilter = new ElementMulticlassFilter(types);
            return new FilteredElementCollector(document)
                .WherePasses(multiClassFilter)
                .ToList();
        }
    }
}

// Generic in C# add class and methods to work with different dataTypes

// Delegate is a type that represents references to methods with a particular parameter list
// and return type. When you instantiate a delegate, you can associate its instance
// with any method with a compatible signature and return type.
// You can invoke (or call) the method through the delegate instance.