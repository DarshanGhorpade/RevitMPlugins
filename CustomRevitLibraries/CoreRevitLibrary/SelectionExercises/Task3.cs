/*
 * Select the instances of type walls and familyInstances whose property Mark is Revit
 * doesn't matter it is case sensitive or not
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using CoreRevitLibrary.TestCommands;

namespace CoreRevitLibrary.SelectionExercises
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Task3 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var uiApplication = commandData.Application;
            var application = uiApplication.Application;
            var uiDocument = uiApplication.ActiveUIDocument;
            var document = uiDocument.Document;

            ParameterValueProvider markValueProvider = new ParameterValueProvider(new ElementId(BuiltInParameter.DOOR_NUMBER));

            FilterStringEquals filterStringEquals = new FilterStringEquals();
            FilterStringRule filterStringRule = new FilterStringRule(markValueProvider, filterStringEquals, "revit", false);

            ElementParameterFilter parameterFilter = new ElementParameterFilter(filterStringRule);
            var types = new List<Type>()
            {
                typeof(Wall),
                typeof(FamilyInstance)
            };

            ElementMulticlassFilter multiClassFilter = new ElementMulticlassFilter(types);

            var collector = new FilteredElementCollector(document)
                .WherePasses(multiClassFilter)
                .WherePasses(parameterFilter);

            var ans = collector.GetElementCount();
            TaskDialog.Show("Message", $"The answer is {ans}");

            // if you want see the value of elements from your collector
            var parameterValues = collector
                .Select(e => e.get_Parameter(BuiltInParameter.DOOR_NUMBER).AsString())
                .ToList();
            TestWindow testWindow = new TestWindow(parameterValues);
            testWindow.Show();

            return Result.Succeeded;
        }
    }
}