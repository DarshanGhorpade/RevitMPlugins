using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

using CoreRevitLibrary.Extensions;
using CoreRevitLibrary.GeometryUtils;

using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace CoreRevitLibrary.Modul7Geometry
{
    [Transaction(TransactionMode.Manual)]
    class WhatSolidConsistsCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Result result = Result.Failed;

            var uiApplication = commandData.Application;
            var uiDocument = uiApplication.ActiveUIDocument;
            var document = uiDocument.Document;

            var element = uiDocument.GetSelectedElements()[0];

            var options = new Options();

            var solid = element.get_Geometry(options).GetRootElements<Solid>().First();

            var faces = solid.Faces.OfType<Face>().ToList();
            var curves = new List<Curve>();
            try
            {
                document.Run(() => {
                    foreach (var face in faces)
                    {
                        curves = face.GetEdgesAsCurveLoops().SelectMany(x => x).ToList();
                        var vertices = curves.SelectMany(c => c.Tessellate()).ToList();
                        document.CreateDirectShape(curves);
                        //document.CreateDirectShape(vertices.Select(v => Point.Create(v));
                        document.CreateDirectShape(vertices.Select(Autodesk.Revit.DB.Point.Create));
                    }
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
