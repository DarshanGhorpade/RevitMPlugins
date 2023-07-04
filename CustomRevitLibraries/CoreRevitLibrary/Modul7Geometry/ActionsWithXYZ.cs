using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

using CoreRevitLibrary.Extensions;
using CoreRevitLibrary.GeometryUtils;

namespace CoreRevitLibrary.Modul7Geometry
{
    [Transaction(TransactionMode.Manual)]
    class ActionsWithXYZ : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Result result = Result.Failed;

            UIApplication uiApplication = commandData.Application;
            UIDocument uiDocument = uiApplication.ActiveUIDocument;
            Document document = uiDocument.Document;

            //var origin = new XYZ(0, 12, 0);
            //var xVector = new XYZ(9, 0, 0);
            //var movedPoint = origin + xVector;

            var v1 = new XYZ(9, 0, 0);
            var v2 = new XYZ(0, 3, 0);
            var v3 = v1 * 2;
            var nV1 = v1.Normalize();

            document.Run(() =>
            {
                v1.Visualize(document);
                nV1.Visualize(document);
                TaskDialog.Show("Message", nV1.IsUnitLength().ToString());
                //v2.Visualize(document);
                //v3.Visualize(document);
                //origin.Visualize(document);
                //movedPoint.Visualize(document);
            });

            return result;
        }
    }
}
