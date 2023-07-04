using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

using CoreRevitLibrary.Extensions;
using CoreRevitLibrary.GeometryUtils;

namespace CoreRevitLibrary.Modul7Geometry.Tasks
{
    [Transaction(TransactionMode.Manual)]
    class ProjectPointOntoPlaneExerciseCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Result result = Result.Failed;

            UIApplication uiApplication = commandData.Application;
            UIDocument uiDocument = uiApplication.ActiveUIDocument;
            Document document = uiDocument.Document;

            var family = uiDocument.GetSelectedElements()[0];
            var normal = new XYZ(1, 1, 0);
            var origin = new XYZ(32, 0, 0);

            var plane = Plane.CreateByNormalAndOrigin(normal, origin);

            document.Run(() => {
                family.GetPlacementPoint().ProjectOntoPlane(plane).Visualize(document);
                result = Result.Succeeded;
            });

     
            return result;
        }
    }
}
