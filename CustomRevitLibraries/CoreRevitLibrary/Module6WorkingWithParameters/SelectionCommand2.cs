/*
 * Module 4 Practice
 */

using System;
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
    class SelectionCommand2 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var uiApplication = commandData.Application;
            var application = uiApplication.Application;
            var uiDocument = uiApplication.ActiveUIDocument;
            var document = uiDocument.Document;

            var selectedWall = uiDocument.GetSelectedElements()[0];

            var markParameter = selectedWall.LookupParameter("Mark");
            var markValue = markParameter.AsString();
            
            var roomBoundingAttrParameter = selectedWall.get_Parameter(BuiltInParameter.WALL_ATTR_ROOM_BOUNDING);
            var roomBoundingAttrValue = roomBoundingAttrParameter.AsInteger();

            var levelParameter = selectedWall.get_Parameter(BuiltInParameter.WALL_BASE_CONSTRAINT);
            var levelId = levelParameter.AsElementId();
            var level = document.GetElement(levelId);

            // Get Elements by Name
            var window = new TestWindow(new List<string>() { markValue, level.Name });
            window.ShowDialog();
            
            window = new TestWindow(new List<int>() { roomBoundingAttrValue });
            window.ShowDialog();

            return Result.Succeeded;
        }
    }
}