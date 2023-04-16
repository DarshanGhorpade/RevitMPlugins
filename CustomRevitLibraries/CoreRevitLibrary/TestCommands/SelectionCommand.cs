/*
 * Module 4 Practice
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using CoreRevitLibrary.Extensions;

namespace CoreRevitLibrary.TestCommands
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
            var types = new List<Type>()
            {
                typeof(Wall),
                typeof(FamilyInstance)
            };
            // Using new extension method GetElementsByTypes
            //var components = document.GetElementsByTypes<Wall, FamilyInstance, Floor>();
            // var components = document.GetElementsByTypes(types);
            
            // Using params
            //var components = document.GetElementsByTypes(typeof(Wall), typeof(Floor), typeof(FamilyInstance));

            // Get Elements by Name
            var component = document.GetElementByName<Wall>("Brick");
            var window = new TestWindow(new List<Element>() {component});
            window.ShowDialog();

            // Using Extension method
            /*
            var walls = document.GetElementsByTypes<Wall>()
                .Where(w=>w.Name.Contains("Brick"));
            */
            // Adding delegate to extension method
            // Gives all walls having Brick in there names
            // var walls = document.GetElementsByTypes<Wall>(w => w.Name.Contains("Brick"));

            /*
            var collector = new FilteredElementCollector(document)
                .OfCategory(BuiltInCategory.OST_Walls)
                .WhereElementIsNotElementType();
            */
            /*
            var collector = new FilteredElementCollector(document)
                .OfClass(typeof(FloorType));
            */
            /*
             * ElementClassFilter
             */
            /*
            var wallFilter = new ElementClassFilter(typeof(Wall));
            var familyInstanceFilter = new ElementClassFilter(typeof(FamilyInstance));
            */
            /*
             * LogicalORFilter
             */
            /*
            LogicalOrFilter logicalOrFilter = new LogicalOrFilter(wallFilter, familyInstanceFilter);
            var collector = new FilteredElementCollector(document)
                .WherePasses(logicalOrFilter);
            */
            //TaskDialog.Show("Message", collector.Count.ToString());
            /*
            TestWindow testWindow = new TestWindow(collector);
            testWindow.ShowDialog();
            */
            return Result.Succeeded;
        }
    }
}
