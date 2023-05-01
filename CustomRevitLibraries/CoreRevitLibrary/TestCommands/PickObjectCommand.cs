using System.Linq;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace CoreRevitLibrary.TestCommands
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class PickObjectCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var uiApplication = commandData.Application;
            var application = uiApplication.Application;
            var uiDocument = uiApplication.ActiveUIDocument;
            var document = uiDocument.Document;

            var references = uiDocument.Selection
                .PickObjects(
                    ObjectType.Element,
                    new ElementSelectionFilter(e => e is Wall),
                    "Please select walls");
            var components = references.Select(r => document.GetElement(r)).ToList();
            var window = new TestWindow(components);
            window.ShowDialog();

            return Result.Succeeded;
        }

        public bool ValidateElement(Element element)
        {
            return element is Wall;
        }
    }
}