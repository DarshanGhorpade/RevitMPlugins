/*
 * Leverage the power of delegates to 
 * make the class extensible
 */

using System.Linq;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace CoreRevitLibrary.TestCommands
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class PickObjectByReferenceCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var uiApplication = commandData.Application;
            var application = uiApplication.Application;
            var uiDocument = uiApplication.ActiveUIDocument;
            var document = uiDocument.Document;
            var elementSelectionFilter = new ElementSelectionFilter(e => e is Wall,
                r => r.ElementReferenceType == ElementReferenceType.REFERENCE_TYPE_SURFACE);
            var linkableSelectionFilter = new LinkableSelectionFilter(
                document,
                (e=>e is Wall));
            var references = uiDocument.Selection
                .PickObjects(
                    ObjectType.PointOnElement,
                    linkableSelectionFilter,
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