namespace cbb.core
{
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI;

    /// <summary>
    /// Hide Family Manager dockable pane.
    /// </summary>
    /// <seealso cref="Autodesk.Revit.UI.IExternalCommand" />"/>
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class FamilyManagerHideCommand : IExternalCommand
    {
        #region public methods

        /// <summary>
        /// Executes the specified command data.
        /// </summary>
        /// <param name="commandData">The command data.</param>
        /// <param name="message">The message.</param>
        /// <param name="elements">The elements.</param>
        /// <returns></returns>
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var dpid = new DockablePaneId(PaneIdentifiers.GetFamilyManagerPaneId());
            var dp = commandData.Application.GetDockablePane(dpid);
            dp.Hide();

            return Result.Succeeded;
        }

        /// <summary>
        /// Gets the full namespace path to this command.
        /// </summary>
        /// <returns></returns>
        public static string GetPath()
        {
            // Return constructed namespace path.
            return typeof(FamilyManagerHideCommand).Namespace + "." + nameof(FamilyManagerHideCommand);
        }

        #endregion
    }
}
