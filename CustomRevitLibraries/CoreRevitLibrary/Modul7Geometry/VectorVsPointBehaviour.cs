using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using CoreRevitLibrary.Extensions;
using CoreRevitLibrary.GeometryUtils;
using System.Windows;

namespace CoreRevitLibrary.Modul7Geometry
{
    [Transaction(TransactionMode.Manual)]
    class VectorVsPointBehaviour : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Result result = Result.Failed;
            try
            {
                UIApplication uiApplication = commandData.Application;
                UIDocument uiDocument = uiApplication.ActiveUIDocument;
                Document document = uiDocument.Document;

                var selectedElement = uiDocument.GetSelectedElements()[0];

                XYZ vector = new XYZ(9, 12, 0);

                var locationPoint = selectedElement.Location as LocationPoint;
                document.Run(() => {
                    //locationPoint.Point = vector;

                    selectedElement.GetPlacementPoint().Visualize(document);

                    //locationPoint.Point.Visualize(document);
                    //document.CreateDirectShape(Autodesk.Revit.DB.Point.Create(locationPoint.Point));
                });

                result = Result.Succeeded;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                result = Result.Failed;
            }

            return result;
        }
    }
}
