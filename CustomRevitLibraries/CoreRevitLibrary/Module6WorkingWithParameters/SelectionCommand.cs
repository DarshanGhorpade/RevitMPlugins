/*
 * Module 4 Practice
 */
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using CoreRevitLibrary.Extensions;
using CoreRevitLibrary.TestCommands;

namespace CoreRevitLibrary.Module6WorkingWithParameters
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    class SelectionCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var uiApplication = commandData.Application;
            var application = uiApplication.Application;
            var uiDocument = uiApplication.ActiveUIDocument;
            var document = uiDocument.Document;

            var selectedWall = uiDocument.GetSelectedElements()[0];

            var markParameter = selectedWall.LookupParameter("Mark");
            var markParameters = selectedWall.GetParameters("Mark")
                .Where(p => (p.Definition as InternalDefinition)?.BuiltInParameter != BuiltInParameter.INVALID);
            var markParameterAsBulitIn = selectedWall.get_Parameter(BuiltInParameter.ALL_MODEL_MARK);
            // Get Elements by Name
            var window = new TestWindow(markParameters.Select(p=>p.Definition.Name));
            window.ShowDialog();

            return Result.Succeeded;
        }
    }
}
