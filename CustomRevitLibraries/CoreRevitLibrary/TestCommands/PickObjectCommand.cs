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

            var references = uiDocument.Selection.PickObjects(ObjectType.Element, new WallSelectionFilter());
            var components = references.Select(r => document.GetElement(r)).ToList();
            var window = new TestWindow(components);
            window.ShowDialog();

            return Result.Succeeded;
        }
    }

    public class WallSelectionFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            //return elem is Wall;
            return elem.Name.Contains("Brick");
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return true;
        }
    }
}