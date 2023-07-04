using System;
using System.Linq;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using CoreRevitLibrary.Extensions;

namespace CoreRevitLibrary.Module6WorkingWithParameters.Tasks
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Task1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var result = Result.Failed;

            UIApplication uiApplication = commandData.Application;
            UIDocument uiDocument = uiApplication.ActiveUIDocument;
            Document document = uiDocument.Document;

            Level levelToCheckBy = document.GetElementByName<Level>("Level 1");

            var walls = document.GetElementsByType<Wall>()
                .Where(w => !w.IsCurtain())
                .Where(w => w.get_Parameter(BuiltInParameter.WALL_BASE_CONSTRAINT).AsElementId() == levelToCheckBy.Id && 
                            w.get_Parameter(BuiltInParameter.WALL_BASE_OFFSET).AsDouble() > 1 && 
                            w.get_Parameter(BuiltInParameter.ALL_MODEL_DESCRIPTION).AsString() == "TheOne")
                .ToList();
            var sum = walls.Sum(w => w.WallType.Id.IntegerValue + w.get_Parameter(BuiltInParameter.HOST_VOLUME_COMPUTED).AsDouble());
            var answer = Math.Round(sum, 2);

            TaskDialog.Show("Answer", $"The answer is {answer}, walls count {walls.Count}");

            document.Run(() =>
                {
                    uiDocument.Highlight(walls);
                },
                "Highlight walls"
            );
            return result;                                                                                                                                                                                     
        }
    }
}