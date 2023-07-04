using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

using CoreRevitLibrary.Extensions;
using CoreRevitLibrary.GeometryUtils;
using System.Linq;
using System.Windows;

namespace CoreRevitLibrary.Modul7Geometry
{
    [Transaction(TransactionMode.Manual)]
    class GetGeometryElementOfSelectedElementCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Result result = Result.Failed;

            var uiApplication = commandData.Application;
            var uiDocument = uiApplication.ActiveUIDocument;
            var document = uiDocument.Document;

            var wall = uiDocument.GetSelectedElements()[0];

            GeometryElement geometryElement = wall.get_Geometry(new Options());

            var solids = wall.get_Geometry(new Options()).Select(go => go as Solid);

            try
            {
                document.Run(() => {
                    foreach (var solid in solids)
                    {
                        solid.Visualize(document);
                    }

                    /*
                    foreach (var geometryObject in geometryElement)
                    {
                        var solid = geometryObject as Solid;
                        // document.CreateDirectShape(solid);
                        solid.Visualize(document);
                    }
                    */
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
