using System.Linq;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using CoreRevitLibrary.Extensions;

namespace CoreRevitLibrary.TestCommands
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    class SelectionCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var uiApplication = commandData.Application;
            var application = uiApplication.Application;
            var uiDocument = uiApplication.ActiveUIDocument;
            var document = uiDocument.Document;

            // Using Extension method
            var walls = document.GetElementsByTypes<Wall>();

            /*
            var collector = new FilteredElementCollector(document)
                .OfCategory(BuiltInCategory.OST_Walls)
                .WhereElementIsNotElementType();
            */
            /*
            var collector = new FilteredElementCollector(document)
                .OfClass(typeof(FloorType));
            */
            /*
             * ElementClassFilter
             */
            var wallFilter = new ElementClassFilter(typeof(Wall));
            var familyInstanceFilter = new ElementClassFilter(typeof(FamilyInstance));
            /*
             * LogicalORFilter
             */
            LogicalOrFilter logicalOrFilter = new LogicalOrFilter(wallFilter, familyInstanceFilter);
            var collector = new FilteredElementCollector(document)
                .WherePasses(logicalOrFilter);

            //TaskDialog.Show("Message", collector.Count.ToString());
            TestWindow testWindow = new TestWindow(collector);
            testWindow.ShowDialog();
            return Result.Succeeded;
        }
    }
}
