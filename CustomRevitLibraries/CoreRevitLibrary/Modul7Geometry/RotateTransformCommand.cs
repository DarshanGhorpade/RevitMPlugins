using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using CoreRevitLibrary.Extensions;
using CoreRevitLibrary.GeometryUtils;
using System.Windows;

namespace CoreRevitLibrary.Modul7Geometry
{
    [Transaction(TransactionMode.Manual)]
    class RotateTransformCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Result result = Result.Failed;

            var uiApplication = commandData.Application;
            var uiDocument = uiApplication.ActiveUIDocument;
            var document = uiDocument.Document;

            var transformAroundZ = Transform.CreateRotation(XYZ.BasisZ, 30.0.ToRadians());
            var transformAroundX = Transform.CreateRotation(XYZ.BasisX, 30.0.ToRadians());

            var combinedTransform = transformAroundZ.Multiply(transformAroundX);

            try
            {
                document.Run(() =>
                {
                    //transformAroundZ.Visualize(document);
                    //transformAroundX.Visualize(document);
                    combinedTransform.Visualize(document);
                });
                result = Result.Succeeded;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            return result;
        }
    }
}
                                           