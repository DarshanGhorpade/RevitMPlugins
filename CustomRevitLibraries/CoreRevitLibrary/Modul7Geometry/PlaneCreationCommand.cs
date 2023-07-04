using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

using CoreRevitLibrary.Extensions;
using CoreRevitLibrary.GeometryUtils;

namespace CoreRevitLibrary.Modul7Geometry
{
    [Transaction(TransactionMode.Manual)]
    class PlaneCreationCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Result result = Result.Failed;

            UIApplication uiApplication = commandData.Application;
            UIDocument uiDocument = uiApplication.ActiveUIDocument;
            Document document = uiDocument.Document;

            // Crete plane with normal as Z axis and origin at Zero
            var plane = Plane.CreateByNormalAndOrigin(XYZ.BasisZ, XYZ.Zero);

            document.Run(() =>
            {
                plane.Visualize(document);
            }, $"Create Plane {plane}");

            return result;
        }
    }
}
