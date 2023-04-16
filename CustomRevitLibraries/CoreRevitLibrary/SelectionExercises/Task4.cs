/*
 * Select element that are dependent on given view id
 */

using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using CoreRevitLibrary.TestCommands;

namespace CoreRevitLibrary.SelectionExercises
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Task4:IExternalCommand 
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var uiApplication = commandData.Application;
            var application = uiApplication.Application;
            var uiDocument = uiApplication.ActiveUIDocument;
            var document = uiDocument.Document;

            var ids = new List<int>() { 312, 695 };

            var viewIds = ids
                .Select(id => new ElementId(id))
                .ToList();

            // using Linq
            var components = viewIds
                .SelectMany(id => new FilteredElementCollector(document, id).OfClass(typeof(FamilyInstance)).OwnedByView(id))
                .ToList();
            // using foreach
            /*
            List<Element> components = new List<Element>();
            foreach (var elementId in viewIds)
            {
                var collector = new FilteredElementCollector(document, elementId).OfClass(typeof(FamilyInstance)).OwnedByView(elementId);
            }
            */

            var answer = components.Max(e => e.Id.IntegerValue);

            TaskDialog.Show("Message", $"The answer is {answer}");
            TestWindow testWindow = new TestWindow(components.Select(c => c.Id));
            testWindow.ShowDialog();
            return Result.Succeeded;
        }
    }
}