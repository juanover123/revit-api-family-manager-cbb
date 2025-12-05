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
            try 
            {
                var managerPage = new FamilyManagerMainPage();

                // Register the dockable pane.
                uIApplication.RegisterDockablePane(
                    PaneIdentifiers.FamilyManagerPaneId, // GUID
                    "Family Manager",                   // Tab title
                    managerPage as IDockablePaneProvider // Content
                );
                return Result.Succeeded;
            }
            catch (System.Exception ex)
            {
                core.Message.Display("ERROR al registrar el panel acoplable: " + ex.Message, core.WindowType.Error);

                return Result.Failed;
            }

        }


        #endregion
    }
}
