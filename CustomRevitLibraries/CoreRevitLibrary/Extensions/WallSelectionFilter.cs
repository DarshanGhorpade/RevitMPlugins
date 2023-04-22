using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;

namespace CoreRevitLibrary.TestCommands
{
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