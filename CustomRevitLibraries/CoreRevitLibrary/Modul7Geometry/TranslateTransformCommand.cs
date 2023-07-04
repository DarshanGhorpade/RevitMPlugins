using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

using CoreRevitLibrary.Extensions;
using CoreRevitLibrary.GeometryUtils;

namespace CoreRevitLibrary.Modul7Geometry
{
    [Transaction(TransactionMode.Manual)]
    class TranslateTransformCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements) { 
            Result result = Result.Failed;

            var uiApplication = commandData.Application;
            var uiDocument = uiApplication.ActiveUIDocument;
            var document = uiDocument.Document;

            /*
            var transform = Transform.Identity;
            transform.Origin = new XYZ(3, 2, 1);
            transform.origin *= 2;
            */

            var transform = Transform.CreateTranslation(new XYZ(3, 1, 1));

            document.Run(() =>
            {
                transform.Visualize(document);
            });

            return result;
        }
    }
}

/*
 *  You can change origin of the transform OR
 *  You can use CreateTranslation to move the location
 */