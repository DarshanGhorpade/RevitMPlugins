/*
 * using Linqs
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
    public class Task1Alternative3 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var uiApplication = commandData.Application;
            var application = uiApplication.Application;
            var uiDocument = uiApplication.ActiveUIDocument;
            var document = uiDocument.Document;

            // each category in revit has its own id
            var categoryIdsToExclude = new List<ElementId>()
            {
                new ElementId(BuiltInCategory.OST_Doors),
                new ElementId(BuiltInCategory.OST_Windows)
            };

            var familyInstances = new FilteredElementCollector(document)
                .OfClass(typeof(FamilyInstance))
                .Where(f => !categoryIdsToExclude.Contains(f.Category.Id) && !f.ViewSpecific);

            var dataToVisualize = familyInstances.Select(f => $"{f.Category.Name} - {f.ViewSpecific}");
            TestWindow testWindow = new TestWindow(dataToVisualize);
            testWindow.ShowDialog();
            return Result.Succeeded;
        }
    }
}