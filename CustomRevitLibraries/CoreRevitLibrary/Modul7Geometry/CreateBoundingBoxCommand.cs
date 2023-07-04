using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

using CoreRevitLibrary.Extensions;
using CoreRevitLibrary.GeometryUtils;

using System.Windows;

namespace CoreRevitLibrary.Modul7Geometry
{
    [Transaction(TransactionMode.Manual)]
    class CreateBoundingBoxCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Result result = Result.Failed;
            var uiApplication = commandData.Application;
            var uiDocument = uiApplication.ActiveUIDocument;
            var document = uiDocument.Document;

            var box = new BoundingBoxXYZ()
            {
                Min = new XYZ(-1, -1, -1),
                Max = new XYZ(1, 1, 1)
            };

            box.Transform = Transform.CreateTranslation(new XYZ(5, 0, 0));

            try
            {
                document.Run(() => {
                    box.Transform.Visualize(document);
                    TaskDialog.Show("Message", $"Min : {box.Min}, Max : {box.Max}");
                    box.Transform.OfPoint(box.Min).Visualize(document);
                    box.Transform.OfPoint(box.Max).Visualize(document);
                    box.Min.Visualize(document);
                    box.Max.Visualize(document);
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
