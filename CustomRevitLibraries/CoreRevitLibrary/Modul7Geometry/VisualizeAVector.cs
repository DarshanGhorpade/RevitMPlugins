using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using CoreRevitLibrary.Extensions;
using CoreRevitLibrary.GeometryUtils;

namespace CoreRevitLibrary.Modul7Geometry
{
    [Transaction(TransactionMode.Manual)]
    class VisualizeAVector : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Result result = Result.Failed;

            UIApplication uiApplication = commandData.Application;
            UIDocument uiDocument = uiApplication.ActiveUIDocument;
            Document document = uiDocument.Document;

            var placementPoint = uiDocument.GetSelectedElements()[0].GetPlacementPoint();

            var v1 = new XYZ(0, 9, 0);
            var line = Line.CreateBound(XYZ.Zero, placementPoint);
            
            document.Run(() => {
                document.CreateDirectShape(v1.AsCurve(placementPoint, 4));
                result = Result.Succeeded;
            });

            return result;
        }
    }
}
