using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using CoreRevitLibrary.Extensions;

namespace CoreRevitLibrary.Module6WorkingWithParameters
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class TransactionCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var result = Result.Failed;

            var uiApplication = commandData.Application;
            var uiDocument = uiApplication.ActiveUIDocument;
            var document = uiDocument.Document;

            var selectedWall = uiDocument.GetSelectedElements()[0];
            var markParameter = selectedWall.LookupParameter("Mark");

            var secondLevel = document.GetElementByName<Level>("Level 1");
            var baseConstraintParameter = selectedWall.get_Parameter(BuiltInParameter.WALL_BASE_CONSTRAINT);

            using (Transaction transaction = new Transaction(document, "set new mark"))
            {
                TaskDialog.Show("Before", transaction.GetStatus().ToString());
                transaction.Start();
                TaskDialog.Show("Inside", transaction.GetStatus().ToString());
                //markParameter.Set("NewMarkValue");
                baseConstraintParameter.Set(secondLevel.Id);
                transaction.Commit();
                TaskDialog.Show("After", transaction.GetStatus().ToString());
            }

            return result;
        }
    }
}