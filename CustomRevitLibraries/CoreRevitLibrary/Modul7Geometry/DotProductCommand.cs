using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

using CoreRevitLibrary.Extensions;
using CoreRevitLibrary.GeometryUtils;

namespace CoreRevitLibrary.Modul7Geometry
{
    [Transaction(TransactionMode.Manual)]
    class DotProductCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Result result = Result.Failed;

            UIApplication uiApplication = commandData.Application;
            UIDocument uiDocument = uiApplication.ActiveUIDocument;
            Document document = uiDocument.Document;

            //var v1 = new XYZ(1, 0, 0);

            var mainDirection = XYZ.BasisY;

            var v1 = new XYZ(1, 1, 0);
            var v2 = new XYZ(-1, -1, 0);

            document.Run(() => {
                mainDirection.AsCurve().Visualize(document);
                //v1.AsCurve().Visualize(document);
                v2.AsCurve().Visualize(document);
            TaskDialog.Show("Message", mainDirection.DotProduct(v2).ToString());
            });

            return result;
        }
    }
}
