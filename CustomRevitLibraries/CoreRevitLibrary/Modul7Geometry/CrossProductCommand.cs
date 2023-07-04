using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

using CoreRevitLibrary.Extensions;
using CoreRevitLibrary.GeometryUtils;

namespace CoreRevitLibrary.Modul7Geometry
{
    [Transaction(TransactionMode.Manual)]
    class CrossProductCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Result result = Result.Failed;

            UIApplication uiApplication = commandData.Application;
            UIDocument uiDocument = uiApplication.ActiveUIDocument;
            Document document = uiDocument.Document;

            //var placementPoint = uiDocument.GetSelectedElements()[0].GetPlacementPoint();

            var v1 = new XYZ(9, 2, 2);
            var v2 = new XYZ(-2, 9, -4);

            document.Run(() => {
                v1.AsCurve().Visualize(document);
                v2.AsCurve().Visualize(document);
                v1.CrossProduct(v2).AsCurve().Visualize(document);
                //XYZ.BasisX.AsCurve().Visualize(document);
                //XYZ.BasisY.AsCurve().Visualize(document);
                //XYZ.BasisX.CrossProduct(XYZ.BasisY).AsCurve().Visualize(document);
                result = Result.Succeeded;
            });

            return result;
        }
    }
}
