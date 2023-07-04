using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

using CoreRevitLibrary.Extensions;
using CoreRevitLibrary.GeometryUtils;

using System.Windows;

namespace CoreRevitLibrary.Modul7Geometry
{
    [Transaction(TransactionMode.Manual)]
    class PlacePointAlongCurve : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Result result = Result.Failed;

            var uiApplication = commandData.Application;
            var uiDocument = uiApplication.ActiveUIDocument;
            var document = uiDocument.Document;

            var element = uiDocument.GetSelectedElements()[0];

            // get locationCurve of the element
            var curve = element.GetPlacementCurve();

            var point = curve.Evaluate(1, true);        // we get the point at end of the curve
            //var point = curve.Evaluate(0, true);      // we get the point at start of the curve
            //var point = curve.Evaluate(0.5, true);    // we get the point at cneter of the curve
            //var point = curve.Evaluate(1, false);     // not using normalized option (false), we will get point along the curve with distance of 1 from beginning point 

            try
            {
                document.Run(() => {
                    point.Visualize(document);
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
