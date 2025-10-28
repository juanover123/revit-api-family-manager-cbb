using Autodesk.Revit.UI;

namespace cbb

    /// <summary>
    /// Plugin's main entry point
    /// </summary>
    /// <seealso cref="Autodesk.Revit.UI.IExternalApplication"/>
{
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
    }
}
