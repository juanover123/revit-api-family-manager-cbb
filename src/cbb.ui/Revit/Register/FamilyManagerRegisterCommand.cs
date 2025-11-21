namespace cbb.ui
{
    using Autodesk.Revit.UI;
    using Autodesk.Revit.DB;

    using core;
    using ui;

    using System.Windows;

    /// <summary>
    /// Register family manager command in zero state document.
    /// </summary> 
    /// <seealso cref="Autodesk.Revit.UI.IExternalCommand"/>
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class FamilyManagerRegisterCommand : IExternalCommand
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
            return Execute(commandData.Application);
        }

        /// <summary>
        /// Register dockable pane.
        /// </summary>
        /// <param name="uIApplication">The ui application.</param>
        /// <returns></returns>
        public Result Execute(UIApplication uIApplication)
        {
            var data = new DockablePaneProviderData();
            var managerPage = new FamilyManagerMainPage();

            
            data.FrameworkElement = managerPage as FrameworkElement;

            // Setup initial state.
            var state = new DockablePaneState
            {
                DockPosition = DockPosition.Right,
                TabBehind = DockablePanes.BuiltInDockablePanes.ProjectBrowser,
            };

            // Use unique GUID identifier for this dockable pane.
            var dpid = new DockablePaneId(PaneIdentifiers.GetFamilyManagerPaneId());

            // Register the dockable pane.
            uIApplication.RegisterDockablePane(dpid, "Family Manager", managerPage as IDockablePaneProvider);

            return Result.Succeeded;
        }


        #endregion
    }
}
