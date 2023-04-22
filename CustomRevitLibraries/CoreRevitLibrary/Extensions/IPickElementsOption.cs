using System;
using System.Collections.Generic;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;

namespace CoreRevitLibrary.Extensions
{
    public interface IPickElementsOption
    {
        List<Element> PickElements(UIDocument uiDocument, Func<Element, bool> validateElement,
            string statusPrompt);
    }
}