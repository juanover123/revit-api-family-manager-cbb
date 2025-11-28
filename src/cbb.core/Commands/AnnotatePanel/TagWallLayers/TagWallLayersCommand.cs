using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using cbb.core;

namespace cbb.core
{
    /// <summary>
    /// Command code to be executed when button is clicked.
    /// </summary>
    /// <seealso cref="Autodesk.Revit.UI.IExternalCommand"/>
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]

    public class TagWallLayersCommand : IExternalCommand
    {
        #region public methods

        ///<summary>
        /// Tag wall layers by creating text note element on user specified point and populate it with wall layer information.
        /// </summary>
        /// <param name="commandData">The command data.</param>
        /// <param name="message">The message.</param>
        /// <param name="elements">The elements.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"</exception>
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Application context.
            var uidoc = commandData.Application.ActiveUIDocument;
            var doc = uidoc.Document;

            // Check if we are in the Revit Project, not in the family editor.
            if (doc.IsFamilyDocument)
            {
                Message.Display("This command is not available in the family editor. Please run it in a Revit project.", WindowType.Warning);
                return Result.Cancelled;
            }

            // Gets access to current active view.
            var activeView = doc.ActiveView;

            // Check if we can create text note in the active project view.
            bool canCreateTextNoteInView = false;
            switch (activeView.ViewType)
            {
                case ViewType.FloorPlan:
                    canCreateTextNoteInView = true;
                    break;
                case ViewType.CeilingPlan:
                    canCreateTextNoteInView = true;
                    break;
                case ViewType.Elevation:
                    canCreateTextNoteInView = true;
                    break;
                case ViewType.Section:
                    canCreateTextNoteInView = true;
                    break;
                case ViewType.Detail:
                    canCreateTextNoteInView = true;
                    break;
            }

            // Collector for data provided in window.
            var userInfo = new TagWallLayersCommandData();

            if (!canCreateTextNoteInView)
            {
                Message.Display("Cannot create text note in the current active view.", WindowType.Error);
                return Result.Cancelled;
            }

            // Get user provided information from window and show dialog.
            var window = new TagWallLayersForm(uidoc);
            bool? result = window.ShowDialog();

            if (result == true)
            {
                userInfo = window.GetInformation();
            }
            else
            {
                return Result.Cancelled;
            }

            // Ask user to select one basic wall.
            var selectionReference = uidoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element,
                new SelectionFilterByCategory(BuiltInCategory.OST_Walls),
                "Select one basic wall to tag its layers.");
            var selectionElement = doc.GetElement(selectionReference);

            // Cast generic element type to more specific Wall type.
            var wall = selectionElement as Wall;

            // Check if wall is the type of basic wall.
            if (wall.IsStackedWall)
            {
                Message.Display("Please select a basic wall, not a stacked wall.\nIt is not supported by this command.",
                    WindowType.Warning);
                return Result.Cancelled;
            }

            // Access list of wall layers.
            var layers = wall.WallType.GetCompoundStructure().GetLayers();

            // Get layer information in structured string format for TextNote.
            var msg = new StringBuilder();

            foreach (var layer in layers)
            {
                if (layer.Width == 0)
                    continue;

                var line = new StringBuilder();

                var material = doc.GetElement(layer.MaterialId) as Material;
                string materialName = (material == null) ? "<N/A>" : material.Name;

                if (userInfo.Function)
                {
                    line.Append($"{layer.Function.ToString()}");
                }

                if (userInfo.Name)
                {
                    if (line.Length > 0) line.Append(", ");
                    line.Append($"{materialName}");
                }

                if (userInfo.Thickness)
                {
                    double convertedThickness = LengthUnitsConverter.ConvertFromInternal(layer.Width,
                                  userInfo.unitType,
                                  userInfo.DecimalPlaces
                               );

                    string formatString = "F" + userInfo.DecimalPlaces.ToString();

                    string unitAbbreviation = LengthUnitsConverter.GetUnitAbbreviation(userInfo.unitType);

                    string formattedThickness = $"{convertedThickness.ToString(formatString)} {unitAbbreviation}";

                    if (line.Length > 0) line.Append(", ");
                    line.Append($"{formattedThickness}");
                }

                msg.AppendLine(line.ToString());
            }

            // Create text note options.
            var textNoteOptions = new TextNoteOptions
            {
                HorizontalAlignment = HorizontalTextAlignment.Left,
                VerticalAlignment = VerticalTextAlignment.Top,
                TypeId = userInfo.TextTypeId,
            };

            // Open Revit document transaction to create new Text Note element.
            using (var transaction = new Transaction(doc, "Tag Wall Layers"))
            {
                transaction.Start("Tag Wall Layers Command");

                var pt = new XYZ();

                // Construct sketch plane for user to pick point if we are in elevation or section views.
                if (activeView.ViewType == ViewType.Elevation || activeView.ViewType == ViewType.Section)
                {
                    var plane = Plane.CreateByNormalAndOrigin(activeView.ViewDirection, activeView.Origin);
                    var sketchPlane = SketchPlane.Create(doc, plane);
                    activeView.SketchPlane = sketchPlane;

                    // Ask user to pick point in elevation or section view.
                    pt = uidoc.Selection.PickPoint("Pick point to place wall layers info text note.");
                }
                else
                {
                    // Ask user to pick point in plan view.
                    pt = uidoc.Selection.PickPoint("Pick point to place wall layers info text note.");
                }

                // Create text note with wall layers info at user specified point.
                var textNote = TextNote.Create(doc, activeView.Id, pt, msg.ToString(), textNoteOptions);
                    
                transaction.Commit();
            }

            return Result.Succeeded;
        }   

        /// <summary>
        /// Gets the full namespace path to this command.
        /// </summary>
        /// <returns></returns>
        public static string GetPath()
        {
            // Return constructed namespace path.
            return typeof(TagWallLayersCommand).Namespace + "." + nameof(TagWallLayersCommand);
        }

        #endregion

    }
}
