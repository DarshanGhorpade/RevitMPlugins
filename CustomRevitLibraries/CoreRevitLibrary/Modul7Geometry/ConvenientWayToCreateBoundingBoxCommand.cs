using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

using CoreRevitLibrary.Extensions;
using CoreRevitLibrary.GeometryUtils;

using System.Windows;

namespace CoreRevitLibrary.Modul7Geometry
{
    [Transaction(TransactionMode.Manual)]
    class ConvenientWayToCreateBoundingBoxCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Result result = Result.Failed;
            var uiApplication = commandData.Application;
            var uiDocument = uiApplication.ActiveUIDocument;
            var document = uiDocument.Document;

            // left alignment
            var length = 3;
            var minX = -length / 2 * 0;
            var maxX = length + minX;

            //var box = new BoundingBoxXYZ()
            //{
            //    Min = new XYZ(-1, -1, -1),
            //    Max = new XYZ(1, 1, 1)
            //};

            var box = new BoundingBoxXYZ()
            {
                Min = new XYZ(-1, minX, -1),
                Max = new XYZ(1, maxX, 1)
            };

            box.Transform = Transform.CreateTranslation(new XYZ(5, 0, 0));

            try
            {
                document.Run(() => {
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
