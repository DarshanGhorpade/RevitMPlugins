using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

using CoreRevitLibrary.Extensions;
using CoreRevitLibrary.GeometryUtils;

using System.Collections.Generic;
using System.Windows;

namespace CoreRevitLibrary.Modul7Geometry
{
    [Transaction(TransactionMode.Manual)]
    class VisualizeBoundingBoxCommand : IExternalCommand
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

            var transform = Transform.CreateTranslation(XYZ.BasisX * 5);

            var box = new BoundingBoxXYZ()
            {
                Min = new XYZ(-1, -1, -1),
                Max = new XYZ(1, 1, 1),
                Transform = transform
            };

            var pt1 = box.Min;
            var pt2 = pt1.MoveAlongVector(XYZ.BasisX, 2);
            var pt3 = pt2.MoveAlongVector(XYZ.BasisY, 2);
            var pt4 = pt1.MoveAlongVector(XYZ.BasisY, 2);

            box.Transform = Transform.CreateTranslation(new XYZ(5, 0, 0)).Multiply(Transform.CreateRotation(XYZ.BasisZ, 30.0.ToRadians()));

            var curveLoop = CurveLoop.Create(
                new List<Curve>() {
                    Line.CreateBound(pt1, pt2),
                    Line.CreateBound(pt2, pt3),
                    Line.CreateBound(pt3, pt4),
                    Line.CreateBound(pt4, pt1)
                });

            var solid = GeometryCreationUtilities.CreateExtrusionGeometry(
                new List<CurveLoop>() { curveLoop },
                XYZ.BasisZ,
                2).CreateTransformed(transform);

            try
            {
                document.Run(() => {
                    solid.Visualize(document);
                    //foreach (var curve in curveLoop)
                    //{
                    //    curve.Visualize(document);
                    //}
                    //box.Min.Visualize(document);
                    //box.Max.Visualize(document);
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
