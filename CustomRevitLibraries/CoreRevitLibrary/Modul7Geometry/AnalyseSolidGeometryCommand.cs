using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using CoreRevitLibrary.Enums;
using CoreRevitLibrary.Extensions;
using CoreRevitLibrary.GeometryUtils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace CoreRevitLibrary.Modul7Geometry
{
    [Transaction(TransactionMode.Manual)]
    class AnalyseSolidGeometryCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Result result = Result.Failed;
            var uiApplication = commandData.Application;
            var uiDocument = uiApplication.ActiveUIDocument;
            var document = uiDocument.Document;
            var wall = uiDocument.GetSelectedElements()[0] as Wall;
            var wallSolid = wall
                .GetGeometryObjects<Solid>()
                .Union();
            var wallCurve = wall.GetPlacementCurve();
            var wallCurveVector = wallCurve.ToNormalizedVector();
            var orientation = wall.Orientation;

            //var face = wallSolid.GetFaces().Cast<PlanarFace>().First(f => f.FaceNormal.IsAlmostEqualTo(orientation));
            var face = wallSolid.GetFaces().Cast<PlanarFace>().First(f => f.FaceNormal.GetRelationTo(orientation) == VectorRelation.Reversed);

            try
            {
                document.Run(() => {
                    //var curves = face.GetEdgesAsCurveLoops()
                    //    .SelectMany(x => x)
                    //    .ToList();
                    //document.CreateDirectShape(curves);
                    orientation.AsCurve(wall.GetPlacementCurve().GetCenter()).Visualize(document);
                    XYZ.BasisZ.AsCurve(wall.GetPlacementCurve().GetCenter()).Visualize(document);
                    XYZ.BasisZ.CrossProduct(orientation).AsCurve(wall.GetPlacementCurve().GetCenter()).Visualize(document);
                    //orientation.AsCurve(wall.GetPlacementCurve().GetCenter()).Visualize(document);
                    //wallSolid.Visualize(document);
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
