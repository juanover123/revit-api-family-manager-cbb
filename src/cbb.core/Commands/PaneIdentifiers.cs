namespace cbb.core
{
    using Autodesk.Revit.UI;
    using System;

    /// <summary>
    /// Guid container that holds all pane identifiers used in the application.
    /// </summary>
    public static class PaneIdentifiers
    {
        #region public properties

        public static readonly DockablePaneId FamilyManagerPaneId = new DockablePaneId(new Guid("D1F5E8C3-3C6B-4F2A-9D7B-8F1E6C3A9B2E"));

        #endregion
    }
}
