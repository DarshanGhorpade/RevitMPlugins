using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace CoreRevitLibrary.Extensions
{
    /// <summary>
    /// This class is used for adding extension methods for UIDocument class, <see cref="UIDocument"/>
    /// </summary>
    public static class UIDocumentExtensions
    {
        /// <summary>
        /// It returns list of selected elements
        /// </summary>
        /// <param name="uiDocument">UIDocument</param>
        /// <returns>Selected Elements</returns>
        public static List<Element> GetSelectedElements(this UIDocument uiDocument)
        {
            return uiDocument.Selection
                .GetElementIds()
                .Select(id => uiDocument.Document.GetElement(id))
                .ToList();
        }

        public static List<Element> PickElements(this UIDocument uiDocument, Func<Element, bool> validateElement,
            IPickElementsOption pickElementsOption, string statusPrompt = "")
        {
            return pickElementsOption.PickElements(uiDocument, validateElement, statusPrompt);
        }
    }
}