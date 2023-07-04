using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

using CoreRevitLibrary.Extensions;

using System;

namespace CoreRevitLibrary.Modul7Geometry.Tasks
{
    [Transaction(TransactionMode.Manual)]
    class trigonometryTask1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Result result = Result.Failed;

            UIApplication uiApplication = commandData.Application;
            UIDocument uiDocument = uiApplication.ActiveUIDocument;
            Document document = uiDocument.Document;

            var verticalLeg = 2;
            var angle = 30.0.ToRadians();
            // var angle = Math.PI / 6;

            var horizontalLeg = verticalLeg / Math.Tan(angle);
            TaskDialog.Show("Message", horizontalLeg.ToString());

            return result;
        }
    }
}
