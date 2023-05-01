/*
 * Task: Select all Element of type familyInstance
 * and get the ones that are owned by that view
 * and show sum of all the ids of the elements that you get
 */

using System.Linq;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using CoreRevitLibrary.TestCommands;

namespace CoreRevitLibrary.SelectionExercises
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Task2 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var uiApplication = commandData.Application;
            var application = uiApplication.Application;
            var uiDocument = uiApplication.ActiveUIDocument;
            var document = uiDocument.Document;
            ElementId activeViewId = document.ActiveView.Id;
            var collector = new FilteredElementCollector(document)
                .OfClass(typeof(FamilyInstance))
                .OwnedByView(activeViewId);

            var answer = collector.Sum(e => e.Id.IntegerValue);
            TaskDialog.Show("Message", $"The sum is {answer}");

            var dataToVisualize = collector.Select(f => $"{f.Category.Name} - {f.ViewSpecific}");
            TestWindow testWindow = new TestWindow(dataToVisualize);
            testWindow.ShowDialog();

            return Result.Succeeded;
        }
    }
}