using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices;

namespace cbb

    /// <summary>
    /// Plugin's main entry point
    /// </summary>
    /// <seealso cref="Autodesk.Revit.UI.IExternalApplication"/>
{
    using ui;


    public class Main : IExternalApplication
    {
        #region external application public methods

        /// <summary>
        /// Called when Revit starts up.
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Result OnStartup(UIControlledApplication application)
        {
            // Initializez whole plugin's user inteface.
            var ui = new SetupInterface();
            ui.Initialize(application);

            application.ControlledApplication.ApplicationInitialized += DockablePaneRegisters;

            return Result.Succeeded;
        }

        /// <summary> 
        /// Called when Revit is shutting down.
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
        #endregion

        #region private methods

        /// <summary>
        /// Registers dockable panes when application is initialized.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DockablePaneRegisters(object sender, Autodesk.Revit.DB.Events.ApplicationInitializedEventArgs e)
        {
            //Register Family Manager dockable pane.

            var familyManagerRegisterCommand = new ui.FamilyManagerRegisterCommand();

            Result result = familyManagerRegisterCommand.Execute(new UIApplication(sender as Application));

            if (result == Result.Succeeded)
            {
                if (SetupInterface.FamilyManagerShowButton != null)
                {
                    SetupInterface.FamilyManagerShowButton.Enabled = true;
                }
                if (SetupInterface.FamilyManagerHideButton != null)
                {
                    SetupInterface.FamilyManagerHideButton.Enabled = true;
                }
            }
        }

        #endregion
    }
}
