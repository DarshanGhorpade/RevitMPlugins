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
    class GetSymbolGeometryOfFamilyInstance : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Result result = Result.Failed;

            var uiApplication = commandData.Application;
            var uiDocument = uiApplication.ActiveUIDocument;
            var document = uiDocument.Document;

            var familyInstance = uiDocument.GetSelectedElements()[0] as FamilyInstance;

            GeometryElement geometryElement = familyInstance.get_Geometry(new Options());

            var solids = familyInstance
                .get_Geometry(new Options())
                .Cast<GeometryInstance>()
                .SelectMany(gi => gi.GetSymbolGeometry().OfType<Solid>())
                .Select(s => SolidUtils.CreateTransformed(s, familyInstance.GetTotalTransform()));
                
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
