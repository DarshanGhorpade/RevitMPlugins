using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using CoreRevitLibrary.Extensions;
using CoreRevitLibrary.GeometryUtils;
using System.Windows;

namespace CoreRevitLibrary.Modul7Geometry
{
    [Transaction(TransactionMode.Manual)]
    class GetInvisibleGeometry : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Result result = Result.Failed;

            var uiApplication = commandData.Application;
            var uiDocument = uiApplication.ActiveUIDocument;
            var document = uiDocument.Document;

            var element = uiDocument.GetSelectedElements()[0];

            var options = new Options()
            {
                IncludeNonVisibleObjects = true
            };

            var solids = element.get_Geometry(options).GetRootElements<Solid>();

            try
            {
                document.Run(() => {
                    foreach (var solid in solids)
                    {
                        solid.Visualize(document);
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
